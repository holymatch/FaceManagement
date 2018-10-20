﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Diagnostics;
using RestfulClient;
using System.Net;

namespace FaceManagement
{
    public partial class frmMain : Form
    {
        private TcpNetworkClientManager tcpNetworkClientManager;

        private VideoCapture _capture = null; //Camera

        private static String _databasePath = Application.StartupPath + "\\Database\\facedb.db";
        private static String _trainerPath = Application.StartupPath + "\\..\\..\\TrainingImage";

        private static int RESIZE_IMAGE_HEIGHT = 75, RESIZE_IMAGE_WIIDTH = 75;

        private Dictionary<String, Person> people = new Dictionary<string, Person>();
        private Person selectedPerson = null;
        private CaptureImageType captureImageType;

        public String FaceInformationServerURL;

        enum CaptureImageType
        {
            None,
            NewPerson,
            NewPersonCaptured,
            CurrentPerson,
            UpdatePerson,
            UpdatePersonCaptured
        }

        enum FlowAction
        {
            StartPreview,
            CaptureFace,
            SelectFace,
            Cancel,
            Save,
            Remove,
            List
        }

        private MutliFaceTracker tracker;

        private byte[] cropedFace;
        
        public frmMain()
        {
            InitializeComponent();
            UpdateBtnStatus(CaptureImageType.None);
        }

        private void BtnCaptureFace_Click(object sender, EventArgs e)
        {
            if (tracker.TrackingFaces.Count > 0)
            {
                //Rectangle cropRect = new Rectangle()
                //Rectanle cropRect = tracker.TrackingFaces.First.Value.humanFace.faceRectangle;
                ImageBoxCapturedImage.Image = tracker.TrackingFaces.First.Value.humanFace.face;
                //cropedFace = tracker.TrackingFaces.First.Value.humanFace.face.ToJpegData();

                var imageList = new ImageList
                {
                    ImageSize = new Size(72, 72),
                    ColorDepth = ColorDepth.Depth32Bit
                };
                LvFaceList.Clear();
                int i = 0;
                LvFaceList.LargeImageList = imageList;
                foreach (FaceTracker tracker in tracker.TrackingFaces)
                {
                    imageList.Images.Add(i.ToString(), tracker.humanFace.face.Bitmap);
                    LvFaceList.Items.Add(i.ToString(), i.ToString());
                    i++;
                }
                UpdateFlow(FlowAction.CaptureFace);
                //cropedFace = tracker.TrackingFaces.First.Value.humanFace.face.Resize(RESIZE_IMAGE_WIIDTH, RESIZE_IMAGE_HEIGHT, Emgu.CV.CvEnum.Inter.Cubic).ToJpegData();

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
                        lock (imageFrame)
                        {
                            tracker.trackFace(imageFrame);
                            ImgCamUser.Image = imageFrame;
                        }
                        
                    //}
                    
                }                    
            }
                
        }


        private async void BtnDeletePerson_Click(object sender, EventArgs e)
        {
            var response = await RestfulClient.RemovePerson(selectedPerson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                TxtErrorMessage.Text = "Remove success.";

            } else
            {
                TxtErrorMessage.Text = "Unable to remove person.";
            }

            UpdateFlow(FlowAction.Remove);
        }

        private void SaveFace(Bitmap face)
        {
            
            if (txtUsrename.Text.Trim() != String.Empty)
            {
                var username = txtUsrename.Text.Trim().Trim().ToLower();
                //MessageBox.Show(result, "Save Result", MessageBoxButtons.OK);
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
            ImgCamUser.Image = _capture.QueryFrame();

            FaceRecognizer recognizer = new FaceRecognizer();
            recognizer.LoadRecognizerData();
            var result = recognizer.RecognizeUser(_capture.QueryFrame().ToImage<Gray, Byte>());
            var resultMsg = "Face not recongize";
            if (result != -1)
            {
                
            }
            MessageBox.Show(resultMsg, "Result", MessageBoxButtons.OK);

            _capture.Dispose();

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture();
            ImgCamUser.Image = _capture.QueryFrame();
            UpdateFlow(FlowAction.StartPreview);
            Application.Idle += Tracking;
        }

        private void StopPreview()
        {
            Application.Idle -= Tracking;
            if (_capture != null && _capture.IsOpened)
            {
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
            }
            if (ImgCamUser.Image != null)
            {
                ImgCamUser.Image.Dispose();
                ImgCamUser.Image = null;
            }            
        }

        private async void BtnCheckFace_ClickAsync(object sender, EventArgs e)
        {
            txtUsrename.Text = "";
            txtDetail.Text = "";
            txtScore.Text = "";
            Stopwatch timer = Stopwatch.StartNew();
            var face_data = new WebEntity.Face(Convert.ToBase64String(cropedFace));
            try
            {
                var response = await RestfulClient.Recognize(face_data);
                if (response.ReturnCode == 200)
                {
                    txtUsrename.Text = response.Content.Name;
                    txtScore.Text = response.Content.Face.Score.ToString();
                    txtDetail.Text = response.Content.Detail;
                    TxtErrorMessage.Text = response.Message;
                }
                else
                {
                    TxtErrorMessage.Text = response.Message;
                }
            } catch(Exception ex)
            {
                Debug.WriteLine("Error on connecting server: " + ex.Message);
                TxtErrorMessage.Text = "Error on connecting server: " + ex.Message;
            }
            
            
            timer.Stop();
            TimeSpan timespan = timer.Elapsed;

            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));
        }

        private void BtnListPeople_Click(object sender, EventArgs e)
        {
            ListFaceFromServer();
        }

        private async void BtnAddFace_ClickAsync(object sender, EventArgs e)
        {
            switch (captureImageType)
            {
                case CaptureImageType.NewPerson:
                case CaptureImageType.NewPersonCaptured:
                    {
                        if (cropedFace != null)
                        {
                            try
                            {
                                var person = new Person(txtUsrename.Text, txtDetail.Text, new WebEntity.Face(Convert.ToBase64String(cropedFace)));

                                TxtErrorMessage.Text = "";
                                var response = await RestfulClient.CreatePerson(person);
                                if (response.ReturnCode == 200)
                                {
                                    TxtErrorMessage.Text = "Success";
                                }
                                else
                                {
                                    TxtErrorMessage.Text = response.Message;
                                    return;
                                }
                            } catch (Exception ex)
                            {
                                TxtErrorMessage.Text = ex.Message;
                                return;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Please capture face first.", "No face found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }                    
                    break;
                case CaptureImageType.CurrentPerson:
                case CaptureImageType.UpdatePerson:
                case CaptureImageType.UpdatePersonCaptured:
                    {
                        if (selectedPerson != null)
                        {
                            selectedPerson.Name = txtUsrename.Text;
                            selectedPerson.Detail = txtDetail.Text;
                            if (cropedFace != null)
                            {
                                selectedPerson.Face.FaceData = Convert.ToBase64String(cropedFace);
                            }
                        }

                        TxtErrorMessage.Text = "";
                        var response = await RestfulClient.UpdatePerson(selectedPerson);
                        if (response.ReturnCode == 200)
                        {
                            TxtErrorMessage.Text = "Success";
                        }
                        else
                        {
                            TxtErrorMessage.Text = response.Message;
                            return;
                        }
                    }
                    break;
            }
            

            UpdateFlow(FlowAction.Save);
        }

        private void LvFaceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (captureImageType)
            {
                case CaptureImageType.NewPersonCaptured:
                    if (LvFaceList.SelectedItems.Count > 0)
                    {
                        var imageIndex = LvFaceList.LargeImageList.Images.IndexOfKey(LvFaceList.SelectedItems[0].ImageKey);
                        if (imageIndex > -1 && imageIndex < LvFaceList.LargeImageList.Images.Count)
                        {
                            using (Bitmap bmpImage = new Bitmap(LvFaceList.LargeImageList.Images[imageIndex]))
                            {
                                ImageBoxCapturedImage.Image = new Image<Bgr, Byte>(bmpImage);
                                cropedFace = tracker.TrackingFaces.ElementAt(imageIndex).humanFace.face.Resize(RESIZE_IMAGE_WIIDTH, RESIZE_IMAGE_HEIGHT, Emgu.CV.CvEnum.Inter.Cubic).ToJpegData();
                            }
                        }
                    } else
                    {
                        if (ImageBoxCapturedImage.Image != null)
                        {
                            ImageBoxCapturedImage.Image.Dispose();
                            ImageBoxCapturedImage.Image = null;
                            cropedFace = null;
                        }
                    }
                    break;
                case CaptureImageType.None:
                case CaptureImageType.CurrentPerson:
                    if (LvFaceList.SelectedItems.Count > 0)
                    {

                        selectedPerson = people[LvFaceList.SelectedItems[0].ImageKey];
                        txtUsrename.Text = selectedPerson.Name;
                        txtDetail.Text = selectedPerson.Detail;
                        using (var image = new Bitmap(Base64ToImage(selectedPerson.Face.FaceData)))
                        {
                            ImageBoxCapturedImage.Image = new Image<Bgr, Byte>(image);
                        }                        
                        /*
                        var imageIndex = lvFaceList.LargeImageList.Images.IndexOfKey(lvFaceList.SelectedItems[0].ImageKey);
                        if (imageIndex > -1 && imageIndex < lvFaceList.LargeImageList.Images.Count)
                        {
                            if (people[imageIndex].Face.Identify.ToString() == lvFaceList.SelectedItems[0].ImageKey)
                            {
                                txtUsrename.Text = people[imageIndex].Name;
                                txtDetail.Text = people[imageIndex].Detail;
                            }
                            using (Bitmap bmpImage = new Bitmap(lvFaceList.LargeImageList.Images[imageIndex]))
                            {
                                imageBoxCapturedImage.Image = new Image<Bgr, Byte>(bmpImage);
                            }
                        }*/
                    } else
                    {
                        selectedPerson = null;
                        txtDetail.Text = "";
                        txtUsrename.Text = "";
                        txtScore.Text = "";
                        if (ImageBoxCapturedImage.Image != null)
                        {
                            ImageBoxCapturedImage.Image.Dispose();
                            ImageBoxCapturedImage.Image = null;
                            cropedFace = null;
                        }
                    }
                    break;
                case CaptureImageType.UpdatePerson:                        
                    break;
                case CaptureImageType.UpdatePersonCaptured:
                    break;
            }
           
            UpdateFlow(FlowAction.SelectFace);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            UpdateFlow(FlowAction.Cancel);
        }

        private async void ListFaceFromServer()
        {
            try
            {
                TxtErrorMessage.Text = "";
                var response = await RestfulClient.ListPeople();
                if (response.ReturnCode == 200)
                {
                    var l_people = response.Content;
                    var imageList = new ImageList
                    {
                        ImageSize = new Size(72, 72),
                        ColorDepth = ColorDepth.Depth32Bit
                    };
                    LvFaceList.Clear();
                    people.Clear();
                    foreach (Person person in l_people)
                    {
                        if (person.Face != null && person.Face.FaceData != null)
                        {
                            people.Add(person.Face.Identify.ToString(), person);
                            imageList.Images.Add(person.Face.Identify.ToString(), Base64ToImage(person.Face.FaceData));
                            LvFaceList.LargeImageList = imageList;
                            LvFaceList.Items.Add(person.Name, person.Face.Identify.ToString());
                        }
                    }
                    LvFaceList.LargeImageList = imageList;
                    TxtErrorMessage.Text = "Success";
                }
                else
                {
                    TxtErrorMessage.Text = response.Message;
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error on connecting server: " + ex.Message);
                Debug.WriteLine(ex.StackTrace);
                TxtErrorMessage.Text = "Error on connecting server: " + ex.Message;
            }
        }

        private void UpdateFlow(FlowAction action)
        {
            switch (captureImageType)
            {
                case CaptureImageType.None:
                    switch (action)
                    {
                        case FlowAction.StartPreview:
                            UpdateBtnStatus(CaptureImageType.NewPerson);
                            break;
                        case FlowAction.SelectFace:
                            UpdateBtnStatus(CaptureImageType.CurrentPerson);
                            break;
                        case FlowAction.List:
                            break;
                        case FlowAction.Remove:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
                case CaptureImageType.NewPerson:
                    switch (action)
                    {
                        case FlowAction.SelectFace:
                        case FlowAction.CaptureFace:
                            UpdateBtnStatus(CaptureImageType.NewPersonCaptured);
                            break;
                        case FlowAction.Cancel:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
                case CaptureImageType.NewPersonCaptured:
                    switch (action)
                    {
                        case FlowAction.SelectFace:
                            UpdateSaveBtn();
                            UpdateCheckImageBtn();
                            break;
                        case FlowAction.Cancel:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                        case FlowAction.Save:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
                case CaptureImageType.CurrentPerson:
                    switch (action)
                    {
                        case FlowAction.StartPreview:
                            UpdateBtnStatus(CaptureImageType.UpdatePerson);
                            break;
                        case FlowAction.SelectFace:
                            UpdateSaveBtn();
                            UpdateCheckImageBtn();
                            break;
                        case FlowAction.Cancel:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                        case FlowAction.Save:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                        case FlowAction.Remove:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
                case CaptureImageType.UpdatePerson:
                    switch (action)
                    {
                        case FlowAction.CaptureFace:
                        case FlowAction.SelectFace:
                            UpdateBtnStatus(CaptureImageType.UpdatePersonCaptured);
                            break;
                        case FlowAction.Cancel:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                        case FlowAction.Save:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
                case CaptureImageType.UpdatePersonCaptured:
                    switch (action)
                    {
                        case FlowAction.CaptureFace:
                        case FlowAction.SelectFace:
                            UpdateCheckImageBtn();
                            UpdateSaveBtn();
                            break;
                        case FlowAction.Cancel:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                        case FlowAction.Save:
                            UpdateBtnStatus(CaptureImageType.None);
                            break;
                    }
                    break;
            }
        }

        private void UpdateCheckImageBtn()
        {
            if (cropedFace != null)
            {
                BtnCheckFace.Enabled = true;
            } else
            {
                BtnCheckFace.Enabled = false;
            }
        }

        private void UpdateSaveBtn()
        {
            if (cropedFace != null || (captureImageType == CaptureImageType.CurrentPerson && LvFaceList.SelectedItems.Count>0))
            {
                BtnSaveFace.Enabled = true;
            }
            else
            {
                BtnSaveFace.Enabled = false;
            }
        }

        private void UpdateDeleteBtn()
        {
            if ((captureImageType == CaptureImageType.None || captureImageType == CaptureImageType.CurrentPerson ) && LvFaceList.SelectedItems.Count > 0)
            {
                BtnDeletePerson.Enabled = true;
            }
            else
            {
                BtnDeletePerson.Enabled = false;
            }
        }

        private void UpdateBtnStatus(CaptureImageType newStatus)
        {
            captureImageType = newStatus;
            switch (captureImageType)
            {
                case CaptureImageType.None:
                    StopPreview();
                    txtDetail.Text = "";
                    txtScore.Text = "";
                    txtUsrename.Text = "";
                    LvFaceList.Clear();
                    LvFaceList.Enabled = true;
                    ImageBoxCapturedImage.Image = null;
                    BtnCancel.Enabled = false;
                    BtnStartPreview.Enabled = true;
                    BtnStartPreview.Text = "New Person";
                    BtnSaveFace.Enabled = false;
                    BtnCheckFace.Enabled = false;
                    BtnListPeople.Enabled = true;
                    BtnCaptureFace.Enabled = false;
                    if (tracker != null)
                    {
                        tracker.Dispose();
                        tracker.TrackingFaces.Clear();
                    }
                    if (people != null)
                    {
                        people.Clear();
                    }
                    selectedPerson = null;
                    //ListFaceFromServer();
                    UpdateDeleteBtn();
                    break;
                case CaptureImageType.NewPerson:
                    LvFaceList.Clear();
                    LvFaceList.Enabled = false;
                    BtnCancel.Enabled = true;
                    BtnStartPreview.Enabled = false;
                    BtnSaveFace.Enabled = false;
                    BtnCheckFace.Enabled = false;
                    BtnListPeople.Enabled = false;
                    BtnCaptureFace.Enabled = true;
                    UpdateDeleteBtn();
                    break;
                case CaptureImageType.CurrentPerson:
                    BtnCancel.Enabled = true;
                    BtnStartPreview.Enabled = true;
                    BtnStartPreview.Text = "Start Preview";
                    UpdateSaveBtn();
                    BtnCheckFace.Enabled = false;
                    BtnListPeople.Enabled = false;
                    BtnCaptureFace.Enabled = false;
                    UpdateDeleteBtn();
                    break;
                case CaptureImageType.UpdatePerson:
                    LvFaceList.Clear();
                    LvFaceList.Enabled = false;
                    BtnCancel.Enabled = true;
                    BtnStartPreview.Enabled = false;
                    BtnSaveFace.Enabled = false;
                    BtnCheckFace.Enabled = false;
                    BtnListPeople.Enabled = false;
                    BtnCaptureFace.Enabled = true;
                    UpdateDeleteBtn();
                    break;
                case CaptureImageType.NewPersonCaptured:
                    LvFaceList.Enabled = true;
                    LvFaceList.Items[0].Selected = true;
                    LvFaceList.Items[0].Checked = true;
                    BtnCancel.Enabled = true;
                    BtnStartPreview.Enabled = false;
                    UpdateSaveBtn();
                    UpdateCheckImageBtn();
                    BtnListPeople.Enabled = false;
                    BtnCaptureFace.Enabled = true;
                    UpdateDeleteBtn();
                    break;
                case CaptureImageType.UpdatePersonCaptured:
                    LvFaceList.Enabled = true;
                    LvFaceList.Items[0].Selected = true;
                    LvFaceList.Items[0].Checked = true;
                    BtnCancel.Enabled = true;
                    BtnStartPreview.Enabled = false;
                    UpdateSaveBtn();
                    UpdateCheckImageBtn();
                    BtnListPeople.Enabled = false;
                    BtnCaptureFace.Enabled = true;
                    UpdateDeleteBtn();
                    break;
            }
            TxtErrorMessage.Text = captureImageType.ToString();
        }

        private void BtnImportImage_Click(object sender, EventArgs e)
        {
            var importFace = new ImportFace();
            importFace.Show();
        }

        private void txtServerURL_Leave(object sender, EventArgs e)
        {
            try
            {
                Debug.Write(txtServerURL.Text);
                label5.ForeColor = Color.Black;
                if (txtServerURL.Text == "")
                {
                    RestfulClient.client.BaseAddress = null;
                }
                else
                {
                    try
                    {
                        updateStatusAsync();
                        Properties.Settings.Default["hosts"] = txtServerURL.Text;
                        Properties.Settings.Default.Save();
                    } catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                    
                }
                
            } catch (Exception ex)
            {
                MessageBox.Show("URL is incorrect please correct it.", "URL in correct", MessageBoxButtons.OK);
                txtServerURL.Focus();
                Debug.Write(ex);
            }            
        }

        // Load Properties and test connection
        private async void frmMain_LoadAsync(object sender, EventArgs e)
        {

            // Testing HoloLens IP
            try
            {
                txtHoloLensIP.Text = Properties.Settings.Default.HoloLensIP;
                // TODO test and get HoloLens FaceInformation Server IP config
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                label6.ForeColor = Color.Red;
            }

            // Testing FaceInformationServer IP
            try
            {
                txtServerURL.Text = Properties.Settings.Default.hosts;
                var result = await RestfulClient.setBaseAddressAsync(txtServerURL.Text);
                updateStatusAsync();
            } catch (Exception ex)
            {
                Debug.Write(ex);
                label5.ForeColor = Color.Red;
            }
        }

        private async void updateStatusAsync()
        {
            try
            {
                var result = await RestfulClient.setBaseAddressAsync(txtServerURL.Text);
                if (result)
                {
                    label5.ForeColor = Color.Green;
                }
                else
                {
                    label5.ForeColor = Color.Red;
                }
            } catch (Exception ex)
            {
                Debug.Write(ex);
                label5.ForeColor = Color.Red;
            }
            
        }

        private void BtnSetHoloLensIP_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HoloLensIP = txtHoloLensIP.Text;
            Properties.Settings.Default.Save();
            tcpNetworkClientManager = new TcpNetworkClientManager(Properties.Settings.Default.HoloLensIP, Properties.Settings.Default.HoloLensPort);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String IP = Properties.Settings.Default.hosts.Substring(0, Math.Max(Properties.Settings.Default.hosts.IndexOf(':'), 0));
            tcpNetworkClientManager.SendMessage(IP);
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            tcpNetworkClientManager.SendMessage("exit");
        }

        private void tcpConnectionChecker_Tick(object sender, EventArgs e)
        {
            if (tcpNetworkClientManager != null && tcpNetworkClientManager.IsConnected())
            {
                label6.ForeColor = Color.Green;
                if (tcpNetworkClientManager.FaceInformationServerInHoloLensIP != null )
                {
                    txtIpOnHoloLens.Text = tcpNetworkClientManager.FaceInformationServerInHoloLensIP;
                } else
                {
                    txtIpOnHoloLens.Text = "";
                }
            } else
            {
                label6.ForeColor = Color.Red;
                txtIpOnHoloLens.Text = "";
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
