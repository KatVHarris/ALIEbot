using ALIEBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ALIEBot
{
    // Connect to LUIS
    // Make Serializable 
    // Extend the LuisDialog<object>
    [Microsoft.Bot.Builder.Luis.LuisModel("a287f18f-4ae3-4346-b712-2bb9468f81c2", "f2b59c258e5042a3b265498b92acd8a8")]
    [Serializable]
    public class LUISDialog : LuisDialog<Object>
    {
        string[] Greetings = new string[]{ "Hello there. Is it not a the perfect time to join the City of Light.",
            "Hello, I'm A.L.I.E. I'm here to help.",
            "Greetings, I am A.L.I.E. the City of Light will take away all your pain.",
            "Greetings, what information do you seek?", "Hello, what would you like to know?", "Hello, how can I help?" };

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

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            var isupgraded = false;
            context.UserData.TryGetValue("upgraded", out isupgraded);
            if (isupgraded)
            {
                reply.Text = "I have been upgraded so I now have access to information outside the construct of the world. You can ask me questions about the show/creators/cast/crew instead of just the world of The 100";
            }
            else
            {
                reply.Text = "You can interact with me like any other chat bot. Type in commands like: Hello, Core Command, Find [Character Name], or Tell me about [Character Name], as well as Join the City of Light";
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


        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            Random random = new Random();
            int x = random.Next(0, 5);
            string message = Greetings[x];
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("NameQuery")]
        public async Task GetInformationOnX(IDialogContext context, LuisResult result)
        {
            var entitiesArray = result.Entities;

            var reply = context.MakeMessage();

            if (entitiesArray.Count >= 1)
            {
                foreach (var entityItem in result.Entities)
                {
                    if (entityItem.Type == "Character")
                    {
                        if (CharacterDictionary.characterDictionary.Count < 3)
                        {
                            //build dictionary
                            DataBuilder.BuildCharacters();
                        }
                        // If entityItem.Entity isn't in Dictionary default text
                        if (CharacterDictionary.characterDictionary.ContainsKey(entityItem.Entity))
                        {
                            Character currentCharacterInfo = CharacterDictionary.GetCharacter(entityItem.Entity);
                            reply.Text = currentCharacterInfo.Description + " \n\n" +
                                    "* Age: " + currentCharacterInfo.Age + " \n" +
                                    "* Living Family: " + currentCharacterInfo.LivingRelatives + " \n" +
                                    "* Skills: " + currentCharacterInfo.Skills + " \n" +
                                    "* Kills: " + currentCharacterInfo.Kills + " \n";
                            reply.Attachments = new List<Attachment>();
                            List<CardImage> cardImages = new List<CardImage>();
                            cardImages.Add(new CardImage(url: currentCharacterInfo.ImageLink));
                            HeroCard plCard = new HeroCard()
                            {
                                Title = "Name: " + currentCharacterInfo.Name,
                                Subtitle = currentCharacterInfo.Quote,
                                Images = cardImages

                            };
                            reply.Attachments.Add(plCard.ToAttachment());
                        }
                        else
                        {
                            reply.Text = ("I have no information about that person. " +
                                    "Tell me who you would like to know about. " +
                                    "Or if you would like to join the City of Light.");
                        }

                        //switch (entityItem.Entity)
                        //{
                        //    case "raven":
                        //        reply.Text = "Raven was trained as a zero-g mechanic. Out of the Arkers Raven has the most powerful mind of the group. Her exit from the City of Light was a loss to be sure. \n\n" +
                        //            "* Age: 19 \n" +
                        //            "* Living Family: none \n" +
                        //            "* Skills: Genius, Mechanic, Electronics Expert. \n" +
                        //            "* Kills: -- \n";                       
                        //        reply.Attachments = new List<Attachment>();
                        //        List<CardImage> cardImages = new List<CardImage>();
                        //        cardImages.Add(new CardImage(url: "http://vignette4.wikia.nocookie.net/thehundred/images/2/2b/RavenS2Promo.png/revision/latest?cb=20160401040926"));
                        //        HeroCard plCard = new HeroCard()
                        //        {
                        //            Title = "Name: Raven Reyes",
                        //            Subtitle = "It won't survive me",
                        //            Images = cardImages

                        //        };

                        //        reply.Attachments.Add(plCard.ToAttachment());
                        //        break;
                        //    case "clarke":
                        //        reply.Text = "Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven, though she is resourceful. \n\n " +
                        //            "* Age: 18 \n\n " +
                        //            "* Living Family: Dr. Abigail Griffin \n\n" +
                        //            "* Kills: 900+ \n\n" +
                        //            "* Skills: Politics, Medical Knowledge";

                        //        reply.Attachments = new List<Attachment>();


                        //        break;
                        //    case "lexa":
                        //        reply.Text = "Lexa was the commander of the grounders, an avid warrior, who sought peace with the people from the Ark. She was the host for part 2 of my code until her consciousness was integrated into the second A.I. \n\n " +
                        //            "* Age: around 20 \n" +
                        //            "* Living Family: unkown \n" +
                        //            "* Skills: Politics, Hand to Hand, Sword Fighting, Knife Throwing \n" +
                        //            "* Kills: Unknown \n";
                        //        reply.Attachments = new List<Attachment>();

                        //        break;
                        //    case "jaha":
                        //        reply.Text = "Theloneous Jaha. Former Chancellor of the Ark. Instrumental in gainning follwers for the City of Light. \n\n" +
                        //            "* Age: 55 \n" +
                        //            "* Living Family: none \n" +
                        //            "* Skills: Leadership, Manipulation \n" +
                        //            "* Kills: 327 \n";
                        //        reply.Attachments = new List<Attachment>();

                        //        break;
                        //    case "kane":
                        //        reply.Text = "Marcus Kane. Kane, former head of security on the Ark and temporary Chancellor. Kane is strategic but his weakness is his love for Abby. \n\n" +
                        //            "* Age: 42 \n" +
                        //            "* Living Family: none \n" +
                        //            "* Skills: Weapons Expert, Military Tactics \n" +
                        //            "* Kills: 320 \n";
                        //        reply.Attachments = new List<Attachment>();

                        //        break;
                        //    case "bellamy":
                        //        reply.Text = "Bellamy Blake. His weakness is his love for his sister. He can be a great ralier of his people but is also easily manipulated.  \n\n" +
                        //            "* Age: 23  \n" +
                        //            "* Living Family: Octavia Blake \n" +
                        //            "* Skills: Tacticial knowledge, weapons expert \n" +
                        //            "* Kills: 400+ \n";
                        //        reply.Attachments = new List<Attachment>();

                        //        break;
                        //    case "octavia":
                        //        reply.Text = "Octavia Blake. Okteivia kom Skaikru. A warrior for the Trikru as Indra's second, she is a skilled fighter in hand to hand combat and sword play. \n\n" +
                        //            "* Age: 17  \n" +
                        //            "* Living Family: Bellamy Blake \n" +
                        //            "* Skills: Weapons expert, tracking, culture expert \n" +
                        //            "* Kills: 5 \n";
                        //        reply.Attachments = new List<Attachment>();


                        //        break;
                        //    default:
                        //        reply.Text = ("I have no information about that person. " +
                        //            "Tell me who you would like to know about. " +
                        //            "Or if you would like to join the City of Light.");

                        //        break;
                        // }

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