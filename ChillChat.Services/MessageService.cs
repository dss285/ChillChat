using Aeon.Core;
using ChillChat.DataModels;

namespace ChillChat.Services
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public ObjectInfo ObjectInfo { get; set; }
        public int? ChannelId { get; set; }

    }
    public class MessageService : BaseService<Message, MessageViewModel>
    {
        public MessageService(ChillChatDbRepository repository) : base(repository)
        {
        }

        public override Message Save(MessageViewModel model)
        {
            var ret = base.Save(model, t => t.MessageId == model.MessageId);
            _repository.SaveChanges();
            return ret;
        }
        public override async Task<Message> SaveAsync(MessageViewModel model)
        {
            var ret = await base.SaveAsync(model, t => t.MessageId == model.MessageId);
            await _repository.SaveChangesAsync();
            return ret;

        }

        protected override Message MapFromModel(MessageViewModel model)
        {
            return new Message { 
                MessageId=model.MessageId,
                ObjectInfo=model.ObjectInfo, 
                Content=model.Content, 
                ChannelId=model.ChannelId
            };
        }

        protected override MessageViewModel MapToModel(Message entity)
        {
            return new MessageViewModel { 
                MessageId=entity.MessageId, 
                ObjectInfo=entity.ObjectInfo, 
                Content=entity.Content, 
                ChannelId=entity.ChannelId 
            };
        }
    }
}