import React from 'react';
import classes from './CustomButton.module.css';

function CustomButton({...props}) {
    return (
        <input {...props} className={classes.butt} />
        
    );
}

export default CustomButton;