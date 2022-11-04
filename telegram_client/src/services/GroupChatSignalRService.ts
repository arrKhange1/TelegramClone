import * as signalR from "@microsoft/signalr";
import { store } from "..";
import SignalRService from "./SignalRService";

export default class GroupChatSignalRService extends SignalRService {

    onAddMsgInGroupChat : (senderName: string, messageText: string) => void;

    getConnection(accessToken: string) {
        this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat", { accessTokenFactory: () => accessToken })
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();
        
        this.connection.on('AddMessageGroupChat', this.onAddMsgInGroupChat);
    }

    constructor(onAddMsgInGroupChat: (senderName: string, messageText: string) => void) {
        super();
        this.onAddMsgInGroupChat = onAddMsgInGroupChat;
        this.getConnection(store.getState().authReducer.accessToken);
    }
}