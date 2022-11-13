using Microsoft.AspNetCore.SignalR;

namespace ChillChat.RestAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task MessageSent(string user, string message, int times) { 
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        } 
    }
}
