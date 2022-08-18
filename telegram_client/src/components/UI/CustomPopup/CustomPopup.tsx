import React, { useState } from 'react';
import { IOption } from '../../../@types/IOption';
import popup from './CustomPopup.module.css';
import PopupElement from './PopupElement';

function CustomPopup({setSelectedOption, options} : {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    options:IOption[]}) {
    
    const [isActive, setIsActive] = useState(false);

    const activePopup: string[] = [popup.content];
    if (isActive)
        activePopup.push(popup.active);

    return (
        <div>
            <div className={popup.popup}>
                <button 
                    type='button' 
                    className={popup.butt}
                    onClick={(e:any) => { setIsActive(true); e.stopPropagation() } }
                    >
                    popup
                </button>
                <div className={activePopup.join(' ')}>
                    {options.map(option => 
                        <PopupElement img='img' text={option.name} onClick={(e:any) => { setSelectedOption(option.name); setIsActive(false)}}/>    
                    )}
                </div>
                
            </div>
            <div className={isActive ? popup.backdrop : ''} onClick={(e:any) => { setIsActive(false) }}>
            </div>
        </div>
        
        
    );
}

export default CustomPopup;