using Aeon.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillChat.DataModels
{
    public class ChillChatDbContext : BaseDbContext
    {
        protected bool _useMock = false;
        public ChillChatDbContext()
        {
        }


        public DbSet<Server> Servers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override string ConnectionString { get; set; } = "Host=localhost;Database=postgres;Username=dss285;Password=aeon123";
    }
}
