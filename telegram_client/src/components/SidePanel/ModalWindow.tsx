import React, { useEffect, useState } from 'react';
import side from '../../styles/side_panel/side.module.css';

function ModalWindow({children} : {children : JSX.Element}) {
    
    return (
        <div className={side.modal}>
            {children}
        </div>
    )
}

export default ModalWindow;