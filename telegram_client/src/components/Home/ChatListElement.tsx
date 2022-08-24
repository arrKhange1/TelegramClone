import React from 'react';
import { IChat } from './ChatList';
import side from '../../styles/side_panel/side.module.css';

function ChatListElement({chat} : {chat: IChat}) {
    return (
        <div className={side.chat}>
            <img src={chat.img} className={side.chat_img} alt='asap'/>
            <div className={side.chat_content}>
                <div>{chat.name}</div>
                <div>{chat.last_msg}</div>
            </div>
            <div className={side.chat_content}>
                <div>{chat.last_msg_date}</div>
                <div>{chat.unread_msgs}</div>
            </div>
        </div>
    );
}

export default ChatListElement;