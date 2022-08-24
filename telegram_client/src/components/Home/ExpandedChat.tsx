import React, { useEffect } from 'react';
import msgs from '../../styles/messages_panel/messages.module.css';
import home from '../../styles/home/home.module.css';
import { useNavigate, useParams } from 'react-router-dom';

function Chat(props:any ) {

    const params = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        document.getElementById(msgs.msgs_wrapper)!.scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down
    }, []);

    const custom_scroll: string = ' ' + home.bar_back + ' ' + home.bar_thumb;

    return (

        <div className={msgs.messages_panel}>
            <div className={msgs.msgs_header}>HEADER OF CHAT</div>
            <div id={msgs.msgs_wrapper} className={custom_scroll}>
                <div className={msgs.msgs}>
                    {[...Array<string>(100)].map((chat,i) => 
                        <div key={i}>#WELCOMETOMESSAGES FROM CHAT ID: {params.chatId}</div>
                    )}
                </div>
            </div>
            <div className={msgs.msgs_footer}>FOOTER OF CHAT</div>
        </div>
    );
}

export default Chat;