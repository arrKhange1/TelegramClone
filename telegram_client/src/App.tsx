import React, { useEffect, useRef, useState } from 'react';
import * as signalR from '@microsoft/signalr';

export interface IMessage {
  user: string,
  msg: string
}

function App() {

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
            .catch(e => console.log('Connection failed: ', e));
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

        <div>Welcome {message.user}!</div>

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
        onClick={() => {
          connection?.send("Send", message.msg, message.user);
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

export default App;
