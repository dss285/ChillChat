using Aeon.Core;
using ChillChat.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillChat.Services
{
    public class ServerViewModel
    {
        public int ServerId { get; set; }
        public string Name { get; set; }
        public ObjectInfo ObjectInfo { get; set; } 
    }
    public class ServerService : BaseService<Server, ServerViewModel>
    {
        public ServerService(ChillChatDbRepository repository) : base(repository)
        {
        }

        public override Server Save(ServerViewModel model)
        {
            var ret = base.Save(model, t => t.ServerId == model.ServerId);
            _repository.SaveChanges();
            return ret;
        }
        public override async Task<Server> SaveAsync(ServerViewModel model)
        {
            var ret = await base.SaveAsync(model, t => t.ServerId == model.ServerId);
            await _repository.SaveChangesAsync();
            return ret;
        }

        protected override Server MapFromModel(ServerViewModel model)
        {
            return new Server
            {
                ServerId = model.ServerId,
                Name = model.Name,
                ObjectInfo = model.ObjectInfo,
            };
        }

        protected override ServerViewModel MapToModel(Server entity)
        {
            return new ServerViewModel 
            {
                ServerId = entity.ServerId,
                Name = entity.Name,
                ObjectInfo = entity.ObjectInfo,
            };
        }
    }
}
