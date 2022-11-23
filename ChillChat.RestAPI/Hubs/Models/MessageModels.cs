using NodaTime;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ChillChat.RestAPI.Hubs.Models
{
    [DataContract]
    public class MessageModel
    {
        [JsonInclude]
        public string User { get; set; }
        [JsonInclude]
        public string Message { get; set; }
        [JsonInclude]
        public DateTime TimeStamp { get; set; }
    }
}
