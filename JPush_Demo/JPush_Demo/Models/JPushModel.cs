using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace JPush_Demo.Models
{
    public class JPushModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Dictionary<string, object> Json { get; set; }

        public ArrayList aliases { get; set; }
    }
}