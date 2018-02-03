using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulClient
{
    class Person
    {
        public long? id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public float? score { get; set; }
        public string faceData { get; set; }

        public Person(string name, string detail, string faceData)
        {
            //this.id = null;
            this.name = name;
            this.detail = detail;
            this.faceData = faceData;
            this.score = null;
        }
    }
}
