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

let signalRService: SignalRService;
function ChatList({modal, setModal} : { modal: boolean,
    setModal: React.Dispatch<React.SetStateAction<boolean>> }) {

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    const chats: IChat[] = [
        {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Vitya', last_msg:'last_msg1sdsqwqwqwwwwwwwwwwwwwwwwwwwwww',
         last_msg_date:'last_msg_date1', unread_msgs:100},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name2', last_msg:'last_msg2',
         last_msg_date:'last_msg_date2', unread_msgs:2},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name3', last_msg:'last_msg3',
         last_msg_date:'last_msg_date3', unread_msgs:3},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name4', last_msg:'last_msg4',
         last_msg_date:'last_msg_date4', unread_msgs:4},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name6', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name7', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name8', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name9', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name10', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name11', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
         {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name15', last_msg:'last_msg5',
         last_msg_date:'last_msg_date5', unread_msgs:5},
    ]

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
            await signalRService.connection.on('Chat', () => {
            console.log('broadcast to chats');
            });
        })()
        return () => { signalRService.stop() };
    }, [])

    const addGroupChat = () => {

    }

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
            
            {/* <ModalWindow modal={modal} setModal={setModal}>
                <ContactsAddForm
                 setModal={setModal}
                 cb={addGroupChat}
                />
            </ModalWindow> */}
        </div>
    );
}

export default ChatList;