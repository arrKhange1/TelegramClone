import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import GroupChatSignalRService from '../../../services/GroupChatSignalRService';

function GroupChat() {
    const params = useParams();

    const [chat, setChat] = useState<IGroupChat>({
        chatName: '',
        groupMembers: 0,
        messages: []
    });

    function onAddMsgInGroupChat(senderName: string, messageText: string) {
        setChat(prev => ({...prev, messages: [...prev.messages, {userName: senderName, messageText: messageText}]}));
    }

    useEffect(() => {
        getChat();

        const signalRService = new GroupChatSignalRService(onAddMsgInGroupChat);
        signalRService.start();
        console.log('conn to groupchat:', signalRService.connection);

        return () => signalRService.stop();
    }, [params.chatId])

    useEffect(() => {
        
        document.getElementById(msgs.msgs_wrapper)!
        .scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down
    }, []);

    const getChat = async () => {
        const response = await $api.get<IGroupChat>(`chats/getgroupchat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    return (
        <div className={msgs.messages_panel}>
            <Header chatName={chat.chatName} groupMembers={chat.groupMembers}/>
            <MessagesList messages={chat.messages}/>
            <Footer/>
        </div>
    );
}

export default GroupChat;