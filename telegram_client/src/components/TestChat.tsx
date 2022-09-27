import * as signalR from '@microsoft/signalr';
import axios from 'axios';
import React, { useEffect, useRef, useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';
import { $api } from '../http/axios';
import AuthService from '../services/AuthService';

export interface IMessage {
    user: string,
    msg: string
  }

function TestChat() {
  const user = useAuth();
  const navigate = useNavigate();

  const [connection, setConnection ] = useState<signalR.HubConnection>();
  const [msgs, setMsgs] = useState<IMessage[]>([]);
  const [message, setMessage] = useState<IMessage>({user: '', msg: ''});
  const userNameInput = useRef<HTMLInputElement>(null);

  useEffect(() => {
    const hubConnection = new signalR.HubConnectionBuilder()
                      .withUrl("/chat")
                      .build();
    setConnection(hubConnection);
  }, []);
  
  useEffect(() => {
    if (connection) {
        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.on('Send', (msg:string, username:string) => {
                    msgs.unshift({user:username, msg:msg});
                    console.log('received!');
                    console.log(msgs);
                    setMsgs([...msgs]);
                });

                
            })
            .catch(async e => {
                console.log('Connection failed: ', e.status);
                try {
                  await axios.post('auth/refresh');
                  const hubConnection = new signalR.HubConnectionBuilder()
                      .withUrl("/chat")
                      .build();
                  setConnection(hubConnection);
                  console.log('access token expired, new pair generated');
                } catch(e) {
                  console.log('refresh error'); // force logout
                  await AuthService.logout();
              }

            });
    }
}, [connection]);

  console.log(message);

  return (
    <>
    <div id="inputForm">
        <div>
          <input
           type="text"
           ref={userNameInput}
           />

           <input type="button" value="Login"
            onClick={() => {
              if (userNameInput && userNameInput.current) {
                  setMessage({...message, user:userNameInput.current.value});
              }
                
            }}
           />
        </div>

        <div>Welcome {message.user}! {user.userName} / {user.role}</div>

        <input
         type="text"
         id="message"
         value={message.msg}
         onChange={(e:any) => {
            setMessage({...message, msg:e.currentTarget.value});
         }}
         />
        <input 
        type="button"
        id="sendBtn"
        value="Отправить"
        onClick={async () => {
          await $api.post(`chats?msg=${message.msg}&username=${message.user}`);
          setMessage({...message, msg:''});
        }}
        />
    </div>
    {msgs.map((msg, index) => 
        <div key={index}>
          <b>{msg.user}: </b>
          <span>{msg.msg}</span>
        </div>
        
    )}
    </>
  );
}

export default TestChat;