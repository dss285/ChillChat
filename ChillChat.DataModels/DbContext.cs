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
        public ChillChatDbContext(bool useMock)
        {
            _useMock = useMock;
        }


        public DbSet<Server> Servers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_useMock)
                optionsBuilder.UseInMemoryDatabase("mockDatabase");
            else
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=dss285;Password=aeon123");
        }
    }
}
