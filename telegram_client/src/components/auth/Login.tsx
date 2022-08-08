import React, { FormEvent } from 'react';
import { authenticate } from '../../store/reducers/authSlice';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAppSelector } from '../../hooks/useAppSelector';
import { Location } from "history";
import { Link, useLocation, useNavigate } from 'react-router-dom';
import axios, { AxiosError } from 'axios';
import { ILoginResponse } from '../../@types/IUser';
import { useAuth } from '../../hooks/useAuth';
import { $api } from '../../http/axios';
import AuthService from '../../services/AuthService';


function Login() {

    const navigate = useNavigate();
    const dispatch = useAppDispatch();

     const userRedux = useAuth();
     const userLocalStorage = localStorage.getItem('userInfo');

    const login = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        await AuthService.login(e);
        navigate('/');
    }

    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <form onSubmit={login}>
            <input type="text" placeholder='username' name='username'/>
            <input type="password" placeholder='password' name='password' />
            <button type='submit'>Log In</button>
            <Link to='/register'>Нет аккаунта? Регистрируйся!</Link>
        </form>
    );
}

export default Login;