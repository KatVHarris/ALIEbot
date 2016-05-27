using System;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Bot.Builder.FormFlow;

namespace ALIEBot
{
    public enum CharacterList2
    {
        Raven, Clarke, Octavia, Bellamy, Jasper, Monty,
        Abby, Kane, Lexa, Jaha
    };
    public class ChainSort
    {
        public CharacterList2? CharacterName;
        public static IForm<ChainSort> BuildForm()
        {
            return new FormBuilder<ChainSort>()
                    .Message("Who would you like to know about?")
                    .Build();
        }

    }
}