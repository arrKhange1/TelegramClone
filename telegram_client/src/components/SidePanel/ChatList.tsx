import React, { useEffect, useMemo, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import home from '../../styles/home/home.module.css';
import side from '../../styles/side_panel/side.module.css';
import ChatListElement from './ChatListElement';
import IChat from '../../@types/IChat';
import ModalWindow from './ModalWindow';
import ChatsAddForm from './ChatsAddForm';
import ChatsService from '../../services/ChatsService';
import { useAuth } from '../../hooks/useAuth';
import ChatListSignalRService from '../../services/ChatListSignalRService';
import { useAppSelector } from '../../hooks/useAppSelector';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { setChats, addToChats, replaceExistingChat } from '../../store/reducers/chatListSlice';
import { setChatsSearchText, setContactsSearchText } from '../../store/reducers/sidePanelSearchInputSlice';
import ISearchText from '../../@types/ISearchText';


function ChatList({modal, setModal} : { modal: boolean,
    setModal: React.Dispatch<React.SetStateAction<boolean>> }) {

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const user = useAuth();
    const dispatch = useAppDispatch();

    const chats = useAppSelector(state => state.chatsReducer);
    const searchInput: ISearchText = useAppSelector(state => state.sidePanelSearchInputReducer);
    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState<string>(chatId);

    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    const fetchChats = async () => {
        const response = await ChatsService.getChats(user.userId);
        dispatch(setChats([...response.data]));
    }

    const onAddGroupChat = (groupName: string, chatId: string, senderName: string) => {
        dispatch(addToChats({chatId: chatId, chatName: groupName, chatCategory: 'group', lastMessageSender: senderName,
            lastMessageText: "created a chat!", lastMessageTime: new Date(Date.now()).toDateString(), lastMessageType: "notification", unreadMsgs: 1}));
        dispatch(setChatsSearchText(''));
    }

    const onNewMsgInChat = (chatElement: IChat) => {
        dispatch(replaceExistingChat(chatElement));
    }

    useEffect(() => {
        dispatch(setContactsSearchText(''));
        fetchChats();

        const signalRService = new ChatListSignalRService(onAddGroupChat, onNewMsgInChat);
        signalRService.start(); // TODO: share fetchcontacts() with signalr listener
        
        return () => signalRService.stop();
    }, [])

    const filteredChats = useMemo(() => {
        return chats.filter(chat => chat.chatName.includes(searchInput.chatsSearchText));
    }, [searchInput.chatsSearchText, chats]);

    return (
        <div className={side.chats + custom_scroll}>
            {filteredChats.length ? filteredChats.map(chat => 
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