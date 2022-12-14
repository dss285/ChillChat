using Aeon.Core;
using ChillChat.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ChillChat.Services
{
    public class MessageViewModel
    {
        public int MemberId { get; set; }
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
            var uid = await _repository.FindExisting<Member>(t => t.MemberId == model.MemberId).FirstOrDefaultAsync();
            if (uid == null) { return null; }
            var ret = await base.SaveAsync(model, t => t.MessageId == model.MessageId);
            await _repository.SaveChangesAsync();
            return ret;

        }

        protected override Message MapFromModel(MessageViewModel model)
        {
            return new Message { 
                MemberId = model.MemberId,
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