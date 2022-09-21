import React from 'react';
import classes from './FormInput.module.css';

function FormInput({placeholder, onChange} : {placeholder : string,
    onChange: any}) {
    return (
        <input type="text"
        placeholder={placeholder}
        className={classes.forminput}
        onChange={onChange}
        />
    );
}

export default FormInput;