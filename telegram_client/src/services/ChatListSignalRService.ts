import * as signalR from "@microsoft/signalr";
import { store } from "..";
import SignalRService from "./SignalRService";

export default class ChatListSignalRService extends SignalRService {

    onAddGroupChat : (groupName: string) => void;

    getConnection(accessToken: string) {
        this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat", { accessTokenFactory: () => accessToken })
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();
        
        this.connection.on('GroupChat', this.onAddGroupChat);
    }

    constructor(onAddGroupChat: (groupName: string) => void) {
        super();
        this.onAddGroupChat = onAddGroupChat;
        this.getConnection(store.getState().authReducer.accessToken);
    }
}