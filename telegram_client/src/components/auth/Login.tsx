import React, { FormEvent, useState } from 'react';
import { authenticate } from '../../store/reducers/authSlice';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAppSelector } from '../../hooks/useAppSelector';
import { Location } from "history";
import { Link, useLocation, useNavigate } from 'react-router-dom';
import axios, { AxiosError } from 'axios';
import { ILoginResponse, IUser } from '../../@types/IUser';
import { useAuth } from '../../hooks/useAuth';
import { $api } from '../../http/axios';
import AuthService from '../../services/AuthService';
import classes from '../../styles/auth/auth.module.css';
import CustomInput from '../UI/CustomInput/CustomInput';
import CustomButton from '../UI/CustomButton/CustomButton';
import FormInput from '../UI/FormInput/FormInput';
import FormButton from '../UI/FormButton/FormButton';
import IAuthLoginFormFields from '../../@types/IAuthLoginFields';

function Login() {

    const navigate = useNavigate();
    const [formFields, setFormFields] = useState<IAuthLoginFormFields>({username: '', password: ''});
    const [serverError, setServerError] = useState('');

     const userRedux: IUser = useAuth();
     const userLocalStorage = localStorage.getItem('userInfo');

    const login = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        try {
            await AuthService.login(e);
            navigate('/');
        }
        catch(e) {
           const errorText = (e as AxiosError).response?.data as string;
           setServerError(errorText);
        }
    }

    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <form onSubmit={login} className={classes.form}>
            <FormInput 
                type="text"
                placeholder='username'
                name='username'
                value={formFields.username}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setFormFields({...formFields, username: e.target.value})} 
            />
            <FormInput
            type="password" 
            placeholder='password' 
            name='password'
            value={formFields.password}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) => setFormFields({...formFields, password: e.target.value})} 
             />
            <FormButton type='submit' onClick={() => {}}>Sign In</FormButton>
            <div className={serverError.length ? classes.server_error : 
                `${classes.server_error} ${classes.server_error__hidden}`}>{serverError}</div>
            <Link to='/auth/reg'>Don't have an account yet?</Link>
        </form>
    );
}

export default Login;