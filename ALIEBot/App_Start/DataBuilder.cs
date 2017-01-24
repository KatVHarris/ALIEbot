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
    public class DataBuilder
    {
        public CharacterList FullCharacterList;
        public  List<Character> Boo;
        public  List<Character> HouseListCharacters;
        public  List<Character> LocationListCharacters;


        /// <summary>
        /// BuildCharacters: Builds Characters from JSON data 
        /// </summary>
        public  void BuildCharacters()
        {
            FullCharacterList = new CharacterList();
            CharacterDictionary.BuildCharactersFromJSON(FullCharacterList);
        }

        public  void BuildHouses()
        {

        }

        /// <summary>
        /// BuildHouseList: For each character add them to appropriate house list
        /// </summary>
         void BuildHouseList()
        {

        }

         void BuildLocations()
        {

        }

         void BuildLocationList()
        {

        }

    }
}