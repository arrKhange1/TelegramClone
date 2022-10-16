import axios from "axios";
import AuthService from "./AuthService";
import * as signalR from '@microsoft/signalr';

export default class SignalRService {

    connection: signalR.HubConnection;

    constructor() {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .withAutomaticReconnect()
        .configureLogging(signalR.LogLevel.Information)
        .build();
    }

    start() {
      this.connection.start();
    }

    stop() {
      this.connection.stop().then((res) => {
          console.log('stop: ', this.connection);
      });
      
    }
}