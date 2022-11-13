import type { Moment } from "moment";
import type { ChannelType } from "./enums";

export class ObjectInfo {
    public Deleted : boolean;
    public Creator : string;
    public Modifier : string;
    public Modified : Moment;
    public Created : Moment;
}
export class Message {
    public MessageId: number;
    public Content : string;
    public ChannelId : number|null;
    public Channel : Channel|null;
    public ObjectInfo : ObjectInfo;
}
export class Server {
    public ServerId : number;
    public Name : string;
    public Channels : Channel[]
    public ObjectInfo : ObjectInfo;
}
export class Channel {
    public ChannelId : number;
    public Name : string;
    public ChannelType : ChannelType;
    public ObjectInfo : ObjectInfo;
}