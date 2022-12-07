using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.Core;
using Microsoft.EntityFrameworkCore;

namespace ChillChat.DataModels
{
    public class Server : IObjectInfo
    {
        [Key]
        public int ServerId { get; set; }
        public string Name { get; set; }
        public List<Channel> Channels { get; set; }
        public virtual ObjectInfo ObjectInfo { get; set; }
    }
    public class Channel : IObjectInfo
    {
        [Key]
        public int ChannelId { get; set; }
        public string Name { get; set; }

        public ChannelTypeEnum ChannelType { get; set; }
        
        public int ServerId;
        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }

        public virtual ObjectInfo ObjectInfo { get; set; }
    }
    public class Message : IObjectInfo
    {
        [Key]
        public int MessageId { get; set; }
        public string Content { get; set; }

        public int? ChannelId { get; set; }
        [ForeignKey("ChannelId")]
        public virtual Channel? Channel { get; set; }
        public virtual ObjectInfo ObjectInfo { get; set; }
    }
}
