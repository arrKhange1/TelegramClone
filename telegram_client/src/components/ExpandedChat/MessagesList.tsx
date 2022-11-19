import React, { useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import { IMessage } from '../../@types/IExpandedChat';
import { useAuth } from '../../hooks/useAuth';
import home from '../../styles/home/home.module.css';
import msgs from '../../styles/messages_panel/messages.module.css';
import Message from './GroupChat/Message';
import Notification from './GroupChat/Notification';

function MessagesList({messages} : {messages: IMessage[]}) {
    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const msgs_wrapper = useRef<HTMLDivElement>(null);
    const user = useAuth();

    useEffect(() => {
        requestAnimationFrame(() => {
            msgs_wrapper.current!.scrollTo(0, msgs_wrapper.current!.scrollHeight)
        });
    }, [messages])

    return (
        <div ref={msgs_wrapper} id={msgs.msgs_wrapper} className={custom_scroll}>
            <div className={msgs.msgs}>
                {messages && messages.length ? messages.map(msg => 
                   msg.messageType === "message" ? <Message msg={msg}/> : <Notification msg={msg}/>
                ) : <div>no messages</div>}
            </div>
        </div>
    );
}

export default MessagesList;