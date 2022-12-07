using ChillChat.Server.Hubs.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChillChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task MessageSend(MessageModel model) {

            await Clients.All.SendAsync("ReceiveMessage", model);
        } 
    }
}
