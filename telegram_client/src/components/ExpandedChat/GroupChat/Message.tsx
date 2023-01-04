import React from 'react';
import { IMessage } from '../../../@types/IExpandedChat';
import { useAuth } from '../../../hooks/useAuth';
import msgs from '../../../styles/messages_panel/messages.module.css';

function Message({msg, prevMsg} : {msg: IMessage, prevMsg: IMessage}) {
    const user = useAuth();

    return (
        <div className={user.userName === msg.userName ? `${msgs.msg} ${msgs.owner_msg}` :
            `${msgs.msg} ${msgs.others_msg}`}>
            <div className={msgs.username}>{prevMsg.messageType === "notification" || 
                msg.userName !== prevMsg.userName ? msg.userName : ''}</div>    
            <div className={msgs.text}>{msg.messageText}</div>
        </div>
    );
}

export default Message;