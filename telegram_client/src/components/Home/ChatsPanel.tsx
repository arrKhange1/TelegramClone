import React from 'react';
import { Link } from 'react-router-dom';
import chats from '../../styles/chats_panel/chats.module.css';
import home from '../../styles/home/home.module.css';

function ChatsPanel() {

    const custom_scroll: string = ' ' + home.bar_back + ' ' + home.bar_thumb;

    return (
        <div className={chats.chat_panel}> 
                
            <div className={chats.search}></div>
            
            <div className={chats.chats + custom_scroll}>
                {[...Array<string>(1000)].map((chat,i) => 
                    <Link to={'/' + i}>#WELCOMETOCHATS</Link>
                )}
            </div>
        </div>
    );
}

export default ChatsPanel;