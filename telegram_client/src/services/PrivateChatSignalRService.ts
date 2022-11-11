import * as signalR from "@microsoft/signalr";
import { store } from "..";
import SignalRService from "./SignalRService";

export default class PrivateChatSignalRService extends SignalRService {

    onAddMsgInPrivateChat : (senderName: string, messageText: string, chatId: string) => void;

    getConnection(accessToken: string) {
        this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat", { accessTokenFactory: () => accessToken })
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();
        
        this.connection.on('AddMessagePrivateChat', this.onAddMsgInPrivateChat);
    }

    constructor(onAddMsgInPrivateChat: (senderName: string, messageText: string, chatId: string) => void) {
        super();
        this.onAddMsgInPrivateChat = onAddMsgInPrivateChat;
        this.getConnection(store.getState().authReducer.accessToken);
    }
}