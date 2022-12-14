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
    public class User : IObjectInfo
    {
        [Key] 
        public int UserId { get; set; }

        public string Name { get; set; }
        public string DisplayName { get; set; }

        public virtual ObjectInfo ObjectInfo { get; set; }
        public virtual IEnumerable<Member> Memberships { get; set; }
    }

    public class Member : IObjectInfo
    {
        [Key]
        public int MemberId { get; set; }
        public string DisplayName { get; set; }

        public int ServerId { get; set; }
        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }



        public virtual ObjectInfo ObjectInfo { get; set; }
    }

    public class Server : IObjectInfo
    {
        [Key]
        public int ServerId { get; set; }
        public string Name { get; set; }
        public List<Channel> Channels { get; set; }
        public virtual ObjectInfo ObjectInfo { get; set; }
        public virtual IEnumerable<Member> Members { get; set; }

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

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        public int? ChannelId { get; set; }
        [ForeignKey("ChannelId")]
        public virtual Channel? Channel { get; set; }
        public virtual ObjectInfo ObjectInfo { get; set; }
    }
}
