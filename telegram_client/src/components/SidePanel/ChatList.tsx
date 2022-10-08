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

let signalRService: SignalRService;
function ChatList({modal, setModal} : { modal: boolean,
    setModal: React.Dispatch<React.SetStateAction<boolean>> }) {

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    const [chats, setChats] = useState<IChat[]>([]);
        // dodelat frontend

    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState<string>(chatId);
    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    useEffect(() => {
        (async function connEstablish() {
            if (signalRService)
                await signalRService.stop();
            signalRService = new SignalRService();
            await signalRService.start();
            await signalRService.connection.on('addGroupChat', (chatName: string) => {
                console.log(chatName);
            });
        })();



        return () => { signalRService.stop() };
    }, [])

    return (
        <div className={side.chats + custom_scroll}>
            <button type='button' onClick={() => $api.post('/chats/testchats')}>chats</button>
            {chats.map((chat,index) => 
                <Link to={chat.name} key={index} className={side.chat_open_link}
                onClick={() => 
                    setActiveChat(chat.name)
                } >
                    <ChatListElement activeChat={activeChat} chat={chat}/>
                </Link>
            )}
            
            <ModalWindow modal={modal} setModal={setModal}>
                <ChatsAddForm
                 setModal={setModal}
                />
            </ModalWindow>
        </div>
    );
}

export default ChatList;