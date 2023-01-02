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
      
    }

    start() {
        return this.connection.start().catch(e => {

            if (!refreshPromise.refresh) {
              refreshPromise.refresh = axios.post<string>('auth/refresh').then(res => {
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
                        refreshPromise.refresh = null;
                        await AuthService.logout();
                    }
              });
        }); 
    }

    stop() {
      this.connection.stop();
    }
}