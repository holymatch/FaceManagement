using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Tracking;
using Emgu.CV.Util;
using RestfulClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceManagement
{
    class FaceTracker : IDisposable
    {
        private const int SUCCESSRETRYFRAMECOUNT = 120;
        private const string TRACKERTYPE = "MEDIANFLOW";
        private const float INTERSECTRATIO = 0.3f;

        private Tracker tracker;
        public bool findFace { get; set; }
        public int failFrameCount { get; set; } //The frame that can't track the face
        private bool isInit;
        public HumanFace humanFace { get; set; }
        public Person Person { get; set; }
        public bool FailToRecognize { get; set; }
        public int successFrameCount { get; set; }
        public bool missingFace{ get; set; }

    public FaceTracker(HumanFace face)
        {
            tracker = new TrackerMedianFlow(10, new Size(3, 3), 5, new MCvTermCriteria(20, 0.3), new Size(30, 30));
            humanFace = face;
            findFace = false;
            isInit = false;
            failFrameCount = 0;
            FailToRecognize = false;
            missingFace = false;
        }

        private FaceTracker()
        {
            tracker = new TrackerMedianFlow(10, new Size(3,3), 5, new MCvTermCriteria(20, 0.3), new Size(30,30));
        }

        public bool trackFace(Image<Bgr, byte> bgrImage)
        {
            var result = false;

            using (var grayframe = new Image<Gray, byte>(new Bitmap(bgrImage.Bitmap)))
            {
                if (!isInit)
                {
                    if (bgrImage != null)
                    {
                        result = trackingInit(bgrImage);
                    }
                }
                else
                {
                    if (bgrImage != null)
                    {
                        try
                        {
                            var updateFace = new Rectangle();
                            result = tracker.Update(grayframe.Mat, out updateFace);
                            if (!result)
                            {
                                failFrameCount++;
                                findFace = false;
                            }
                            else
                            {

                                //var updateFace = new Rectangle();
                                //var result = tracker.Update(grayframe.Mat, out updateFace);

                                /*
                                 * for ( var i = 0; i < updateFace.ToArray().Count(); i ++)
                                {
                                    bgrImage.Draw(updateFace.ToArray()[i], new Bgr(Color.Red), 3);
                                }*/

                                Color color = Color.Gray;
                                if (Person != null)
                                {
                                    color = Color.Green;
                                }
                                else if (FailToRecognize)
                                {
                                    color = Color.Red;
                                }

                                bgrImage.Draw(updateFace, new Bgr(color), 3);
                                //TODO update name
                                if (Person != null)
                                {
                                    using (Graphics g = Graphics.FromImage(bgrImage.Bitmap))
                                    {
                                        int tWidth = (int)g.MeasureString(Person.Name, new Font("Arial", 12, FontStyle.Bold)).Width;
                                        int x;
                                        if (tWidth >= updateFace.Width)
                                            x = updateFace.Left - ((tWidth - updateFace.Width) / 2);
                                        else
                                            x = (updateFace.Width / 2) - (tWidth / 2) + updateFace.Left;

                                        g.DrawString(Person.Name, new Font("Arial", 12, FontStyle.Bold), Brushes.Green, new PointF(x, updateFace.Top - 18));
                                    }                                    
                                }
                                humanFace.faceRectangle = updateFace;
                                findFace = true;
                                //UpdatePersonAsync();
                                if (FailToRecognize)
                                {
                                    failFrameCount++;
                                    successFrameCount = 0;
                                }
                                else
                                {
                                    failFrameCount = 0;
                                    if (successFrameCount > SUCCESSRETRYFRAMECOUNT)
                                    {
                                        FaceDetector faceDetector = new FaceDetector();
                                        
                                        var detectedFaces = faceDetector.findFace(bgrImage);
                                        var sameFaceFind = false;
                                        foreach (var r1 in detectedFaces)
                                        {
                                            var r1Size = r1.Height * r1.Width;
                                            var r2 = humanFace.faceRectangle;
                                            float r2Size = r2.Height * r2.Width;
                                            var r3 = Rectangle.Intersect(r1, r2);
                                            if (!r3.IsEmpty)
                                            {
                                                float r3Size = r3.Height * r3.Width;
                                                float ratio = r3Size / Math.Min(r1Size, r2Size);
                                                if (ratio < INTERSECTRATIO)
                                                {

                                                    Debug.Print("Face compare, Ratio: {0}", ratio);
                                                }
                                                else
                                                {
                                                    sameFaceFind = true;
                                                }
                                            }
                                            else
                                            {
                                                Debug.Print("r3 is empty");
                                            }
                                        }
                                        
                                        

                                        if (!sameFaceFind)
                                        {
                                            missingFace = true;
                                        }
                                        faceDetector = null;
                                        successFrameCount = 0;
                                    } else
                                    {
                                        successFrameCount++;
                                    }                                    
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(ex.ToString());
                        }
                    }
                }
            }
            return result;
        }

        private bool trackingInit(Image<Bgr, byte> bgrImage)
        {
            using (var grayframe = new Image<Gray, byte>(new Bitmap(bgrImage.Bitmap)))
            {
                var faceDetector = new FaceDetector();

                isInit = tracker.Init(grayframe.Mat, humanFace.faceRectangle);
                //Debug.Print("Tracking Init {0}", isInit);
                if (isInit && !findFace)
                {
                    bgrImage = faceDetector.drawFaceToImage(bgrImage, humanFace);
                    findFace = true;
                    UpdatePersonAsync();
                    failFrameCount = 0;
                }

                return isInit;
            }            
        }

        private async void UpdatePersonAsync()
        {
            if (findFace && Person == null)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var face_data = new WebEntity.Face(Convert.ToBase64String(humanFace.face.ToJpegData()));
                try
                {
                    var response = await RestfulClient.Recognize(face_data);
                    if (response.ReturnCode == 200)
                    {
                        Person = response.Content;
                    } else if (response.ReturnCode == 404)
                    {
                        FailToRecognize = true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error on connecting server: " + ex.Message);
                    Person = null;
                }

                timer.Stop();
                TimeSpan timespan = timer.Elapsed;
            }
        }

        public void Dispose()
        {
            tracker.Dispose();
        }
    }
}
