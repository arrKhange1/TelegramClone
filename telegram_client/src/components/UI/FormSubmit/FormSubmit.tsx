import React from 'react';
import classes from './FormSubmit.module.css';

function FormSubmit({children} : {children: string}
    ) {
    return (
        <button type='submit'
         className={classes.butt}
         >{children}</button>
    );
}

export default FormSubmit;