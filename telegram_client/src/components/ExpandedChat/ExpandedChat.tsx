import React, { useEffect } from 'react';
import msgs from '../../styles/messages_panel/messages.module.css';
import home from '../../styles/home/home.module.css';
import { useNavigate, useParams } from 'react-router-dom';
import IChat from '../../@types/IChat';
import Header from './Header';
import Footer from './Footer';

function ExpandedChat() {

    const params = useParams();
    const navigate = useNavigate();

    // here might be request for chat by chatId from url params 

    const closeChat = (e:KeyboardEvent) => {
        if (e.key === 'Escape')
            navigate('/');
    }

    useEffect(() => {
        document.getElementById(msgs.msgs_wrapper)!
        .scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down

        window.addEventListener('keydown', closeChat);
        return () => window.removeEventListener('keydown', closeChat);
    }, []);

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    return (

        <div className={msgs.messages_panel}>
            <Header/>
            <div id={msgs.msgs_wrapper} className={custom_scroll}>
                <div className={msgs.msgs}>
                    {[...Array<string>(100)].map((chat,i) => 
                        <div key={i}>#WELCOMETOMESSAGES FROM CHAT ID: {params.chatId}</div>
                    )}
                </div>
            </div>
            <Footer/>
        </div>
    );
}

export default ExpandedChat;