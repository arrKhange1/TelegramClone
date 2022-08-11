import React, { useEffect } from 'react';
import chats from '../../styles/chats_panel/chats.module.css';
import home from '../../styles/home/home.module.css';
import msgs from '../../styles/messages_panel/messages.module.css';
import {resize} from '../../services/ResizeService';

function Home() { 

    useEffect(() => {
        document.getElementById(msgs.msgs_wrapper)!.scrollTo(0, document.getElementById(msgs.msgs_wrapper)!.scrollHeight); // auto scrollin user down
    }, []);

    const custom_scroll: string = ' ' + home.bar_back + ' ' + home.bar_thumb;


    // TODO: decompose, aight?
    return (
        <div className={home.home}>
            <div className={chats.chat_panel}> 
                
                <div className={chats.search}></div>
                
                <div className={chats.chats + custom_scroll}>
                    {[...Array<string>(1000)].map((chat,i) => 
                        <div key={i}>#WELCOMETOCHATS</div>
                    )}
                </div>
            </div>
            
            <div className={home.border} onMouseDown={resize}></div>

            <div className={msgs.messages_panel}>
                <div className={msgs.msgs_header}>HEADER OF CHAT</div>
                <div id={msgs.msgs_wrapper} className={custom_scroll}>
                    <div className={msgs.msgs}>
                        {[...Array<string>(1000)].map((chat,i) => 
                            <div key={i}>#WELCOMETOMESSAGES</div>
                        )}
                    </div>
                </div>
                <div className={msgs.msgs_footer}>FOOTER OF CHAT</div>
                
            </div>
            

            
        </div>
    );
}

export default Home;