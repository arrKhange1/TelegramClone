import { useEffect, useState } from 'react';
import IChat from '../../@types/IChat';
import side from '../../styles/side_panel/side.module.css';

function ChatListElement({activeChat, chat} : {activeChat: string,
    chat: IChat}) {
    
    function editLastMsgText(lastMsgText: string): string {
        if (lastMsgText.length > 20) 
            return lastMsgText.substring(0, 20) + '...';
        return lastMsgText;
    }

    return (
        <div className={activeChat === chat.chatId ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <img src="imgs/contacts_icon.png" alt="" className={side.chat_img} />
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{chat.chatName}</div>
                <div>{chat.lastMessageType === "message" ? `${chat.lastMessageSender}: ${editLastMsgText(chat.lastMessageText)}` :
                    `${chat.lastMessageSender} ${editLastMsgText(chat.lastMessageText)}`}</div>
            </div>
            {chat.unreadMsgs ? <div className={`${side.chat_content} ${side.chat_end}`}>{chat.unreadMsgs}</div> : <></>}
        </div>
    );
}

export default ChatListElement;