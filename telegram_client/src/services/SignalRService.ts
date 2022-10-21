import { store } from './../index';
import axios, { AxiosError } from "axios";
import AuthService from "./AuthService";
import * as signalR from '@microsoft/signalr';
import refreshPromise from '../http/refreshTokenPromise';
import { setAccessToken } from '../store/reducers/authSlice';

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

            if (!refreshPromise.refresh) {
              refreshPromise.refresh = axios.post<string>('auth/refresh').then(res => {
                console.log('send refresh from signalr interceptor');
                refreshPromise.refresh = null;
                store.dispatch(setAccessToken(res.data));
                return res.data;
              })
              
            } 
            refreshPromise.refresh.then((token:string) => {
              this.getConnection(token);
              this.connection.start();
            })
            .catch(async (e: AxiosError) => {
              if ((e as AxiosError).response?.status === 401) {
                        console.log('refresh error on signalr interceptor'); // force logout
                        await AuthService.logout();
                    }
              });
        }); 
    }

    stop() {
      this.connection.stop().then((res) => {
          console.log('stop: ', this.connection);
      });
      
    }
}