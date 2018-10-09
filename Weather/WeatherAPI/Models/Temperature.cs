using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class Temperature
    {
        public string format { get; set; }
        public int value { get; set; }
        public int humidity { get; set; }
    }
}