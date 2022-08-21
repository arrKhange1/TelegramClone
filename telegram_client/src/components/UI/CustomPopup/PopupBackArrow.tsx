import React from 'react';
import popup from './CustomPopup.module.css';

function PopupBackArrow({setSelectedOption} : 
    {setSelectedOption:React.Dispatch<React.SetStateAction<string>>}) {
    return (
        <img src="imgs/back_arrow.png" 
        className={popup.butt} 
        alt="" 
        onClick={() => setSelectedOption('')}/>
    );
}

export default PopupBackArrow;