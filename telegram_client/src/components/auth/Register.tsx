import axios from 'axios';
import React, { FormEvent } from 'react';
import { Link, Navigate, useNavigate } from 'react-router-dom';
import { ILoginResponse, IUser } from '../../@types/IUser';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAuth } from '../../hooks/useAuth';
import AuthService from '../../services/AuthService';
import { authenticate } from '../../store/reducers/authSlice';
import classes from '../../styles/auth/auth.module.css';
import CustomButton from '../UI/CustomButton/CustomButton';
import CustomInput from '../UI/CustomInput/CustomInput';

function Register() {

    const navigate = useNavigate();

    // for dev purposes
    const userRedux: IUser = useAuth();
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
        <form onSubmit={register} className={classes.form}>
            <CustomInput type="text" name='username' placeholder='username'/>
            <CustomInput type="password" name='password' placeholder='password'/>
            <CustomInput type="password" name='username' placeholder='confirm password'/>
            <CustomButton type='submit' value='Sign Up'/>
            <Link to='/auth'>Already have an account?</Link>
        </form>
        
    );
}

export default Register;