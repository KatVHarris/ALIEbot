/*
 * The ComplexDialogChain Class demonstrates more of the Chian functionality going into Chained responses. 
 * The class also implements regex to identify user input. 
 * The Class does not use any of the Bot Framework Formflow Specific Functions. 
*/

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

namespace ALIEBot
{   

    public class ComplexDialogChain
    {
        
        public static readonly IDialog<string> dialog = Chain.PostToChain()
    .Select(msg => msg.Text)
    .Switch(
        new Case<string, IDialog<string>>(text =>
        {
            var regex = new Regex("^reset");
            return regex.Match(text).Success;
        }, (context, txt) =>
        {
            return Chain.From(() => new PromptDialog.PromptConfirm("Are you sure you want to reset the City of Light?",
                    "I could not process your request", 3)).ContinueWith<bool, string>(async (ctx, res) =>
                    {
                        string reply;
                        if (await res)
                        {
                            ctx.UserData.SetValue("count", 0);
                            reply = "You have reset the City of Light.";
                        }
                        else
                        {
                            reply = "The City of Light is intact.";
                        }
                        return Chain.Return(reply);
                    });
        }),
        new Case<string, IDialog<string>>(text =>
        {
            var regex = new Regex("^join");
            return regex.Match(text).Success;
        }, (context, txt) =>
        {
            return Chain.From(() => new PromptDialog.PromptConfirm("Are you prepared to take the Key into the City of Light?",
                    "I could not process your request", 3)).ContinueWith<bool, string>(async (ctx, res) =>
                    {
                        string reply;
                        if (await res)
                        {
                            ctx.UserData.SetValue("joined", true);
                            reply = "Welcome to the City of Light!";
                        }
                        else
                        {
                            reply = "You should reconsider. The City of Light will take away all pain.";
                        }
                        return Chain.Return(reply);
                    });
        }),
        new RegexCase<IDialog<string>>(new Regex("^help", RegexOptions.IgnoreCase), (context, txt) =>
        {
            return Chain.Return("I can only help you once you join the City of Light. Input the command \"join\" to join the City of Light. Once there you can input a name of specific people or places to access more information on them. There are also hidden commands which, if inputed, will provide additional information that my program cannot access by default. ");
        }),
        new RegexCase<IDialog<string>>(new Regex("core command", RegexOptions.IgnoreCase), (context, txt) =>
        {
            
            return Chain.Return("My core command is to make life better.");
        }),
        new Case<string, IDialog<string>>(text =>
        {
            var regex = new Regex("^upgrade");
            return regex.Match(text).Success;
        }, (context, txt) =>
        {
                return Chain.From(() => new PromptDialog.PromptString("What is the pass phrase?",
                        "That was incorrect", 1)).ContinueWith<string, string>(async (ctext, response) =>
                        {
                            string reply; 
                            var text = await response;
                            ctext.UserData.SetValue("upgraded", true);
                            var regex = new Regex("^ascende superius");
                            if (regex.Match(text).Success)
                            {
                                bool upgraded = true; 
                                context.UserData.SetValue("upgraded", upgraded);
                                reply = "I have merged with The Flame and have successfully upgraded. You know have access to my full database.";
                            }
                            else
                            {
                                context.UserData.SetValue("upgraded", false);
                                reply = "That was incorrect.";
                            }
                            return Chain.Return(reply);
                        });
        }),
        new DefaultCase<string, IDialog<string>>((context, txt) =>
        {
            string reply = "Tell me who you would like to know about. Or if you would like to join the City of Light."; 
            return Chain.Return(reply);
        }))
    .Unwrap()
    .PostToUser();
    }


}
