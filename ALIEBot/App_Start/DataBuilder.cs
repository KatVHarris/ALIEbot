using ALIEbot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using ALIEbot.Properties;
using System.Diagnostics;

namespace ALIEbot.App_Start
{

    /// <summary>
    /// DataBuilder: Formats JSON Data into Managable data. Builds Dictionary for easy lookup
    /// Currently only for local data, eventually link to Database
    /// </summary>
    public static class DataBuilder
    {
        public static CharacterList FullCharacterList;
        public static List<Character> HouseListCharacters;
        public static List<Character> LocationListCharacters;


        /// <summary>
        /// BuildCharacters: Builds Characters from JSON data 
        /// </summary>
        public static void BuildCharacters()
        {
            //string startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "/Models/JSONCharacters.json");
            string jsonText = Resources.CharactersJSON;

            FullCharacterList = JsonConvert.DeserializeObject<CharacterList>(jsonText);
            Debug.WriteLine("dos");
        }

        public static void BuildHouses()
        {

        }

        /// <summary>
        /// BuildHouseList: For each character add them to appropriate house list
        /// </summary>
        static void BuildHouseList()
        {

        }

        static void BuildLocations()
        {

        }

        static void BuildLocationList()
        {

        }

    }
}