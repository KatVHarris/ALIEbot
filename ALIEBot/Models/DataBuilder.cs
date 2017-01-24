using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ALIEbot.Models
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

        /*
        public static async void BuildCharacters()
        {
            bool builtDB = await Task.Run(() => CharacterDictionary.BuildCharactersFromJSON());
        }
        */
    }
}