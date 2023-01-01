import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { IOption } from '../../../@types/IOption';
import BurgerIcon from '../../../icons/BurgerIcon';
import popup from './CustomPopup.module.css';
import PopupElement from './PopupElement';

function CustomPopup({setSelectedOption, options} : {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    options:IOption[]}) {
    
    const [isActive, setIsActive] = useState<boolean>(false);

    return (
        <div>
            <div className={popup.popup}>
                <button
                    className={popup.butt}
                    onClick={(e:React.MouseEvent<HTMLButtonElement>) => {setIsActive(true); e.stopPropagation()}}
                >
                    <BurgerIcon className={popup.burger_icon} />
                </button>
                
                <div className={isActive ? `${popup.content} ${popup.active}` :
                    popup.content}>
                    {options.map((option,i) => 
                        <PopupElement key={i}  text={option.name} onClick={() => { setSelectedOption(option.name); setIsActive(false)}}/>    
                    )}
                </div>
                
            </div>
            <div className={isActive ? popup.backdrop : ''} onClick={() => { setIsActive(false) }}>
            </div>
        </div>
        
        
    );
}

export default CustomPopup;