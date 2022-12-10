import type { MessageSendModel } from "@/models/models";
import * as signalR from "@microsoft/signalr";
import moment from "moment";
export class SignalRHubService {
    protected hubConnection: signalR.HubConnection;
    public schema: IChatSchema
    constructor(protected hubUrl: string) {
        this.hubConnection = new signalR
        .HubConnectionBuilder()
        .withUrl(hubUrl).withAutomaticReconnect()
        .withHubProtocol(new signalR.JsonHubProtocol())
        .build();        
    }

    public Start = async () => {
        await this.hubConnection.start()
        await this.GetSchema();
    }

    public async GetSchema() {


    }
    
    protected async Invoke(target: string, model?: any) {
        if (model)
            await this.hubConnection.invoke(target, model);
        else
            await this.hubConnection.invoke(target);
    }

    public RegisterCallback = (event : string, callback : (...args : any) => void) => {
        this.hubConnection.on(event, callback);
    }
}

export interface IChatHubEntry {
    HubMethod : string;
    ReceiveMethod : string;
}

export interface IChatSchema {
    SERVER_POST : IChatHubEntry;
    MESSAGE_POST : IChatHubEntry;
    MESSAGE_REMOVE : IChatHubEntry;
    MESSAGE_PUT : IChatHubEntry;

}
export class ChatHubService extends SignalRHubService {
    constructor(hubUrl : string) {
        super(hubUrl);
    }


    public async GetSchema() {
        this.RegisterCallback("SCHEMA", (t : IChatSchema) => {
            let schema : any = t

            for (let x of Object.entries(t)) {
                let splitted = x[1].split(";");
                schema[x[0]] = {
                    HubMethod : splitted[0],
                    ReceiveMethod : splitted[1]
                }
            }            

            this.schema = schema;
            console.log(this.schema)
        })
        await this.Invoke("GetSchema")

    }

    public async SendMessage(model : MessageSendModel) {
        model.TimeStamp = moment();
        console.log(model);
        
        this.Invoke(this.schema.MESSAGE_POST.HubMethod, model);
    }
}