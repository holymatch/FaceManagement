using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;
using System.Diagnostics;
using Emgu.CV.Tracking;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using RestfulClient;

namespace OpenCVTest
{
    public partial class Form1 : Form
    {

        private VideoCapture _capture = null; //Camera
        private DataStoreAccess _dataStoreAccess = null;

        private static String _databasePath = Application.StartupPath + "\\Database\\facedb.db";
        private static String _trainerPath = Application.StartupPath + "\\..\\..\\TrainingImage";

        private static int RESIZE_IMAGE_HEIGHT = 75, RESIZE_IMAGE_WIIDTH = 75;

        MutliFaceTracker tracker;

        byte[] cropedFace;
        
        public Form1()
        {
            InitializeComponent();
            _dataStoreAccess = new DataStoreAccess(_databasePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tracker.TrackingFaces.Count > 0)
            {
                //Rectangle cropRect = new Rectangle()
                //Rectanle cropRect = tracker.TrackingFaces.First.Value.humanFace.faceRectangle;
                imageBoxCapturedImage.Image = tracker.TrackingFaces.First.Value.humanFace.face;
                //cropedFace = tracker.TrackingFaces.First.Value.humanFace.face.ToJpegData();
                cropedFace = tracker.TrackingFaces.First.Value.humanFace.face.Resize(RESIZE_IMAGE_WIIDTH, RESIZE_IMAGE_HEIGHT, Emgu.CV.CvEnum.Inter.Cubic).ToJpegData();
            }
            
            //imageBoxCapturedImage.Image = _capture.QueryFrame();

        }

        void Tracking(object sender, EventArgs e)
        {
            using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (imageFrame != null)
                {
                    //FaceDetector faceDetector = new FaceDetector();
                    //var faces = faceDetector.findHumanFace(imageFrame);
                    //if (faces.Count()>0)
                    //{
                        if (tracker == null)
                        {
                            tracker = new MutliFaceTracker();
                        }                        
                        tracker.trackFace(imageFrame);
                    //}                    
                    imgCamUser.Image = imageFrame;
                }                    
            }
                
        }

        //void Application_Idle(object sender, EventArgs e)
        //{
        //    //顯示影像到PictureBox上
        //    if (frameCount == 0)
        //    {
        //        using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
        //        {
        //            if (imageFrame != null)
        //            {
        //                var faceDetector = new FaceDetector();
        //                var faces = faceDetector.findHumanFace(imageFrame);
                        
        //                if (faces.Count > 0)
        //                {
        //                    var grayframe = imageFrame.Convert<Gray, byte>();
        //                    frameCount++;
        //                    //tracker.Init(grayframe.Mat, faces[0].faceRectangle);
        //                }
        //                /*
        //                var grayframe = imageFrame.Convert<Gray, byte>();
        //                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here

                        
                        
        //                foreach (var face in faces)
        //                {
        //                    Bitmap facetarget = new Bitmap(face.Width, face.Height);
        //                    using (Graphics g = Graphics.FromImage(facetarget))
        //                    {
        //                        g.DrawImage(grayframe.Bitmap, new Rectangle(0, 0, facetarget.Width, facetarget.Height), face, GraphicsUnit.Pixel);
        //                    }
        //                    Image<Gray, Byte> faceImage = new Image<Gray, Byte>(facetarget);
        //                    var eyes = _cascadeEyeClassifier.DetectMultiScale(faceImage, 1.3, 5, Size.Empty);

        //                    Debug.Print("Eye count : {0}", eyes.Count());
        //                    if (eyes.Count() == 2)
        //                    {
        //                        foreach (var eye in eyes)
        //                        {
        //                            imageFrame.Draw(new Rectangle(face.X + eye.X, face.Y + eye.Y, eye.Width, eye.Height), new Bgr(Color.Green), 1); //the detected face(s) is highlighted here using a box that is drawn around it/them
        //                            if (this.txtUsrename.Text.Trim() != String.Empty)
        //                            {

        //                                Bitmap target = new Bitmap(face.Width, face.Height);
        //                                using (Graphics g = Graphics.FromImage(target))
        //                                {
        //                                    g.DrawImage(grayframe.Bitmap, new Rectangle(0, 0, target.Width, target.Height), face, GraphicsUnit.Pixel);
        //                                }
        //                                //saveFace(target);
        //                            }
        //                        }
        //                        _face = face;
        //                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
        //                        frameCount++;
        //                        tracker.Init(grayframe.Mat, face);
        //                    }
        //                }
        //                */
        //            }

        //            imgCamUser.Image = imageFrame;
        //        }
        //    } else
        //    {
        //        Debug.Print("Carmer size: {0}", _capture.QueryFrame().Size);
        //        using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
        //        {
        //            // Read frame. 
        //            if (imageFrame != null)
        //            {
        //                var grayframe = imageFrame.Convert<Gray, byte>();
        //                /*
        //                try
        //                {

        //                    var result = tracker.Update(grayframe.Mat, out trackingFace);
        //                    Debug.Print("Tracking result : {0}", result.ToString());
        //                    if (!result)
        //                    {
        //                        frameCount = 0;
        //                        var faceDetector = new FaceDetector();
        //                        faceDetector.getImageWithFace(imageFrame);
        //                        imgCamUser.Image = imageFrame;
        //                        return;
        //                    }                            
        //                    imageFrame.Draw(trackingFace, new Bgr(Color.Red), 3);
        //                } catch (Exception ex)
        //                {
        //                    Debug.Print(ex.ToString());
        //                }
        //                */
                        
        //            }
        //            frameCount++;
        //            imgCamUser.Image = imageFrame;
        //            if (frameCount > 27)
        //            {
        //                frameCount = 0;
        //            }
        //        }

        //    }       

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            FaceRecognizer recognizer = new FaceRecognizer();
            MessageBox.Show(recognizer.TrainRecognizer().ToString(), "Training result", MessageBoxButtons.OK);

        }

        private void saveFace(Bitmap face)
        {
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);

            if (txtUsrename.Text.Trim() != String.Empty)
            {
                var username = txtUsrename.Text.Trim().Trim().ToLower();
                var result = dataStore.SaveFace(username, ImageToByte(face));
                //MessageBox.Show(result, "Save Result", MessageBoxButtons.OK);
                Debug.Print("Result : " + result);
            }
        }

        public static byte[] ImageToByte(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture();
            imgCamUser.Image = _capture.QueryFrame();

            FaceRecognizer recognizer = new FaceRecognizer();
            recognizer.LoadRecognizerData();
            var result = recognizer.RecognizeUser(_capture.QueryFrame().ToImage<Gray, Byte>());
            var resultMsg = "Face not recongize";
            if (result != -1)
            {
                resultMsg = _dataStoreAccess.GetUsername(Convert.ToInt32(result));
            }
            MessageBox.Show(resultMsg, "Result", MessageBoxButtons.OK);

            _capture.Dispose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            var directories = new List<String>(Directory.GetDirectories(_trainerPath).ToList());
            for (var i = 0; i < directories.Count(); i++)
            {
                DirectoryInfo d = new DirectoryInfo(directories[i]);
                FileInfo[] Files = d.GetFiles("*.jpg");
                for (var j = 0; j < Files.ToList().Count(); j++)
                {
                    //Debug.Print("File name : {0}", Files[i].FullName);
                    //Debug.Print("Dir name : {0}", d.Name);

                    Bitmap image = (Bitmap)Image.FromFile(Files[j].FullName, true);
                    FaceDetector faceDetector = new FaceDetector();
                    var humanFaces = faceDetector.findHumanFace(image);
                    if ( humanFaces.Count() == 0 )  {
                        Debug.Print("Human Faces not found : {0}", Files[j].Name);
                    } else if (humanFaces.Count() == 1)
                    {

                        Image<Gray, Byte> faceImage = new Image<Gray, Byte>(humanFaces[0].face.ToBitmap()); 
                        _dataStoreAccess.SaveFace(d.Name, (ImageToByte(faceImage.ToBitmap())));
                    }
                    /*
                    Byte[] file;

                    using (var stream = new FileStream(Files[i].FullName, FileMode.Open, FileAccess.Read))
                    {
                        
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int)stream.Length);
                        }
                    }
                    */
                    //_dataStoreAccess.SaveFace(d.Name, file);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new frmOverlapTest();
            myForm.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture();
            imgCamUser.Image = _capture.QueryFrame();
            Application.Idle += Tracking;
        }

        private async void btnCheckFace_ClickAsync(object sender, EventArgs e)
        {
            txtUsrename.Text = "";
            txtScore.Text = "";
            Stopwatch timer = Stopwatch.StartNew();
            var face_data = new WebEntity.Face(Convert.ToBase64String(cropedFace));
            try
            {
                var response = await RestfulClient.Recognize(face_data);
                if (response.ReturnCode == 200)
                {
                    txtUsrename.Text = response.Content.name;
                    txtScore.Text = response.Content.score.ToString();
                    txtErrorMessage.Text = "";
                }
                else
                {
                    txtErrorMessage.Text = response.Message;
                }
            } catch(Exception ex)
            {
                Debug.WriteLine("Error on connecting server: " + ex.Message);
                txtErrorMessage.Text = "Error on connecting server: " + ex.Message;
            }
            
            
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
        }

        private async void btnAddFace_ClickAsync(object sender, EventArgs e)
        {
            var person = new Person(txtUsrename.Text, txtDetail.Text, Convert.ToBase64String(cropedFace));

            try
            {
                txtErrorMessage.Text = "";
                var response = await RestfulClient.CreatePerson(person);
                if (response.ReturnCode == 200)
                {
                    txtErrorMessage.Text = "Success";
                } else
                {
                    txtErrorMessage.Text = response.Message;
                }

            } catch(Exception ex)
            {
                Debug.WriteLine("Error on connecting server: " + ex.Message);
                txtErrorMessage.Text = "Error on connecting server: " + ex.Message;
            }
}
    }
}
