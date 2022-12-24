import React, { useEffect, useState } from 'react';
import IChat from '../../@types/IChat';
import side from '../../styles/side_panel/side.module.css';
import { useParams } from 'react-router-dom';
import IContact from '../../@types/IContact';

function ContactListElement({activeChat, contact} : {activeChat: string,
    contact: IContact}) {
    
    return (
        <div className={activeChat === contact.contactId ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <img src="imgs/contacts_icon.png" alt="" className={side.chat_img} />
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{contact.contactName}</div>
                <div></div>
            </div>
        </div>
    );
}

export default ContactListElement;