import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import IExpandedChat from '../../@types/IExpandedChat';
import { $api } from '../../http/axios';
import Footer from './Footer';
import Header from './Header';
import MessagesList from './MessagesList';
import msgs from '../../styles/messages_panel/messages.module.css';

function GroupChat() {
    const params = useParams();

    const [chat, setChat] = useState<IExpandedChat>({
        chatName: '',
        chatStatus: '',
        messages: []
    })

    useEffect(() => {
        getChat();
    }, [params.chatId])

    const getChat = async () => {
        const response = await $api.get<IExpandedChat>(`chats/getchat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    return (
        <div className={msgs.messages_panel}>
            <Header chatName={chat.chatName} chatStatus={chat.chatStatus}/>
            <MessagesList messages={chat.messages}/>
            <Footer/>
        </div>
    );
}

export default GroupChat;