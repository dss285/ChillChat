using NodaTime;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ChillChat.Server.Hubs.Models
{
    [DataContract]
    public class MessageModel
    {
        [JsonInclude]
        public int UserId { get; set; }
        [JsonInclude]
        public string Message { get; set; }
        [JsonInclude]
        public DateTime TimeStamp { get; set; }
    }
}
