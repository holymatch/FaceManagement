using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FaceManagement
{
    class FaceRecognizer : IDisposable
    {

        private static String _databasePath = Application.StartupPath + "\\Database\\facedb.db";
        private static String _recognizerFilePath = Application.StartupPath + "\\facedata\\trainingdata.yml";
        private EigenFaceRecognizer _faceRecognizer = null;

        public FaceRecognizer() 
        {
            _faceRecognizer = new EigenFaceRecognizer(80, 3900);
        }

        public void Dispose()
        {
            _faceRecognizer.Dispose();
        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Read(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            _faceRecognizer.Read(_recognizerFilePath);

            var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
            Debug.Print("Face recognizer result Label:Distance {0}:{1}", result.Label,result.Distance );
            return result.Label;
        }
    }
}
