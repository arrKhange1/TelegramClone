import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat, IPrivateChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import PrivateChatSignalRService from '../../../services/PrivateChatSignalRService';
import { useAuth } from '../../../hooks/useAuth';
import ChatsService from '../../../services/ChatsService';
import { useAppSelector } from '../../../hooks/useAppSelector';
import { cleanChatUnreadMsgs, setChats } from '../../../store/reducers/chatListSlice';
import IChat from '../../../@types/IChat';
import { useDispatch } from 'react-redux';
import IPrivateChatMessage from '../../../@types/PrivateChatDTO/IPrivateChatMessage';

function PrivateChat() {
    const params = useParams();
    const user = useAuth();
    const chats = useAppSelector(state => state.chatsReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const closeChat = (e:KeyboardEvent) => {
        if (e.key === 'Escape')
            navigate('/');
    }

    const [chat, setChat] = useState<IPrivateChat>({
        userName: '',
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

        window.addEventListener('keydown', closeChat);

        return () => { 
            signalRService.stop();
            window.removeEventListener('keydown', closeChat);
        }
    }, [params.chatId])

    useEffect(() => {
        const response = ChatsService.readPrivateChat(user.userId, params.chatId!);
        dispatch(cleanChatUnreadMsgs(params.chatId!));

    }, [chat, params.chatId])

    const getChat = async () => {
        const response = await $api.get<IPrivateChat>(`chats/getprivatechat?fromId=${user.userId}&toId=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    const sendMsg = async (e:React.MouseEvent<HTMLDivElement>) => {
        const privateChatMessage: IPrivateChatMessage = {
            fromId: user.userId,
            toId: params.chatId!,
            toName: chat.userName,
            messageText: textMsg
        }
        const response = await $api.post('chats/sendprivatechat', privateChatMessage);
        setTextMsg('');
        console.log(response.data)
    };

    return (
        <div className={msgs.messages_panel}>
            <Header userName={chat.userName}/>
            <MessagesList messages={chat.messages}/>
            <Footer textMsg={textMsg} sendMsg={sendMsg} setTextMsg={setTextMsg}/>
        </div>
    );
}

export default PrivateChat;