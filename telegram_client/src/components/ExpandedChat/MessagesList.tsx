import React from 'react';
import { useParams } from 'react-router-dom';
import { IMessage } from '../../@types/IExpandedChat';
import home from '../../styles/home/home.module.css';
import msgs from '../../styles/messages_panel/messages.module.css';
import Message from './Message';

function MessagesList({messages} : {messages: IMessage[]}) {
    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    return (
        <div id={msgs.msgs_wrapper} className={custom_scroll}>
            <div className={msgs.msgs}>
                {messages.length ? messages.map(msg => 
                    <Message msg={msg}/>
                ) : <div>no messages</div>}
            </div>
        </div>
    );
}

export default MessagesList;