import axios from 'axios';
import React, { FormEvent } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import { ILoginResponse } from '../../@types/IUser';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAuth } from '../../hooks/useAuth';
import AuthService from '../../services/AuthService';
import { authenticate } from '../../store/reducers/authSlice';

function Register() {

    const navigate = useNavigate();

    // for dev purposes
    const userRedux = useAuth();
    const userLocalStorage = localStorage.getItem('userInfo');

    const register = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        await AuthService.register(e);
        navigate('/');
    }

     // for dev purposes
    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <form onSubmit={register}>
            <input type="text" name='username' placeholder='username'/>
            <input type="password" name='password' placeholder='password'/>
            <input type="password" name='username' placeholder='confirm'/>
            <button type='submit'>Register</button>
        </form>
    );
}

export default Register;