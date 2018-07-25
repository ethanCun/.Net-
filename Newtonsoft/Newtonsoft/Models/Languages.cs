using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newtonsoft.Models
{
    public class Languages
    {
        /*
           string jsonStr = @"
                [{'Languages':['C#','Java'],'Name':'李志伟','Sex':true},
                {'Languages':['C#','C++'],'Name':'Coder2','Sex':false},
                {'Languages':['C#','C++','C','Java'],'Name':'Coder3','Sex':true}]";
        */

        public List<Language> myLanguages { get; set; } = new List<Language>();
    }

    public class Language
    {
        public List<string> languageKinds { get; set; } = new List<string>();

        public string Name { get; set; }

        public string Sex { get; set; }
    }

}