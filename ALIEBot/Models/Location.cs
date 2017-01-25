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
        static LocationList LocationList; 

        public static void BuildLocationsFromJSON()
        {
            LocationList = new LocationList();
            string jsonText = Resources.JSONLocations;
            LocationList = JsonConvert.DeserializeObject<LocationList>(jsonText);
            AddAllLocations();
        }
        public static void AddAllLocations()
        {
            // For each Character in Character List add to Dictionary
            foreach (Location c in LocationList.FullLocationsList)
            {
                locationDictionary.Add(c.id, c);
            }

        }

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static Location GetLocation(string word)
        {
            // Try to get the result in the static Dictionary
            Location requestedLocation;
            if (locationDictionary.TryGetValue(word, out requestedLocation))
            {
                return requestedLocation;
            }
            else
            {
                return null;
            }
        }
    }


    public class LocationList
    {
        [JsonProperty("Locations")]
        public List<Location> FullLocationsList { get; set; }
        //public int CharacterCount { get; set; }
    }

    public class Location
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("ImageLink")]
        public string ImageLink { get; set; }
    }
}