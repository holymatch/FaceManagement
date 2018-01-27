using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVTest
{
    public partial class frmOverlapTest : Form
    {
        public frmOverlapTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 x1 = Convert.ToInt32(txtX1.Text);
            Int32 xa1 = x1;
            Int32 y1 = Convert.ToInt32(txtY1.Text);
            Int32 ya1 = y1;
            Int32 x2 = Convert.ToInt32(txtX2.Text);
            Int32 xb1 = x2;
            Int32 y2 = Convert.ToInt32(txtY2.Text);
            Int32 yb1 = y2;
            Int32 width1 = Convert.ToInt32(txtWidth1.Text);
            Int32 ya2 = ya1 + width1;
            Int32 hight1 = Convert.ToInt32(txtHeight1.Text);
            Int32 xa2 = xa1 + hight1;
            Int32 width2 = Convert.ToInt32(txtWidth2.Text);
            Int32 yb2 = yb1 + width2;
            Int32 hight2 = Convert.ToInt32(txtHeight2.Text);
            Int32 xb2 = yb1 + hight2;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            Size size1 = new Size(width1, hight1);
            Size size2 = new Size(width2, hight2);

            Rectangle r1 = new Rectangle(point1, size1);
            Rectangle r2 = new Rectangle(point2, size2);

            Mat img = new Mat(200, 400, DepthType.Cv8U, 3);

            Image<Bgr, byte> image = img.ToImage<Bgr, Byte>();
            image.Draw(r1, new Bgr(Color.Yellow), 1);
            image.Draw(r2, new Bgr(Color.Red), 1);

            var r3 = Rectangle.Intersect(r1, r2);
            image.Draw(r3, new Bgr(Color.White), 1);
            
            imgBG.Image = image;

            Debug.Print("R1 Size: {0}, R2 Size: {1}, R3 Size: {2}", r1.Size, r2.Size, r3.Size);

            Debug.Print("R3/R1: {0}, R3/R1: {1}", ((float)((float)(r3.Width*r3.Height)/ (float)(r1.Width*r1.Height))), ((float)((float)(r3.Width * r3.Height) / (float)(r2.Width * r2.Height))));

            //Debug.Print("xa1: {0}, xa2: {1}, ya1: {2} ya2: {3}", xa1, xa2 , ya1, ya2);
            //Debug.Print("xb1: {0}, xb2: {1}, yb1: {2} yb2: {3}", xb1, xb2, yb1, yb2);

            float iLeft = Math.Max(xa1, xb1);
            float iRight = Math.Min(xa2, xb2);
            float iTop = Math.Max(ya1, yb1);
            float iBottom = Math.Min(ya2, yb2);

            //Debug.Print("iLeft: {0}, iRight: {1}, iTop: {2}, iBottom: {3}", iLeft, iRight, iTop, iBottom);

            float si = Math.Max(0, iRight - iLeft) * Math.Max(0, iBottom - iTop);
            //Debug.Print("si: {0}", si);

            float sa = (xa2 - xa1) * (ya2 - ya1);
            float sb = (xb2 - xb1) * (yb2 - yb1);

            float su = sa + sb - si;

            float f = si / su;

            Debug.Print("sa: {0}, sb{1}, su: {2}, ratio: {3}", sa, sb, su, f);

            lblOverlap.Text = (Math.Max(0, Math.Min(xa2, xb2) - Math.Max(xa1, xb2)) * Math.Max(0, Math.Min(ya2, yb2) - Math.Max(ya1, yb1))).ToString();
        }
    }
}
