import React from 'react';
import popup from './CustomPopup.module.css';

function PopupElement({img, text, onClick} : {img: string, text: string,
    onClick: any}) {
    return (
        <div onClick={onClick} className={popup.element}>
            <div>{img}</div>
            <div>{text}</div>
        </div>
    );
}

export default PopupElement;