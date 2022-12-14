using ChillChat.Server.Hubs.Models;
using ChillChat.Services;
using Microsoft.AspNetCore.SignalR;

namespace ChillChat.Server.Hubs
{

    public class ChatHub : Hub
    {
        private readonly IServiceProvider _serviceProvider;
        public ChatHub(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task SendMessage(MessageModel model) {



            
            MessageService ser = _serviceProvider.GetRequiredService<MessageService>();

            MessageViewModel mvm = new()
            {
                MemberId = model.UserId,
                Content = model.Message
            };
            var res = await ser.SaveAsync(mvm);

            if (res != null)
                await Clients.All.SendAsync(ChatSchema.MessagePost.Event, model);
            // send fail ?
        }
        public async Task ServerCreate()
        {
            await Clients.Caller.SendAsync(ChatSchema.ServerPost.Event);
        }

        public async Task GetSchema()
        {
            await Clients.Caller.SendAsync("SCHEMA", ChatSchema.SchemaDictionary);
        }
    }
}
