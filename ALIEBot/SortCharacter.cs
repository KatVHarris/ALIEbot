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
using Microsoft.Bot.Builder.FormFlow;

namespace ALIEBot
{
    [Serializable]
    public class SortCharacter : IDialog<object>
    {
        protected int count = 1;
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecievedAsync);
        }

        internal static IDialog<ChainSort> SortCharacterDialog()//MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(ChainSort.BuildForm));
        }

        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<Message> argument)
        {
            var message = await argument;
            var reply = context.MakeMessage();
            switch (message.Text.ToLower())
            {
                case "raven":

                    //reply.Text = string.Format("{0}: You said {1}", this.count++, message.Text);
                    reply.Text = "Out of the Arkers Raven has the most powerful mind of the group. Her exit from the City of Light was a loss to be sure. ";
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment
                    {
                        Title = "Name: Raven Reyes",
                        ContentType = "image/jpeg",
                        ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
                        Text = "Status: Exited City of Light \n >Age: 19 \n  >Living Family: None \n ",
                        FallbackText = "Raven"
                        //Actions = actions

                    });
                    await context.PostAsync(reply);
                    context.Wait(MessageRecievedAsync);
                    break;
                case "clarke":

                    //reply.Text = string.Format("{0}: You said {1}", this.count++, message.Text);
                    reply.Text = "Clarke is... problematic. Her friends and family are her weakness. She is not as clever as Raven though she is resrouceful. As leader of the 100 having her join the City of Light will make it easier to obtain the second half of my code.";
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment
                    {
                        Title = "Name: Clarke Griffin - aka WanHeda - the commander of Death.",
                        ContentType = "image/jpeg",
                        ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/6/68/The-100-season-2-cast-photos-clarke.png/revision/latest?cb=20160401042738",
                        Text = "Status: Not in City of Light \n >Age: 19 \n  >Living Family: Abby Griffin \n "
                        //Actions = actions

                    });
                    await context.PostAsync(reply);
                    context.Wait(MessageRecievedAsync);
                    break;
                case "joke":

                    //reply.Text = string.Format("{0}: You said {1}", this.count++, message.Text);
                    reply.Text = "Clarke is... problematic. Her friends and family are her weakness. She is not as clever as Raven though she is resrouceful. As leader of the 100 having her join the City of Light will make it easier to obtain the second half of my code.";
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment
                    {
                        Title = "Name: Clarke Griffin - aka WanHeda - the commander of Death.",
                        ContentType = "image/jpeg",
                        ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/6/68/The-100-season-2-cast-photos-clarke.png/revision/latest?cb=20160401042738",
                        Text = "Status: Not in City of Light \n >Age: 19 \n  >Living Family: Abby Griffin \n "
                        //Actions = actions

                    });
                    await context.PostAsync(reply);
                    context.Wait(MessageRecievedAsync);
                    break;
                case "join":
                    PromptDialog.Confirm(
                        context,
                        AfterJoinAsync,
                        "The City of Light take away all your pain. Do you wish to take the Key?", //If you do all the people in the City of Light will die.",
                        "Could not determine your request...",
                        promptStyle: PromptStyle.None);
                    break;
                default:
                    reply.Text = ("Tell me who you would like to know about. Or if you would like to join the City of Light.");
                    await context.PostAsync(reply);
                    context.Wait(MessageRecievedAsync);
                    break;
            }
        }

        public async Task AfterJoinAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Congratulations! Let us take away all of your pain. Welcome to the City of Light.");
            }
            else
            {
                await context.PostAsync("Are you sure? There is no pain in the City of Light.");
            }
            context.Wait(MessageRecievedAsync);
        }

        public async Task SelectCharacter(IDialogContext context, IAwaitable<string> arg)
        {
            Chain.Switch().PostToUser();
        }
    }
}