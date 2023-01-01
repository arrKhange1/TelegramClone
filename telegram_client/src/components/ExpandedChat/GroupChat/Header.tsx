import React from 'react';
import ContactIcon from '../../../icons/ContactIcon';
import msgsHeader from '../../../styles/messages_panel/header.module.css';
import Controls from '../Controls';

function Header({chatName, groupMembers} : {chatName: string,
    groupMembers: number}) {

    return (
        <div className={msgsHeader.header}>
            <div className={msgsHeader.info}>
                <ContactIcon className={msgsHeader.info_img} />
                <div className={msgsHeader.info_text}>
                    <div>{chatName}</div>
                    <div>{groupMembers} members</div>
                </div>
            </div>
            <Controls/>
        </div>
    );
}

export default Header;