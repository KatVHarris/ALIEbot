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

namespace ALIEBot
{
    [Serializable]
    public class ALIEecho : IDialog<object>
    {
        protected int count = 1;
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecievedAsync);
        }

        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<Message> argument)
        {
            var message = await argument;
            var reply = context.MakeMessage();
            switch (message.Text.ToLower())
            {
                case "raven":

                    //reply.Text = string.Format("{0}: You said {1}", this.count++, message.Text);
                    reply.Text = "Out of the Arkers Raven has the most powerful mind of the group. Her exit from the City of Light was a loss to be sure. " ;
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment
                    {
                        //Title = "Raven",
                        //TitleLink = "http://the100.wikia.com/wiki/Raven_Reyes",
                        //ThumbnailUrl = "http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
                        //Text = "Bender Bending Rodríguez, commonly known as Bender, is a main character in the animated television series Futurama.",
                        //FallbackText = "Raven"
                        Title = "Name: Raven Reyes",
                        ContentType = "image/jpeg",
                        ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
                        Text = "Status: Exited City of Light \n >Age: 19 \n  >Living Family: None \n "
                        //Actions = actions

                    });
                    break;
                case "clarke":

                    //reply.Text = string.Format("{0}: You said {1}", this.count++, message.Text);
                    reply.Text = "Clarke is strong and determined. Her friends and family are her weakness. She is not as clever as Raven though she is resrouceful.";
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(new Attachment
                    {
                        Title = "Name: Clarke Griffin - aka WanHeda - the commander of Death.",
                        ContentType = "image/jpeg",
                        ContentUrl = $"http://vignette4.wikia.nocookie.net/thehundred/images/6/68/The-100-season-2-cast-photos-clarke.png/revision/latest?cb=20160401042738",
                        Text = "Status: Not in City of Light \n >Age: 19 \n  >Living Family: Abby Griffin \n "
                        //Actions = actions

                    });
                    break;
                default:
                    reply.Text = ("Tell me who you would like to know about.");
                    
                    break;
            } 
                    

                await context.PostAsync(reply);
                context.Wait(MessageRecievedAsync);
         }

            //for (int i = 0; i < 10; i++)
            //{
            //    reply.Attachments.Add(new Attachment
            //    {
            //        Title = "Raven",
            //        TitleLink = "http://the100.wikia.com/wiki/Raven_Reyes",
            //        ThumbnailUrl = "http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
            //        Text = "Bender Bending Rodríguez, commonly known as Bender, is a main character in the animated television series Futurama.",
            //        FallbackText = "Bender: http://www.theoldrobots.com/images62/Bender-18.JPG",
            //        Actions = actions
            //    });
            //}
            //await context.PostAsync(reply);
                //context.Wait(MessageReceivedAsync);

                //var reply1 = new Message();

                //reply.Attachments.Add(new Attachment()
                //{
                //    Title = "Bender",
                //    TitleLink = "https://en.wikipedia.org/wiki/Bender_(Futurama)",
                //    ThumbnailUrl = "http://vignette4.wikia.nocookie.net/thehundred/images/5/5e/The-100-season-2-cast-photos-raven.png/revision/latest?cb=20160401040926",
                //    Text = "Bender Bending Rodríguez, commonly known as Bender, is a main character in the animated television series Futurama.",
                //    FallbackText = "Bender: http://www.theoldrobots.com/images62/Bender-18.JPG"
                //});
                ////message.CreateReplyMessage("reply");
                //await context.PostAsync(reply1);



            
            //if(message.Text == "reset")
            //{
            //    PromptDialog.Confirm(
            //        context,
            //        AfterResetAsync,
            //        "Are you sure you want to reset the Code? If you do all the people in the City of Light will die.",
            //        "Didn't get that...",
            //        promptStyle: PromptStyle.None);
            //else
            //{
            //    await context.PostAsync(string.Format("{0}: You said {1}", this.count++, message.Text));
            //    context.Wait(MessageRecievedAsync);
            //}

        //}

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reseting");
            }else
            {
                await context.PostAsync("Reset aorted. Thank you.");
            }
            context.Wait(MessageRecievedAsync);
        }
    }

    //Who is in City of Light?
    // Jaha, Abby, Kane, Emori, Jasper,

    //Octavia, Clakre, Raven, Bellamy, Monty, Harper, 

    //Sort [Character] // What house is [BLANK] in?

    //
}