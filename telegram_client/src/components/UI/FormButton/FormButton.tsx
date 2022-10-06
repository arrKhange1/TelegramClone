import React from 'react';
import classes from './FormButton.module.css';

function FormButton({children, onClick} : {children: string,
    onClick: () => void}
    ) {
    return (
        <button type='submit'
         className={classes.butt}
         onClick={onClick}
         >{children}</button>
    );
}

export default FormButton;