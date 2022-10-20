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

// let signalRService: SignalRService;

function ChatList({modal, setModal} : { modal: boolean,
    setModal: React.Dispatch<React.SetStateAction<boolean>> }) {

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const user = useAuth();

    const [chats, setChats] = useState<IChat[]>([]);
    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState<string>(chatId);

    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    const fetchChats = async () => {
        const response = await ChatsService.getChats(user.userId);
        console.log(response);
        setChats([...response.data]);
    }

    const callback = (groupName: string) => {
        console.log('chat added:', chats, groupName)
        fetchChats();
    }

    useEffect(() => {

        fetchChats();

        const signalRService = new SignalRService();
        signalRService.start();

        
        console.log('conn:', signalRService.connection);
        return () => signalRService.stop();
    }, [])


    return (
        <div className={side.chats + custom_scroll}>
            <button type='button' onClick={() => $api.post('/chats/testchats')}>chats</button>
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