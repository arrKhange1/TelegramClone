import React from 'react';
import msgsHeader from '../../../styles/messages_panel/header.module.css';
import Controls from '../Controls';

function Header({userName, conStatus} : {userName: string,
    conStatus: string}) {

    return (
        <div className={msgsHeader.header}>
            <div className={msgsHeader.info}>
                <img src="imgs/contacts_icon.png" alt="" className={msgsHeader.info_img} />
                <div className={msgsHeader.info_text}>
                    <div>{userName}</div>
                    <div>{conStatus}</div>
                </div>
            </div>
            <Controls/>
        </div>
    );
}

export default Header;