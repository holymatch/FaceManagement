using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVTest
{
    class MutliFaceTracker
    {
        private const int REINITBYSUCCESSFRAMECOUNT = 48;
        private const int REINITBYFAILFRAMECOUNT = 6;

        private LinkedList<FaceTracker> trackingFaces;
        private const float INTERSECTRATIO = 0.3f;
        private FaceDetector faceDetector;
        private int frameCount = 0;

        internal LinkedList<FaceTracker> TrackingFaces { get => trackingFaces; set => trackingFaces = value; }

        public MutliFaceTracker()
        {
            trackingFaces = new LinkedList<FaceTracker>();
            faceDetector = new FaceDetector();
        }

        public void trackFace(Image<Bgr,byte> bgrImage)
        {

            //var bgrImage = new Image<Bgr, byte>(new Bitmap(image));
            var trackNode = trackingFaces.First;
            while (trackNode != null)
            {
                if ((!trackNode.Value.trackFace(bgrImage) || trackNode.Value.FailToRecognize) && trackNode.Value.failFrameCount > REINITBYFAILFRAMECOUNT)
                {
                    trackNode.Value.Dispose();
                    trackingFaces.Remove(trackNode.Value);
                    Debug.Print("Face removed, total face: {0}", trackingFaces.Count());
                }
                trackNode = trackNode.Next;
            }
            List<HumanFace> faces = new List<HumanFace>();

            if (frameCount > REINITBYSUCCESSFRAMECOUNT || trackingFaces.Count() == 0)
            {
                faces = faceDetector.findHumanFace(bgrImage);
                frameCount = 0;
            }

            foreach (HumanFace face in faces)
            {
                //Debug.Print("Try to add face, total face find: {0}", faces.Count());
                addFace(face);
            }
            frameCount++;
        }

        public bool addFace(HumanFace newFace)
        {
            var result = false;
            var r1 = newFace.faceRectangle;
            float r1Size = r1.Height * r1.Width;
            bool sameFaceFind = false;
            if (trackingFaces.Count() == 0)
            {
                sameFaceFind = false;
                result = true;
            } else
            {
                var trackNode = trackingFaces.First;
                while (trackNode != null)
                {
                    var r2 = trackNode.Value.humanFace.faceRectangle;
                    float r2Size = r2.Height * r2.Width;
                    var r3 = Rectangle.Intersect(r1, r2);
                    if (!r3.IsEmpty)
                    {
                        float r3Size = r3.Height * r3.Width;
                        float ratio = r3Size / Math.Min(r1Size, r2Size);
                        if (ratio < INTERSECTRATIO)
                        {

                            Debug.Print("Face compare, Ratio: {0}",ratio);
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
                    trackNode = trackNode.Next;
                }
            }
            if (!sameFaceFind)
            {
                trackingFaces.AddLast(new FaceTracker(newFace));
                Debug.Print("New face added, total face: {0}", trackingFaces.Count());
            }
            return result;
        }
    }
}
