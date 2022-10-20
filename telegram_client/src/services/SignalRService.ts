import { store } from './../index';
import axios from "axios";
import AuthService from "./AuthService";
import * as signalR from '@microsoft/signalr';

export default class SignalRService {

    connection!: signalR.HubConnection;

    getConnection(accessToken: string) {
      this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/chat", { accessTokenFactory: () => accessToken })
      .withAutomaticReconnect()
      .configureLogging(signalR.LogLevel.Information)
      .build();
      
      this.connection.on('GroupChat', (groupName: string) => {
        console.log('chat added:',  groupName)
      });
    }

    constructor() {
      this.getConnection(store.getState().authReducer.accessToken);
      
    }

    start() {
        return this.connection.start().catch(e => {
            console.log('wtf')
            axios.post<string>('auth/refresh').then((res) => {
              console.log('new access token:', res.data);
              this.getConnection(res.data);
              this.connection.start();
              // refresh token in redux and local storage
          });
        }); 
    }

    stop() {
      this.connection.stop().then((res) => {
          console.log('stop: ', this.connection);
      });
      
    }
}