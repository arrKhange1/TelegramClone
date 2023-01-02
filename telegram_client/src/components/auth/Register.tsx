import axios, { AxiosError } from 'axios';
import React, { FormEvent, useState } from 'react';
import { Link, Navigate, useNavigate } from 'react-router-dom';
import IAuthFormErrors from '../../@types/IAuthFormErrors';
import { ILoginResponse, IUser } from '../../@types/IUser';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAuth } from '../../hooks/useAuth';
import AuthService from '../../services/AuthService';
import { authenticate } from '../../store/reducers/authSlice';
import classes from '../../styles/auth/auth.module.css';
import CustomButton from '../UI/CustomButton/CustomButton';
import CustomInput from '../UI/CustomInput/CustomInput';
import FormButton from '../UI/FormButton/FormButton';
import FormInput from '../UI/FormInput/FormInput';

function Register() {

    const navigate = useNavigate();

    // for dev purposes
    const userRedux: IUser = useAuth();
    const userLocalStorage = localStorage.getItem('userInfo');
    
    const [formFields, setFormFields] = useState<IAuthFormFields>({username: '', password: '', confirmPassword: ''});
    const [formErrors, setFormErrors] = useState<IAuthFormErrors>({usernameError: '', passwordError: '', confirmPasswordError: ''});
    const [serverError, setServerError] = useState<string>('');

    const register = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        if (formFields.username.length < 5) {
            setFormErrors({...formErrors, usernameError: "Username is less 5 symbols!"});
            return;
        }
        if (formFields.password.length < 8) {
            setFormErrors({...formErrors, passwordError: "Password is less 8 symbols!"});
            return;
        }
        if (formFields.confirmPassword !== formFields.password) {
            setFormErrors({...formErrors, confirmPasswordError: "Passwords don't match!"});
            return;
        }

        try {
            await AuthService.register(e);
            navigate('/');
        }
        catch(e) {
            const errorText = (e as AxiosError).response?.data as string;
            setServerError(errorText);
        }
    }

    const onChangeUsername = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormFields({...formFields, username: e.target.value});
        if (e.target.value.length < 5)
            setFormErrors({...formErrors, usernameError: "Username is less 5 symbols!"});
        else 
            setFormErrors({...formErrors, usernameError: ""});
    }

    const onChangePassword = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormFields({...formFields, password: e.target.value});
        if (e.target.value.length < 8) {
            console.log(e.target.value)
            setFormErrors({...formErrors, passwordError: "Password is less 8 symbols!"});
        }
        else 
            setFormErrors({...formErrors, passwordError: ""});

        if (e.target.value !== formFields.confirmPassword) 
            setFormErrors(formErr => ({...formErr, confirmPasswordError: "Passwords don't match!"}));
        else 
            setFormErrors(formErr => ({...formErr, confirmPasswordError: ""}));
    }

    const onChangeConfirmPassword = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormFields({...formFields, confirmPassword: e.target.value});;
        if (e.target.value !== formFields.password) 
            setFormErrors({...formErrors, confirmPasswordError: "Passwords don't match!"});
        else 
            setFormErrors({...formErrors, confirmPasswordError: ""});
    }

     // for dev purposes
    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <form onSubmit={register} className={classes.form}>
            <FormInput 
                 type="text"
                 placeholder='username'
                 name='username'
                 value={formFields.username}
                 onChange={onChangeUsername} 
             />
             <div className={formErrors.usernameError.length ? classes.reg_error :
                 `${classes.reg_error} ${classes.reg_error__hidden}`}>{formErrors.usernameError}</div>
            <FormInput
                type="password" 
                name='password'
                placeholder='password'
                value={formFields.password}
                onChange={onChangePassword} 
              />
            <div className={formErrors.passwordError.length ? classes.reg_error :
                 `${classes.reg_error} ${classes.reg_error__hidden}`}>{formErrors.passwordError}</div>
            <FormInput 
                type="password" 
                name='confirmPassword' 
                placeholder='confirm password'
                value={formFields.confirmPassword}
                onChange={onChangeConfirmPassword} 
            />
            <div className={formErrors.confirmPasswordError.length ? classes.reg_error :
                 `${classes.reg_error} ${classes.reg_error__hidden}`}>{formErrors.confirmPasswordError}</div>
            
            <FormButton type='submit' onClick={() => {}}>Sign Up</FormButton>
            
            <div className={serverError.length ? classes.server_error :
                 `${classes.server_error} ${classes.server_error__hidden}`}>{serverError}</div>
            
            <Link to='/auth'>Already have an account?</Link>
        </form>
        
    );
}

export default Register;