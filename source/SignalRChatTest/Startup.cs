
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRChatTest.Startup))]

namespace SignalRChatTest
{
   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}