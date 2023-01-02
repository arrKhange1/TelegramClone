import React from 'react';
import classes from './FormInput.module.css';

function FormInput({placeholder, type, name, value, onChange} : {placeholder : string, type: string,
     name: string, value: string, onChange: (e:React.ChangeEvent<HTMLInputElement>) => void}) {
    return (
        <input
        type={type}
        placeholder={placeholder}
        className={classes.forminput}
        name={name}
        value={value}
        onChange={onChange}
        />
    );
}

export default FormInput;