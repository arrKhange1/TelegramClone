import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { IOption } from '../../../@types/IOption';
import popup from './CustomPopup.module.css';
import PopupElement from './PopupElement';

function CustomPopup({setSelectedOption, options} : {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    options:IOption[]}) {
    
    const [isActive, setIsActive] = useState<boolean>(false);

    return (
        <div>
            <div className={popup.popup}>
                <img src="imgs/burger_icon.png" 
                className={popup.butt} 
                alt=""
                onClick={(e:React.MouseEvent<HTMLDivElement>) => {setIsActive(true); e.stopPropagation()}}
                />
                
                <div className={isActive ? `${popup.content} ${popup.active}` :
                    popup.content}>
                    {options.map((option,i) => 
                        <PopupElement key={i} img={option.img} text={option.name} onClick={() => { setSelectedOption(option.name); setIsActive(false)}}/>    
                    )}
                </div>
                
            </div>
            <div className={isActive ? popup.backdrop : ''} onClick={() => { setIsActive(false) }}>
            </div>
        </div>
        
        
    );
}

export default CustomPopup;