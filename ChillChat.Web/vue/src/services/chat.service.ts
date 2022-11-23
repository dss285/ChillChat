import type { MessageSendModel } from "@/models/models";
import * as signalR from "@microsoft/signalr";
import moment from "moment";
export class SignalRHubService {
    protected hubConnection : signalR.HubConnection;
    constructor(protected hubUrl : string) {
        this.hubConnection = new signalR
        .HubConnectionBuilder()
        .withUrl(hubUrl).withAutomaticReconnect()
        .withHubProtocol(new signalR.JsonHubProtocol())
        .build();        
    }

    public Start = async () => {
        await this.hubConnection.start();
    }
    
    protected async Invoke(target : string, model : any) {
        await this.hubConnection.invoke(target, model);
    }

    public RegisterCallback = (event : string, callback : (...args : any) => void) => {
        this.hubConnection.on(event, callback);
    }
}

export class ChatHubService extends SignalRHubService {
    constructor(hubUrl : string) {
        super(hubUrl);
    }

    public SendMessage(model : MessageSendModel) {
        model.TimeStamp = moment();
        console.log(model);
        
        this.Invoke("MessageSend", model);
    }
}