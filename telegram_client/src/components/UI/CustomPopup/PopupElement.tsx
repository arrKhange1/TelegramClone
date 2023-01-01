import React from 'react';
import ContactIcon from '../../../icons/ContactIcon';
import popup from './CustomPopup.module.css';

function PopupElement({ text, onClick} :
     { text: string, onClick: () => void}) {
    return (
        <div onClick={onClick} className={popup.element}>
            <ContactIcon className={popup.contact_icon}/>
            <div>{text}</div>
        </div>
    );
}

export default PopupElement;