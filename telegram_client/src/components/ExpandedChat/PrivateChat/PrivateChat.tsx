import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat, IPrivateChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import PrivateChatSignalRService from '../../../services/PrivateChatSignalRService';

function PrivateChat() {
    const params = useParams();

    const [chat, setChat] = useState<IPrivateChat>({
        userName: '',
        connectionStatus: '',
        messages: []
    })

    function onAddMsgInPrivateChat(senderName: string, messageText: string, chatId: string) {
        if (chatId === params.chatId)
            setChat(prev => ({...prev, messages: [...prev.messages, {userName: senderName, messageText: messageText}]}));
    }

    useEffect(() => {
        getChat();

        const signalRService = new PrivateChatSignalRService(onAddMsgInPrivateChat);
        signalRService.start();
        console.log('conn to privatechat:', signalRService.connection);

        return () => signalRService.stop();
    }, [params.chatId])



    // useEffect(() => {
    //     document.getElementById(msgs.msgs_wrapper)!
    //     .scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down
    // }, []);

    const getChat = async () => {
        const response = await $api.get<IPrivateChat>(`chats/getprivatechat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    return (
        <div className={msgs.messages_panel}>
            <Header userName={chat.userName} conStatus={chat.connectionStatus}/>
            <MessagesList messages={chat.messages}/>
            <Footer/>
        </div>
    );
}

export default PrivateChat;