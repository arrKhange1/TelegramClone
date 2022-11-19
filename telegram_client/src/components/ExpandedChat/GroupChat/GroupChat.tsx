import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import GroupChatSignalRService from '../../../services/GroupChatSignalRService';
import { useAuth } from '../../../hooks/useAuth';

function GroupChat() {
    const params = useParams();
    const user = useAuth();

    const [chat, setChat] = useState<IGroupChat>({
        chatName: '',
        groupMembers: 0,
        messages: []
    });
    const  [textMsg, setTextMsg] = useState('');

    function onAddMsgInGroupChat(senderName: string, messageText: string, chatId: string) {
        if (chatId === params.chatId)
            setChat(prev => ({...prev, messages: [...prev.messages, {userName: senderName, messageText: messageText, messageType: "message"}]}));
    }

    useEffect(() => {
        getChat();

        const signalRService = new GroupChatSignalRService(onAddMsgInGroupChat);
        signalRService.start();
        console.log('conn to groupchat:', signalRService.connection);

        return () => signalRService.stop();
    }, [params.chatId])

    const getChat = async () => {
        const response = await $api.get<IGroupChat>(`chats/getgroupchat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    const sendMsg = async (e: React.MouseEvent<HTMLDivElement>) => {
        const response = await $api.post(`chats/sendgroupchat?chatId=${params.chatId}&senderId=${user.userId}&messageText=${textMsg}`);
        console.log(response.data)
    };

    return (
        <div className={msgs.messages_panel}>
            <Header chatName={chat.chatName} groupMembers={chat.groupMembers}/>
            <MessagesList messages={chat.messages}/>
            <Footer textMsg={textMsg} sendMsg={sendMsg} setTextMsg={setTextMsg}/>
        </div>
    );
}

export default GroupChat;