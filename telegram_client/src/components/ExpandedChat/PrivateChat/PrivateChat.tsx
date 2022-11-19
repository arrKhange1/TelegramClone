import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat, IPrivateChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import PrivateChatSignalRService from '../../../services/PrivateChatSignalRService';
import { useAuth } from '../../../hooks/useAuth';

function PrivateChat() {
    const params = useParams();
    const user = useAuth();

    const [chat, setChat] = useState<IPrivateChat>({
        userName: '',
        connectionStatus: '',
        messages: []
    });
    const  [textMsg, setTextMsg] = useState('');

    function onAddMsgInPrivateChat(senderName: string, messageText: string, fromId: string, toId: string) {
        if ((user.userId === fromId && params.chatId === toId) ||
                (user.userId === toId && params.chatId === fromId))
            setChat(prev => ({...prev, messages: [...prev.messages, {userName: senderName, messageText: messageText, messageType: "message"}]}));
    }

    useEffect(() => {
        getChat();

        const signalRService = new PrivateChatSignalRService(onAddMsgInPrivateChat);
        signalRService.start();
        console.log('conn to privatechat:', signalRService.connection);

        return () => signalRService.stop();
    }, [params.chatId])

    const getChat = async () => {
        const response = await $api.get<IPrivateChat>(`chats/getprivatechat?fromId=${user.userId}&toId=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    const sendMsg = async (e: React.MouseEvent<HTMLDivElement>) => {
        const response = await $api.post(`chats/sendprivatechat?fromId=${user.userId}&toId=${params.chatId}&messageText=${textMsg}`);
        console.log(response.data)
    };

    return (
        <div className={msgs.messages_panel}>
            <Header userName={chat.userName} conStatus={chat.connectionStatus}/>
            <MessagesList messages={chat.messages}/>
            <Footer textMsg={textMsg} sendMsg={sendMsg} setTextMsg={setTextMsg}/>
        </div>
    );
}

export default PrivateChat;