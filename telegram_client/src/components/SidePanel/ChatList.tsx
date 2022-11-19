import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import home from '../../styles/home/home.module.css';
import side from '../../styles/side_panel/side.module.css';
import ChatListElement from './ChatListElement';
import IChat from '../../@types/IChat';
import AddButton from './AddButton';
import AddContactIcon from '../../icons/AddContactIcon';
import ModalWindow from './ModalWindow';
import ContactsAddForm from './ContactsAddForm';
import SignalRService from '../../services/SignalRService';
import { $api } from '../../http/axios';
import ChatsAddForm from './ChatsAddForm';
import ChatsService from '../../services/ChatsService';
import { useAuth } from '../../hooks/useAuth';
import refreshPromise from '../../http/refreshTokenPromise'
import ChatListSignalRService from '../../services/ChatListSignalRService';
import { useAppSelector } from '../../hooks/useAppSelector';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { setChats, addToChats } from '../../store/reducers/chatListSlice';

// let signalRService: SignalRService;

function ChatList({modal, setModal} : { modal: boolean,
    setModal: React.Dispatch<React.SetStateAction<boolean>> }) {

    console.log('in chatlist:', refreshPromise);

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const user = useAuth();
    const dispatch = useAppDispatch();

    const chats = useAppSelector(state => state.chatsReducer);
    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState<string>(chatId);

    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    const fetchChats = async () => {
        const response = await ChatsService.getChats(user.userId);
        console.log(response);
        dispatch(setChats([...response.data]));
    }

    const onAddGroupChat = (groupName: string, chatId: string) => {
        console.log('chat added:', chats, groupName)
        dispatch(addToChats({chatId: chatId, chatName: groupName, chatCategory: 'group', lastMessageSender: user.userName,
            lastMessageText: "created a chat!", lastMessageTime: new Date(Date.now()).toDateString(), lastMessageType: "notification"}));
    }

    useEffect(() => {

        fetchChats();

        const signalRService = new ChatListSignalRService(onAddGroupChat);
        signalRService.start(); // TODO: share fetchcontacts() with signalr listener
        
        console.log('conn:', signalRService.connection);
        return () => signalRService.stop();
    }, [])


    return (
        <div className={side.chats + custom_scroll}>
            {chats.length ? chats.map(chat => 
                <Link to={chat.chatId} key={chat.chatId} className={side.chat_open_link}
                onClick={() => 
                    setActiveChat(chat.chatId)
                } >
                    <ChatListElement activeChat={activeChat} chat={chat}/>
                </Link>
            ) : <div>no chats</div>}
            
            <ModalWindow modal={modal} setModal={setModal}>
                <ChatsAddForm
                 setModal={setModal}
                 modal={modal}
                />
            </ModalWindow>
        </div>
    );
}

export default ChatList;