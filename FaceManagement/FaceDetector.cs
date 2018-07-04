using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FaceManagement
{
    class FaceDetector
    {
        private CascadeClassifier _cascadeClassifier;
        private CascadeClassifier _cascadeEyeClassifier;

        private static String _haarcascade_frontalface = Application.StartupPath + "\\facedata\\haarcascade_frontalface_alt.xml";
        private static String _haarcascade_eye = Application.StartupPath + "\\facedata\\haarcascade_eye_tree_eyeglasses.xml";

        private static String _trainerPath = Application.StartupPath + "\\..\\..\\TrainingImage";

        public FaceDetector()
        {
            _cascadeClassifier = new CascadeClassifier(_haarcascade_frontalface);
            _cascadeEyeClassifier = new CascadeClassifier(_haarcascade_eye);
        }

        public Rectangle[] findFace(Image<Gray, byte> grayImage)
        {
            lock (grayImage)
            {
                return _cascadeClassifier.DetectMultiScale(grayImage, 1.5, 3, new Size(80, 80));
            }
            
        }

        public Rectangle[] findFace(Image<Bgr, byte> BgrImage)
        {
            lock(BgrImage)
            {
                return findFace(BgrImage.Convert<Gray, byte>());
            }            
        }

        public Rectangle[] findEye(Image<Gray, byte> grayImage)
        {
            lock(grayImage)
            {
                return _cascadeEyeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty);
            }            
        }

        public Rectangle[] findEye(Image<Bgr, byte> BgrImage)
        {
            lock(BgrImage)
            {
                return findEye(BgrImage.Convert<Gray, byte>());
            }
        }

        public Image<Bgr, byte> getFace()
        {
            return null;
        }

        public Image<Bgr, byte> cropFaceInRectangle(Image<Bgr, byte> bgrImage, Rectangle face)
        {
            using (Bitmap tragetFace = new Bitmap(face.Width, face.Height))
            {
                using (Graphics g = Graphics.FromImage(tragetFace))
                {
                    g.DrawImage(bgrImage.Bitmap, new Rectangle(0, 0, tragetFace.Width, tragetFace.Height), face, GraphicsUnit.Pixel);
                }
                return new Image<Bgr, byte>(tragetFace);
            }            
        }

        public List<HumanFace> findHumanFace(Image image)
        {
            return findHumanFace(new Image<Bgr, byte>(new Bitmap(image)));
        }

        public List<HumanFace> findHumanFaceWithEye(Image<Bgr, byte> bgrImage)
        {
            var humanFaces = new List<HumanFace>();
            var faces = findFace(bgrImage);
            for (var i = 0; i < faces.Count(); i++)
            {
                var faecImage = cropFaceInRectangle(bgrImage, faces[i]);
                var eyes = findEye(faecImage);
                if (eyes.Count() == 2)
                {
                    humanFaces.Add(new HumanFace(faecImage, faces[i], eyes));
                }
            }
            return humanFaces;
        }

        public List<HumanFace> findHumanFace(Image<Bgr, byte> bgrImage)
        {
            var humanFaces = new List<HumanFace>();
            var faces = findFace(bgrImage);
            for (var i = 0; i < faces.Count(); i++)
            {
                using (var faecImage = cropFaceInRectangle(bgrImage, faces[i]))
                {
                    humanFaces.Add(new HumanFace(faecImage.Clone(), faces[i]));
                }                
            }
            return humanFaces;
        }

        public bool getImageWithFace(Image image)
        {
            using(var bgrImage = new Image<Bgr, byte>(new Bitmap(image)))
            {
                var result = getImageWithFace(bgrImage);
                if (result)
                {
                    image = bgrImage.Bitmap;
                }
                return result;
            }
        }

        public bool getImageWithFace(Image<Bgr, byte> bgrImage)
        {
            var humanFaces = findHumanFace(bgrImage);
            var result = false;
            if (humanFaces.Count() > 0)
            {
                result = true;
                drawFaceToImage(bgrImage, humanFaces);
            }
            return result;
        }

        public Image<Bgr, byte> drawFaceToImage(Image<Bgr, byte> bgrImage, List<HumanFace> humanFaces)
        {
            foreach(HumanFace humanFace in humanFaces)
            {
                drawFaceToImage(bgrImage, humanFace);
            }
            return bgrImage;
        }

        internal Image<Bgr, byte> drawFaceToImage(Image<Bgr, byte> bgrImage, HumanFace humanFace)
        {
            lock (bgrImage)
            {
                bgrImage.Draw(humanFace.faceRectangle, new Bgr(Color.BurlyWood), 3);
                for (var i = 0; i < humanFace.eyeRectangle.Count(); i++)
                {

                    bgrImage.Draw(new Rectangle(humanFace.faceRectangle.X + humanFace.eyeRectangle[i].X, humanFace.faceRectangle.Y + humanFace.eyeRectangle[i].Y, humanFace.eyeRectangle[i].Width, humanFace.eyeRectangle[i].Height), new Bgr(Color.Green), 1);
                }
                return bgrImage;
            }            
        }
    }
}
