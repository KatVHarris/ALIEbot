using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEbot.Models
{
    public class House
    {
        public string HouseName { get; set; }
        public string HouseDescription { get; set; }
        public List<Character> HouseList { get; set; }
    }
}