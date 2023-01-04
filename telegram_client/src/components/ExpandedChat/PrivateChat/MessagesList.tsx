import React, { useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import { IMessage } from '../../../@types/IExpandedChat';
import home from '../../../styles/home/home.module.css';
import msgs from '../../../styles/messages_panel/messages.module.css';
import Message from './Message';

function MessagesList({messages} : {messages: IMessage[]}) {
    const customScroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const msgsWrapper = useRef<HTMLDivElement>(null);

    useEffect(() => {
        requestAnimationFrame(() => {
            msgsWrapper.current!.scrollTo(0, msgsWrapper.current!.scrollHeight)
        });
    }, [messages])


    return (
        <div ref={msgsWrapper} id={msgs.msgs_wrapper} className={customScroll}>
            <div className={msgs.msgs}>
                {messages && messages.length ? messages.map((msg, i) => 
                   <Message key={i} msg={msg} prevMsg={i > 0 ? messages[i-1] : msg}/> 
                ) : <div>no messages</div>}
            </div>
        </div>
    );
}

export default MessagesList;