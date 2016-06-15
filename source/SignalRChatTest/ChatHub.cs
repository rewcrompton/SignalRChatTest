using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChatTest.Models;

namespace SignalRChatTest
{
    [HubName("theChatHub")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.processMessage(message);
        }

        //TODO refactor chat.js to call SendMessageWithUserData rather than this method
        //passing the username in as a userData object instead of the string username
        public void SendMessageAndName(string username, string message)
        {
            Clients.All.broadcastMessage(username, message);
        }

        public void SendMessageWithUserData(UserData userData, string message)
        {
            Clients.All.processMessageFromUser(userData, message);
        }
    }
}