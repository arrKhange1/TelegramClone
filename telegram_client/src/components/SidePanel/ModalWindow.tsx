import React, { useEffect, useState } from 'react';
import side from '../../styles/side_panel/side.module.css';

function ModalWindow({modal, setModal, children} : {children : JSX.Element, 
    modal: boolean, setModal: React.Dispatch<React.SetStateAction<boolean>> }) {
    
    return (
        <div className={modal ? `${side.modal} ${side.modal__active}` :
            side.modal} onMouseDown={(e: any) => e.target.classList.contains(`${side.modal__active}`) && setModal(false)}>
                {children}
        </div>
    )
}

export default ModalWindow;