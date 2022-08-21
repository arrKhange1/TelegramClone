import React from 'react';
import { Link } from 'react-router-dom';
import home from '../../styles/home/home.module.css';
import side from '../../styles/side_panel/side.module.css';

function Chats() {

    const custom_scroll: string = ' ' + home.bar_back + ' ' + home.bar_thumb;

    return (
        <div className={side.chats + custom_scroll}>
            {[...Array<string>(1000)].map((chat,i) => 
                    <Link key={i} to={'/' + i}>#WELCOMETOCHATS</Link>
            )}
        </div>
    );
}

export default Chats;