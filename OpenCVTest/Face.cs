using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEntity
{
    public class Face
    {

        public Face(string faceData, string identify)
        {
            this.FaceData = faceData;
            this.Identify = identify;
        }

        public Face(string faceData)
        {
            this.FaceData = faceData;
        }

        public Face()
        {
            
        }

        public string FaceData { get; set; }
        public string Identify { get; set; }
    }
}
