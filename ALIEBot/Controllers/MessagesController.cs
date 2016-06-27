﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json;

namespace ALIEBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // ConnectorClient botConnector = new BotConnector();
                // ... use message.CreateReplyMessage() to create a message, or
                // ... create a new message and set From, To, Text 
                // await botConnector.Messages.SendMessageAsync(message);

                // Simplest of responses
                //return message.CreateReplyMessage($"You said:{message.Text}");

                //return await Conversation.SendAsync(message, () => new SimpleDialog());
                //return await Conversation.SendAsync(message, () => ComplexDialogChain.dialog);
                return await Conversation.SendAsync(message, () => new LUIS_Integration());

            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                var connector = new ConnectorClient();
                //ConnectorClient botConnector = new BotConnector();
                Message hello = new Message();
                hello.Text = "Bot Added";
                return hello;
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
                var connector = new ConnectorClient();
                Message reply =new Message();
                reply.Text = "User ADDED";
                return reply;
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}