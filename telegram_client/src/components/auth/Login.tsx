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

function Login() {

    const navigate = useNavigate();
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

     const userRedux: IUser = useAuth();
     const userLocalStorage = localStorage.getItem('userInfo');

    const login = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        await AuthService.login(e);
        navigate('/');
    }

    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <form onSubmit={login} className={classes.form}>
            <FormInput 
                type="text"
                placeholder='username'
                name='username'
                value={username}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setUsername(e.target.value)} 
            />
            <FormInput
            type="password" 
            placeholder='password' 
            name='password'
            value={password}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) => setPassword(e.target.value)} 
             />
            <FormButton type='submit' onClick={() => {}}>Sign In</FormButton>
            <Link to='/auth/reg'>Don't have an account yet?</Link>
        </form>
    );
}

export default Login;