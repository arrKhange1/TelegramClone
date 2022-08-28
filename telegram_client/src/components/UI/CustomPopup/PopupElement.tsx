import React from 'react';
import popup from './CustomPopup.module.css';

function PopupElement({img, text, onClick} :
     {img: string, text: string, onClick: () => void}) {
    return (
        <div onClick={onClick} className={popup.element}>
            <img src={img} alt="contacts" />
            <div>{text}</div>
        </div>
    );
}

export default PopupElement;