import React from 'react';
import { useNavigate } from 'react-router-dom';
import BackArrowIcon from '../../../icons/BackArrowIcon';
import popup from './CustomPopup.module.css';

function PopupBackArrow({setSelectedOption} : 
    {setSelectedOption:React.Dispatch<React.SetStateAction<string>>}) {

    return (
        <button
        className={popup.butt} 
        onClick={() => {setSelectedOption('')}}
        >
            <BackArrowIcon className={popup.back_arrow_icon} />
        </button>
    );
}

export default PopupBackArrow;