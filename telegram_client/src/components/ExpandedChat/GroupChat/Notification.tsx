import React from 'react';
import { IMessage } from '../../../@types/IExpandedChat';
import msgs from '../../../styles/messages_panel/messages.module.css';

function Notification({msg} : {msg: IMessage}) {
    return (
        <div className={msgs.notification}>
            <span className={msgs.username}>{msg.userName} </span>
            <span>{msg.messageText}</span>
        </div>
    );
}

export default Notification;