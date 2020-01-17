using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMap.Models
{
    public class Formulist
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string number { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string lgt { get; set; }
        public string foto { get; set; }
    }
}