using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulClient
{
    class Person
    {
        //public int? id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public float? score { get; set; }
        public string facedata { get; set; }

        public Person(string name, string detail, string facedata)
        {
            //this.id = null;
            this.name = name;
            this.detail = detail;
            this.facedata = facedata;
            this.score = null;
        }
    }
}
