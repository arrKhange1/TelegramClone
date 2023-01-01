import React from 'react';
import ContactIcon from '../../../icons/ContactIcon';
import msgsHeader from '../../../styles/messages_panel/header.module.css';
import Controls from '../Controls';

function Header({userName} : {userName: string}) {

    return (
        <div className={msgsHeader.header}>
            <div className={msgsHeader.info}>
                <ContactIcon className={msgsHeader.info_img} />
                <div className={msgsHeader.info_text}>
                    <div>{userName}</div>
                    <div></div>
                </div>
            </div>
            <Controls/>
        </div>
    );
}

export default Header;