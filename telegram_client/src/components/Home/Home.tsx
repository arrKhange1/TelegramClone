import React, { useEffect } from 'react';
import chats from '../../styles/chats_panel/chats.module.css';
import home from '../../styles/home/home.module.css';
import msgs from '../../styles/messages_panel/messages.module.css';
import {resize} from '../../services/ResizeService';
import Chat from './Chat';
import ChatsPanel from './ChatsPanel';
import { Outlet } from 'react-router-dom';

function Home() { 

    return (
        <div className={home.home}>

            <ChatsPanel/>
            <div className={home.border} onMouseDown={resize}></div>
            <Outlet/>

        </div>
    );
}

export default Home;