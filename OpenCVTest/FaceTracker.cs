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

namespace OpenCVTest
{
    class FaceTracker : IDisposable
    {

        private const string TRACKERTYPE = "MEDIANFLOW";
        private Tracker tracker;
        public bool findFace { get; set; }
        public int failFrameCount { get; set; } //The frame that can't track the face
        private bool isInit;
        public HumanFace humanFace { get; set; }
        public Person Person { get; set; }
        public bool FailToRecognize { get; set; }

        public FaceTracker(HumanFace face)
        {
            tracker = new Tracker(TRACKERTYPE);
            humanFace = face;
            findFace = false;
            isInit = false;
            failFrameCount = 0;
            FailToRecognize = false;
        }

        private FaceTracker()
        {
            tracker = new Tracker(TRACKERTYPE);
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
                                }
                                else
                                {
                                    failFrameCount = 0;
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
