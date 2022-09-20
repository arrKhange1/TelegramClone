import React, { useEffect, useState } from 'react';
import side from '../../styles/side_panel/side.module.css';

function ModalWindow({modal, setModal, children} : {children : JSX.Element, 
    modal: boolean, setModal: React.Dispatch<React.SetStateAction<boolean>> }) {
    
    return (
        <div className={modal ? `${side.modal} ${side.modal__active}` :
            side.modal} onClick={() => setModal(false)}>
            <div onClick={(e:React.MouseEvent<HTMLDivElement>) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    )
}

export default ModalWindow;