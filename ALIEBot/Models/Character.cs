using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEbot.Models
{
    /// <summary>
    /// Structure for DB pull and JSON Seralization
    /// Receive a message from a user and reply to it
    /// </summary>
    public class Character
    {
        /*
         * 
         * Name
         * TextDescription
         * Age
         * Living Relatives
         * Kills
         * Skills
         * Quote
         * ImageLink
         * DescriptionLink
         * Location
         * House
         * Group
        */

        // A few example members
        public string Name { get;  set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string LivingRelatives { get; set; }
        public int Kills { get; set; }
        public string Skills { get; set; }
        public string Quote { get; set; }
        public string ImageLink { get; set; }
        public string DescriptionLink { get; set; }
        public Location Location { get; set; }
        public House House { get; set; }
        public string Group { get; set; }

        // Serialize to JSON

    }
}