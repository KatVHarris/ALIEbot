using ALIEBot.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEBot.Models
{
    public static class LocationDictionary
    {
        public static Dictionary<string, Location> locationDictionary = new Dictionary<string, Location>();
        static List<Location> LocationList; 

        public static void BuildLocationsFromJSON()
        {
            LocationList = new List<Location>();
            string jsonText = Resources.JSONLocations;
            LocationList = JsonConvert.DeserializeObject<List<Location>>(jsonText);
        }
    }

    public class Location
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}