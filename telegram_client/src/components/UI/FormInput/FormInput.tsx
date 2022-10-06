import React from 'react';
import classes from './FormInput.module.css';

function FormInput({placeholder, onChange, value, name} : {placeholder : string,
    onChange: any, value: string, name: string}) {
    return (
        <input type="text"
        value={value}
        placeholder={placeholder}
        className={classes.forminput}
        onChange={onChange}
        name={name}
        />
    );
}

export default FormInput;