import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import IExpandedChat, { IGroupChat } from '../../../@types/IExpandedChat';
import { $api } from '../../../http/axios';
import Footer from '../Footer';
import Header from './Header';
import MessagesList from '../MessagesList';
import msgs from '../../../styles/messages_panel/messages.module.css';
import GroupChatSignalRService from '../../../services/GroupChatSignalRService';
import { useAuth } from '../../../hooks/useAuth';
import ChatsService from '../../../services/ChatsService';
import IChat from '../../../@types/IChat';
import { useAppSelector } from '../../../hooks/useAppSelector';
import { useDispatch } from 'react-redux';
import { cleanChatUnreadMsgs, setChats } from '../../../store/reducers/chatListSlice';
import IGroupChatMessage from '../../../@types/PrivateChatDTO/IGroupChatMessage';

function GroupChat() {
    const params = useParams();
    const user = useAuth();
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const closeChat = (e:KeyboardEvent) => {
        if (e.key === 'Escape')
            navigate('/');
    }

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

        window.addEventListener('keydown', closeChat);

        return () =>  {
            signalRService.stop();
            window.removeEventListener('keydown', closeChat);
        }
    }, [params.chatId])

    useEffect(() => {
        const response = ChatsService.readGroupChat(user.userId, params.chatId!);
        dispatch(cleanChatUnreadMsgs(params.chatId!));

    }, [chat, params.chatId])

    const getChat = async () => {
        const response = await $api.get<IGroupChat>(`chats/getgroupchat?chatid=${params.chatId}`);
        console.log(response.data)
        setChat(response.data)
    }

    const sendMsg = async (e: React.MouseEvent<HTMLDivElement>) => {
        const groupChatMessage: IGroupChatMessage = {
            chatId: params.chatId!,
            senderId: user.userId,
            messageText: textMsg
        }
        const response = await $api.post('chats/sendgroupchat', groupChatMessage);
        setTextMsg('');
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