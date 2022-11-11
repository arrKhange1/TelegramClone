import React, { useEffect, useState } from 'react';
import msgs from '../../styles/messages_panel/messages.module.css';
import { useNavigate, useParams } from 'react-router-dom';
import IChat from '../../@types/IChat';
import Header from './GroupChat/Header';
import Footer from './Footer';
import SignalRService from '../../services/SignalRService';
import { $api } from '../../http/axios';
import { useAuth } from '../../hooks/useAuth';
import IExpandedChat from '../../@types/IExpandedChat';
import MessagesList from './MessagesList';
import { useAppSelector } from '../../hooks/useAppSelector';
import PrivateChat from './PrivateChat/PrivateChat';
import GroupChat from './GroupChat/GroupChat';

function ExpandedChat() {
    const navigate = useNavigate();
    const chatId = useParams().chatId;
    const chatList = useAppSelector(state => state.chatsReducer);
    const contactList = useAppSelector(state => state.contactListReducer);

    const closeChat = (e:KeyboardEvent) => {
        if (e.key === 'Escape')
            navigate('/');
    }

    if (contactList.some(contact => contact.contactId === chatId))
        return <PrivateChat/>;
    else if (chatList.some(chat => chat.chatId === chatId))
        return <GroupChat/>;
    return <div>Page unavailable</div>;
}

export default ExpandedChat;