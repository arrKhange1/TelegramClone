import React, { useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import { IMessage } from '../../@types/IExpandedChat';
import home from '../../styles/home/home.module.css';
import msgs from '../../styles/messages_panel/messages.module.css';
import Message from './GroupChat/Message';

function MessagesList({messages} : {messages: IMessage[]}) {
    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;
    const msgs_wrapper = useRef<HTMLDivElement>(null);

    useEffect(() => {
        // msgs_wrapper.current!.scroll(0, msgs_wrapper.current!.scrollHeight);
        // setTimeout(() => msgs_wrapper.current!.scrollTo(0, msgs_wrapper.current!.scrollHeight), 500);
        requestAnimationFrame(() => msgs_wrapper.current!.scrollTo(0, msgs_wrapper.current!.scrollHeight));
        console.log(msgs_wrapper.current!.scrollTop, msgs_wrapper.current!.scrollHeight);
    }, [messages])

    return (
        <div ref={msgs_wrapper} id={msgs.msgs_wrapper} className={custom_scroll}>
            <div className={msgs.msgs}>
                {messages.length ? messages.map(msg => 
                    <Message msg={msg}/>
                ) : <div>no messages</div>}
            </div>
        </div>
    );
}

export default MessagesList;