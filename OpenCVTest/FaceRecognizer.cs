using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenCVTest
{
    class FaceRecognizer
    {

        private static String _databasePath = Application.StartupPath + "\\Database\\facedb.db";
        private static String _recognizerFilePath = Application.StartupPath + "\\facedata\\trainingdata.yml";
        private DataStoreAccess _dataStoreAccess = null;
        private EigenFaceRecognizer _faceRecognizer = null;

        public FaceRecognizer() 
        {
            _dataStoreAccess = new DataStoreAccess(_databasePath);
            _faceRecognizer = new EigenFaceRecognizer(80, 3900);
        }


        public bool TrainRecognizer()
        {
            var allFaces = _dataStoreAccess.CallFaces("ALL_USERS");
            if (allFaces != null)
            {
                var faceImages = new Image<Gray, byte>[allFaces.Count];
                var faceLabels = new int[allFaces.Count];
                for (int i = 0; i < allFaces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(allFaces[i].Image, 0, allFaces[i].Image.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                    faceLabels[i] = allFaces[i].UserId;
                    Debug.Print("Userid : {0}", allFaces[i].UserId);
                }
                _faceRecognizer.Train(faceImages, faceLabels);
                _faceRecognizer.Save(_recognizerFilePath);
            }
            return true;

        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Load(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Load(_recognizerFilePath);

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            Debug.Print("Face recognizer result Label:Distance {0}:{1}", result.Label,result.Distance );
            return result.Label;
        }
    }
}
