import React, { FormEvent } from 'react';
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

function Login() {

    const navigate = useNavigate();
    const dispatch = useAppDispatch();

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
            <CustomInput type="text" placeholder='username' name='username'/>
            <CustomInput type="password" placeholder='password' name='password' />
            <CustomButton type='submit' value='Sign In'/>
            <Link to='/auth/reg'>Don't have an account yet?</Link>
        </form>
    );
}

export default Login;