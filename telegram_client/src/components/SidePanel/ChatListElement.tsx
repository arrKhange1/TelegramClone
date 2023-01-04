import { useEffect, useState } from 'react';
import IChat from '../../@types/IChat';
import { useAuth } from '../../hooks/useAuth';
import ContactIcon from '../../icons/ContactIcon';
import side from '../../styles/side_panel/side.module.css';

function ChatListElement({activeChat, chat} : {activeChat: string,
    chat: IChat}) {
    
    const currUsername = useAuth().userName;

    function editLastMsgText(lastMsgText: string): string {
        if (lastMsgText.length > 20) 
            return lastMsgText.substring(0, 20) + '...';
        return lastMsgText;
    }

    function getChatLastMessage() {
        const msgType = chat.lastMessageType;
        const sender = chat.lastMessageSender;
        const shortenMessageText = editLastMsgText(chat.lastMessageText);
        const chatType = chat.chatCategory;

        if (msgType === "notification") 
            return `${sender} ${shortenMessageText}`;
        if (sender === currUsername) 
            return `You: ${shortenMessageText}`;
        if (chatType === "private")
            return `${shortenMessageText}`;
        if (chatType === "group") 
            return `${sender}: ${shortenMessageText}`;
            
    }


    return (
        <div className={activeChat === chat.chatId ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <ContactIcon className={side.chat_img}/>
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{chat.chatName}</div>
                <div>{getChatLastMessage()}</div>
            </div>
            {chat.unreadMsgs ? <div className={`${side.chat_content} ${side.chat_end}`}>{chat.unreadMsgs}</div> : <></>}
        </div>
    );
}

export default ChatListElement;