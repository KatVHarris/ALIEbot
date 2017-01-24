﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEbot.Models
{
    public class CharacterList
    {
        [JsonProperty("Characters")]
        public List<Character> FullCharacterList { get; set; }
        //public int CharacterCount { get; set; }
    }
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
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("Name")]
        public string Name { get;  set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Age")]
        public string Age { get; set; }
        [JsonProperty("LivingRelatives")]
        public string LivingRelatives { get; set; }
        [JsonProperty("Kills")]
        public string Kills { get; set; }
        [JsonProperty("Skills")]
        public string Skills { get; set; }
        [JsonProperty("Quote")]
        public string Quote { get; set; }
        [JsonProperty("DescriptionLink")]
        public string DescriptionLink { get; set; }
        [JsonProperty("ImageLink")]
        public string ImageLink { get; set; }
        [JsonProperty("Location")]
        public string Location { get; set; }
        [JsonProperty("House")]
        public House House { get; set; }
        [JsonProperty("Group")]
        public string Group { get; set; }

        // Serialize to JSON

    }
}