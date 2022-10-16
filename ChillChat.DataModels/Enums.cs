using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillChat.DataModels
{
    [Flags]
    public enum ChannelTypeEnum : byte
    {
        TextChannel = 1,
        VoiceChannel = 2,
    }
}
