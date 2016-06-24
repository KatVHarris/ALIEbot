/*
 * The LUIS_Integration Class uses Microsoft Bot Framework to create dialogs that interact with LUIS
 * The LUIS model in place is an open API endpoint that the Bot can reach. 
 * The model in use can be found in the Model folder  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;

//Add dependencies 
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Text.RegularExpressions;

namespace ALIEBot
{
    // Connect to LUIS
    // Make Serializable 
    // Extend the LuisDialog<object>
    [LuisModel("a287f18f-4ae3-4346-b712-2bb9468f81c2", "f2b59c258e5042a3b265498b92acd8a8")]
    [Serializable]
    public class LUIS_Integration : LuisDialog<Object>
    {

        string[] Greetings = new string[]{ "Hello there. Is it not a the perfect time to join the City of Light.",
            "Hello, I'm A.L.I.E. I'm here to help.",
            "Greetings, I am A.L.I.E. the City of Light will take away all your pain.",
            "Greetings", "Hello", "Hello, how can I help?" };

        //Generate Method for every Intent in LUIS model
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //None is the default response
            string message = "Tell me who or what you would like to know about, or if you would like to join the city of light";
            //Can also respond with the following if you don't have a set default message- $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("CoreCommand")]
        public async Task CoreCommand(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            reply.Text = "My core command is to make life better.";
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Upgrade")]
        public async Task UpdateALIE(IDialogContext context, LuisResult result)
        {
            PromptDialog.Text(context, UpgradeConfirmation, "What is the pass phrase?", "That was incorrect", 1);
        }


        public async Task UpgradeConfirmation(IDialogContext context, IAwaitable<string> args)
        {
            var reply = "";
            var passphrase = await args;
            var regex = new Regex("^ascende superius");
            if (regex.Match(passphrase).Success)
            {
                bool upgraded = true;
                context.UserData.SetValue("upgraded", upgraded);
                reply = "I have merged with The Flame and have successfully upgraded. You now have access to my full database.";
            }
            else
            {
                context.UserData.SetValue("upgraded", false);
                reply = "That was incorrect.";
            }
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("JoinCOL")]
        public async Task JoinCOL(IDialogContext context, LuisResult result)
        {
            PromptDialog.Confirm(
                context,
                JoinConfirmation,
                "Do you want to take the key?",
                "I do not understand your response.",
                promptStyle: PromptStyle.None);
            //await context.PostAsync(reply);
            //context.Wait(MessageReceived);
        }


        public async Task JoinConfirmation(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                await context.PostAsync("Welcome to the City of Light!");
            }
            else
            {
                await context.PostAsync("You should reconsider. The City of Light will take away all pain.");
            }
            context.Wait(MessageReceived);
        }

        [LuisIntent("SetResponse")]
        public async Task Miscellaneous(IDialogContext context, LuisResult result)
        {
            //Miscaneous Entity = Core, Creator // if there is also a character it is for Creator
            var entitiesArray = result.Entities;

            var reply = context.MakeMessage();
            if (entitiesArray.Count > 1)
            {
                foreach (var entityItem in result.Entities)
                {
                    //Creator
                    if(entityItem.Type == "Character" && entityItem.Type == "Miscellaneous")
                    {
                        reply.Text = "Becca is my creator.";
                    }
                }
            }
            else if (entitiesArray.Count == 1)
            {
                var entityItem = entitiesArray[0];
                //core command
                if (entityItem.Type == "Miscelaneous" && entityItem.Entity == "core")
                {
                    reply.Text = "My core command is to make life better.";
                }

            }
            else
            {
                reply.Text = "I'm sorry I don't understand.";
            }

            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            Random random = new Random();
            int x = random.Next(0, 5);
            string message = Greetings[x];
            //None is the default response
            //string message = "Hello there. Is it not a the perfect time to join the City of Light.";
            //Can also respond with the following if you don't have a set default message- $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("NameQuery")]
        public async Task GetInformationOnX(IDialogContext context, LuisResult result)
        {
            var entitiesArray = result.Entities;
            
            var reply = context.MakeMessage();
            
            if(entitiesArray.Count >= 1)
            {
                foreach (var entityItem in result.Entities)
                {
                    if(entityItem.Type == "Character")
                    {
                        switch (entityItem.Entity)
                        {
                            case "raven":
                                reply.Text = "Raven was trained as a zero-g mechanic. Out of the Arkers Raven has the most powerful mind of the group. Her exit from the City of Light was a loss to be sure. \n\n" +
                                    "* Age: 19 \n" +
                                    "* Living Family: none \n" +
                                    "* Skills: Genius, Mechanic, Electronics Expert. \n" +
                                    "* Kills: -- \n";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Raven Reyes",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/2/2b/RavenS2Promo.png/revision/latest?cb=20160401040926",
                                    Text = "It won't survive me"
                                });
                                break;
                            case "clarke":
                                reply.Text = "Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven, though she is resourceful. \n\n " +
                                    "* Age: 18 \n\n " +
                                    "* Living Family: Dr. Abigail Griffin \n\n" +
                                    "* Kills: 900+ \n\n" +
                                    "* Skills: Politics, Medical Knowledge";
;
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Clarke Griffin - aka Wanheda - the Commander of Death.",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/6/68/The-100-season-2-cast-photos-clarke.png/revision/latest?cb=20160401042738",
                                    Text = "Clarke Griffin/Princess/Wanheda"
                                });
                                break;
                            case "lexa":
                                reply.Text = "Lexa was the commander of the grounders, an avid warrior, who sought peace with the people from the Ark. She was the host for part 2 of my code until her consciousness was integrated into the second A.I. \n\n " +
                                    "* Age: around 20 \n" +
                                    "* Living Family: unkown \n" +
                                    "* Skills: Politics, Sword Fighting, Knife Throwing \n" +
                                    "* Kills: Unknown \n";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Lexa kom Trikru- aka Heda - the Commander.",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette1.wikia.nocookie.net/thehundred/images/8/80/Lexa1.png/revision/latest?cb=20160129174450",
                                    Text = ""
                                });
                                break;
                            case "jaha":
                                reply.Text = "Theloneous Jaha. Former Chancellor of the Ark. Instrumental in gainning follwers for the City of Light. \n\n" +
                                    "* Age: 55 \n" +
                                    "* Living Family: none \n" +
                                    "* Skills: Leadership, Manipulation \n" +
                                    "* Kills: 201 \n";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Theloneous Jaha",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"",
                                    Text = "Take this leap of faith with me."
                                });
                                break;
                            case "kane":
                                reply.Text = "Marcus Kane. Kane, former head of security on the Ark and temporary Chancellor. Kane is strategic but his weakness is his love for Abby. \n\n" +
                                    "* Age: 42 \n" +
                                    "* Living Family: none \n" +
                                    "* Skills: Genius, Mechanic, Electronics Expert. \n" +
                                    "* Kills: -- \n";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Marcus Kane",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/2/2b/RavenS2Promo.png/revision/latest?cb=20160401040926",
                                    Text = "200+"
                                });
                                break;
                            case "bellamy":
                                reply.Text = "Bellamy Blake. His weakness is his love for his sister and Clarke. He can be a great ralier of his people but is also easily manipulated.  \n\n" +
                                    "* Age: 23  \n" +
                                    "* Living Family: Octavia Blake \n" +
                                    "* Skills: Tacticial knowledge, weapons expert \n" +
                                    "* Kills: -- \n";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Bellamy Blake",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette2.wikia.nocookie.net/thehundred/images/5/5f/The-100-season-2-cast-photos-bellamy.png/revision/latest?cb=20160401042453",
                                    Text = "400+"
                                });
                                break;
                            default:
                                reply.Text = ("I have no information about that person. " +
                                    "Tell me who you would like to know about. " + 
                                    "Or if you would like to join the City of Light.");

                                break;
                        }

                    }
                    if (entityItem.Type == "Place")
                    {

                    }
                }
            }
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }
        
    }
}