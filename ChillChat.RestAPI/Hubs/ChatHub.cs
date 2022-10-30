using Microsoft.AspNetCore.SignalR;

namespace ChillChat.RestAPI.Hubs
{
    public class ChatHub : Hub
    {
        
        public async Task messageSent(string username, string message, string timestamp)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("messageRecieved");
        }



    }
}
