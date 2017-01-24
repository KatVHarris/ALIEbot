using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEbot.Models
{
    public class DataBuilder
    {
        public static CharacterList FullCharacterList;
        public static List<Character> Boo;
        public static List<Character> HouseListCharacters;
        public static List<Character> LocationListCharacters;


        /// <summary>
        /// BuildCharacters: Builds Characters from JSON data 
        /// </summary>
        public static void BuildCharacters()
        {
            CharacterDictionary.BuildCharactersFromJSON();
            CharacterDictionary.AddAllCharacters();
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