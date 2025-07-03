using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zmtapi.Models
{
    public class zmtmodel
    {
        public int id { get; set; }
        public string rname { get; set; }
        public string imgdata { get; set; }
        public string address { get; set; }
        public string delimg { get; set; }
        public string somedata { get; set; }
        public double? price { get; set; }
        public double? rating { get; set; }
        public string arrimg { get; set; }
    }
}