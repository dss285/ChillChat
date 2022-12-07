using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.Core;

namespace ChillChat.DataModels
{
    public class ChillChatDbRepository : BaseDbRepository, IBaseDbRepository
    {
        public ChillChatDbRepository() : base(new ChillChatDbContext())
        {
        }
        public ChillChatDbRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }

        public override void CreateNewContext()
        {
            throw new NotImplementedException();
        }
    }
}
