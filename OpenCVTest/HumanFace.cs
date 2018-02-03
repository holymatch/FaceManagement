using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVTest
{
    class HumanFace : IDisposable
    {
        public Image<Bgr, byte> face { get; set; }
        public Rectangle faceRectangle { get; set; }
        public Rectangle[] eyeRectangle { get; set; }

        public HumanFace(Image<Bgr, byte> face, Rectangle faceRectangle, Rectangle[] eyeRectangle)
        {
            this.face = face;
            this.faceRectangle = faceRectangle;
            this.eyeRectangle = eyeRectangle;
        }

        public HumanFace(Image<Bgr, byte> face, Rectangle faceRectangle)
        {
            this.face = face;
            this.faceRectangle = faceRectangle;
            this.eyeRectangle = new Rectangle[0];
        }

        public void Dispose()
        {
            face.Dispose();
        }
    }
}
