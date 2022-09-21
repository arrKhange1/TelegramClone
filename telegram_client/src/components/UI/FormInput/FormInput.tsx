import React from 'react';
import classes from './FormInput.module.css';

function FormInput({placeholder, onChange, value} : {placeholder : string,
    onChange: any, value: string}) {
    return (
        <input type="text"
        value={value}
        placeholder={placeholder}
        className={classes.forminput}
        onChange={onChange}
        />
    );
}

export default FormInput;