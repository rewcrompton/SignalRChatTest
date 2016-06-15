using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChatTest.Models;

namespace SignalRChatTest
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.processMessage(message);
        }

        public void SendMessageWithUserData(UserData userData, string message)
        {
            Clients.All.processMessageFromUser(userData, message);
        }
    }
}