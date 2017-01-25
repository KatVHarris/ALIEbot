using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEBot.Models
{
    public class DataBuilder
    {
        /// <summary>
        /// BuildCharacters: Builds Characters from JSON data 
        /// </summary>
        public static void BuildCharacters()
        {
            CharacterDictionary.BuildCharactersFromJSON();
        }
        public static void BuildLocations()
        {
            LocationDictionary.BuildLocationsFromJSON();
        }
    }
}