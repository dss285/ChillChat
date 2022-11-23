using ChillChat.RestAPI.Hubs.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChillChat.RestAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task MessageSend(MessageModel model) {

            await Clients.All.SendAsync("ReceiveMessage", model);
        } 
    }
}
