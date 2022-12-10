namespace ChillChat.Server.Hubs
{
    public class ChatEventMethod
    {
        public ChatEventMethod(string name, string hubMethod, string eventN)
        {
            Name = name;
            HubMethod = hubMethod;
            Event = eventN;
        }
        public string Name { get; private set; }
        public string HubMethod { get; private set; }
        public string Event { get; private set; }
        public string MethodEvent
        {
            get
            {
                return $"{HubMethod};{Event}";
            }
        }

    }
    public static class ChatSchema
    {
        public static ChatEventMethod ServerPost { get; } = new("SERVER_POST", "SendMessage", "MESSAGE_RECEIVE");
        public static ChatEventMethod ServerPut { get; } = new("SERVER_PUT", "ServerUpdate", "SERVER_UPDATED");
        public static ChatEventMethod MessagePost { get; } = new("MESSAGE_POST", "SendMessage", "MESSAGE_RECEIVE");
        public static ChatEventMethod MessagePut { get; } = new("MESSAGE_PUT", "MESSAGE_UPDATE", "MESSAGE_UPDATED");
        public static ChatEventMethod MessageRemove { get; } = new("MESSAGE_REMOVE", "DeleteMessage", "MESSAGE_DELETED");

        public static Dictionary<string, string> SchemaDictionary { get; } = new()
        {
            { ServerPost.Name, ServerPost.MethodEvent},
            { ServerPut.Name, ServerPut.MethodEvent},
            { MessagePost.Name, MessagePost.MethodEvent},
            { MessagePut.Name, MessagePut.MethodEvent},
            { MessageRemove.Name, MessageRemove.MethodEvent}
        };

    }
}
