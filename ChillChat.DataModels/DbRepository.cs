using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.DataModels;

namespace ChillChat.DataModels
{
    public class ChillChatDbRepository : DbRepository
    {
        public ChillChatDbRepository() : base(new ChillChatDbContext())
        {
        }
        public ChillChatDbRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
