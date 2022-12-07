using Aeon.Core;
using ChillChat.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillChat.Services
{
    public class ChannelViewModel
    {
        public int ChannelId { get; set; }
        public string Name { get; set; }
        public ChannelTypeEnum ChannelType { get; set; }
        public ObjectInfo ObjectInfo { get; set; }
    }
    public class ChannelService : BaseService<Channel, ChannelViewModel>
    {
        public ChannelService(ChillChatDbRepository repository) : base(repository)
        {
        }

        public override Channel Save(ChannelViewModel model)
        {
            var ret = base.Save(model, t => t.ChannelId == model.ChannelId);
            _repository.SaveChanges();
            return ret;
        }

        protected override Channel MapFromModel(ChannelViewModel model)
        {
            return new Channel
            {
                ChannelId = model.ChannelId,
                Name = model.Name,
                ChannelType = model.ChannelType,
                ObjectInfo = model.ObjectInfo
            };
        }

        protected override ChannelViewModel MapToModel(Channel entity)
        {
            return new ChannelViewModel
            {
                ChannelId = entity.ChannelId,
                Name = entity.Name,
                ChannelType = entity.ChannelType,
                ObjectInfo = entity.ObjectInfo
            };
        }
    }
}
