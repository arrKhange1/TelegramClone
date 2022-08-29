import React, { useEffect, useState } from 'react';
import IChat from '../../@types/IChat';
import side from '../../styles/side_panel/side.module.css';
import { useParams } from 'react-router-dom';
import IContact from '../../@types/IContact';

function ContactListElement({activeChat, contact} : {activeChat: string,
    contact: IContact}) {
    
    return (
        <div className={activeChat === contact.name ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <img src={contact.img} className={side.chat_img} alt='asap'/>
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{contact.name}</div>
                <div>{contact.last_seen}</div>
            </div>
        </div>
    );
}

export default ContactListElement;