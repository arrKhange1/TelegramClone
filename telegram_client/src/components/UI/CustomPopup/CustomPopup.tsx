import React, { useState } from 'react';
import popup from './CustomPopup.module.css';
import PopupElement from './PopupElement';

function CustomPopup({setIsContacts} : { 
    setIsContacts:any}) {
    
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
                {/* content */}
                <div className={activePopup.join(' ')}>
                    <PopupElement img='img' text='Contacts' onClick={(e:any) => { setIsContacts(true); setIsActive(false)}}/>
                </div>
                
            </div>
            <div className={isActive ? popup.backdrop : ''} onClick={(e:any) => { setIsActive(false) }}>
            </div>
        </div>
        
        
    );
}

export default CustomPopup;