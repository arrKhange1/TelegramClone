import React, { useEffect } from 'react';
import classes from '../../styles/home/home.module.css';
import {resize} from '../../services/ResizeService';

function Home() { 

    return (
        <div className={classes.home}>
            <div className={classes.chat_panel}> 
                
                <div className={classes.search}></div>
                
                <div className={classes.chats}>
                    {[...Array<string>(1000)].map((chat,i) => 
                        <div key={i}>#WELCOMETOCHATSВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВВ</div>
                    )}
                </div>
            </div>
            
            <div className={classes.border} onMouseDown={resize}></div>

            <div className={classes.messages_panel}>

            </div>

        </div>
    );
}

export default Home;