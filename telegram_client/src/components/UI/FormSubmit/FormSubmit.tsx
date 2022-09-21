import React from 'react';
import classes from './FormSubmit.module.css';

function FormSubmit({children, onClick} : {children: string,
    onClick: () => void}
    ) {
    return (
        <button type='button'
         className={classes.butt}
         onClick={onClick}
         >{children}</button>
    );
}

export default FormSubmit;