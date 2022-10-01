import axios from "axios";
import AuthService from "./AuthService";
import * as signalR from '@microsoft/signalr';

export default class SignalRService {

    connection: signalR.HubConnection;

    constructor() {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();
    }

    async start() {
      await this.connection.start();
    }

    async stop() {
      await this.connection.stop();
    }
}