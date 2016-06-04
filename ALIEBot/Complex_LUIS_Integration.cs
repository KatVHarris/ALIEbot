using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

//Add dependencies 
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

namespace ALIEBot
{
    // Connect to LUIS
    // Make Serializable 
    // Extend the LuisDialog<object>
    [LuisModel("a287f18f-4ae3-4346-b712-2bb9468f81c2", "f2b59c258e5042a3b265498b92acd8a8")]
    [Serializable]
    public class Complex_LUIS_Integration : LuisDialog<Object>
    {
        //Generate Method for every Intent in LUIS model
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //None is the default response
            string message = "Tell me who you would like to know about. Or if you would like to join the City of Light.";
            //Can also respond with the following if you don't have a set default message- $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));

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
                        switch (entityItem.Entity)
                        {
                            case "raven":
                                reply.Text = "Out of the Arkers Raven has the most powerful mind of the group. Her exit from the City of Light was a loss to be sure. ";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Raven Reyes",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
                                    Text = "Status: Exited City of Light \n >Age: 19 \n  >Living Family: None \n "
                                });
                                break;
                            case "clarke":
                                reply.Text = "Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven though she is resrouceful.";
                                reply.Attachments = new List<Attachment>();
                                reply.Attachments.Add(new Attachment
                                {
                                    Title = "Name: Clarke Griffin - aka WanHeda - the commander of Death.",
                                    ContentType = "image/jpeg",
                                    ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/6/68/The-100-season-2-cast-photos-clarke.png/revision/latest?cb=20160401042738",
                                    Text = "Status: Not in City of Light \n >Age: 19 \n  >Living Family: Abby Griffin \n "
                                });
                                break;
                            default:
                                reply.Text = ("Tell me who you would like to know about.");
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