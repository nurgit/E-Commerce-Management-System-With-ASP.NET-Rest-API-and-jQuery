using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Rest__API.Models
{
    public class Link
    {
        public String Url { get; set; }
        public String Method { get; set; }
        public String Relation { get; set; }
    }
}