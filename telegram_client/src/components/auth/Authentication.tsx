import React from 'react';
import { Outlet } from 'react-router-dom';
import classes from '../../styles/auth/auth.module.css';

function Authentication() {

    return (
        <div className={classes.auth}>
            <img  src="/imgs/telegram_logo.png"
             alt="Telegram Logo"
             className={classes.tg_logo}
             />
            <Outlet/>
        </div>
    );
}

export default Authentication;