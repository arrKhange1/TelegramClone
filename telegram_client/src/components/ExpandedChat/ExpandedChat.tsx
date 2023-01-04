import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useAppSelector } from '../../hooks/useAppSelector';
import PrivateChat from './PrivateChat/PrivateChat';
import GroupChat from './GroupChat/GroupChat';

function ExpandedChat() {
    const chatId = useParams().chatId;
    const chatList = useAppSelector(state => state.chatsReducer);
    const contactList = useAppSelector(state => state.contactListReducer);

    if (contactList.some(contact => contact.contactId === chatId) ||
         chatList.find(chat => chat.chatId === chatId)?.chatCategory === 'private') {
        return <PrivateChat/>;
    }
    else if (chatList.some(chat => chat.chatId === chatId)) {
        return <GroupChat/>;
    }
    return <div>Page unavailable</div>;
}

export default ExpandedChat;