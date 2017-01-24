using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALIEbot.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Character> CharacterList {get; set;}

        public List<Character> GetCharacters()
        {
            return CharacterList;
        }
    }
}