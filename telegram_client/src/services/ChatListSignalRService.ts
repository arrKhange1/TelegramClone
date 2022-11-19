import * as signalR from "@microsoft/signalr";
import { store } from "..";
import IChat from "../@types/IChat";
import SignalRService from "./SignalRService";

export default class ChatListSignalRService extends SignalRService {

    onAddGroupChat : (groupName: string, chatId: string) => void;
    onNewMsgInChat: (chatElement: IChat) => void

    getConnection(accessToken: string) {
        this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat", { accessTokenFactory: () => accessToken })
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();
        
        this.connection.on('GroupChat', this.onAddGroupChat);
        this.connection.on('NewMsgInChat', this.onNewMsgInChat);
    }

    constructor(onAddGroupChat: (groupName: string, chatId: string) => void, 
        onNewMsgInChat: (chatElement: IChat) => void) {
        super();
        this.onAddGroupChat = onAddGroupChat;
        this.onNewMsgInChat = onNewMsgInChat;
        this.getConnection(store.getState().authReducer.accessToken);
    }
}