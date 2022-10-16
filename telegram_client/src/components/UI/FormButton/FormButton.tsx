import React from 'react';
import classes from './FormButton.module.css';

function FormButton({children, type, onClick} : {children: string,
    type: any ,onClick: () => void}
    ) {
    return (
        <button 
         type={type}
         className={classes.butt}
         onClick={onClick}
         >{children}</button>
    );
}

export default FormButton;