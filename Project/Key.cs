using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class KeyResult
    {
        public string token { get; set; }
        public string key { get; set; }
        public string ts { get; set; }
    }

    public class Key
    {
        public string status { get; set; }
        public string message { get; set; }
        public KeyResult result { get; set; }
    }
}
