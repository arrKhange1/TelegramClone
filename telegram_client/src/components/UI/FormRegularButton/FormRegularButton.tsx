import React from 'react';
import classes from './FormRegularButton.module.css';

function FormRegularButton({children, onClick} : {children: string,
    onClick: () => void}) {
    return (
        <button className={classes.butt} type='button' onClick={onClick}>{children}</button>
    );
}

export default FormRegularButton;