import React, { useEffect, useState } from 'react';
import msgs from '../../styles/messages_panel/messages.module.css';
import { useNavigate, useParams } from 'react-router-dom';
import IChat from '../../@types/IChat';
import Header from './Header';
import Footer from './Footer';
import SignalRService from '../../services/SignalRService';
import { $api } from '../../http/axios';
import { useAuth } from '../../hooks/useAuth';
import IExpandedChat from '../../@types/IExpandedChat';
import MessagesList from './MessagesList';

// let signalRService : SignalRService;
function ExpandedChat() {

    const params = useParams();
    const user = useAuth();
    const navigate = useNavigate();

    const [chat, setChat] = useState<IExpandedChat>({
        chatName: '',
        chatStatus: '',
        messages: []
    })

    // here might be request for chat by chatId from url params 
    useEffect(() => {
        getChat();
    }, [params.chatId])


    const closeChat = (e:KeyboardEvent) => {
        if (e.key === 'Escape')
            navigate('/');
    }

    const getChat = async () => {
        const response = await $api.get<IExpandedChat>(`chats/getchat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    useEffect(() => {
        document.getElementById(msgs.msgs_wrapper)!
        .scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down
    }, []);

    return (

        <div className={msgs.messages_panel}>
            {/* dev purposes */}
            <Header chatName={chat.chatName} chatStatus={chat.chatStatus}/>
            <MessagesList messages={chat.messages}/>
            <Footer/>
        </div>
    );
}

export default ExpandedChat;