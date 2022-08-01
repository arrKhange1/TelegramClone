import React, { FormEvent } from 'react';
import { signIn } from '../../store/reducers/authSlice';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { useAppSelector } from '../../hooks/useAppSelector';
import { Location } from "history";
import { Link, useLocation, useNavigate } from 'react-router-dom';
import axios, { AxiosError } from 'axios';
import { ILoginResponse } from '../../@types/IUser';
import { useAuth } from '../../hooks/useAuth';

interface CustomizedState {
    myState: string
  }

function Login() {
    const navigate = useNavigate();
    const dispatch = useAppDispatch();
    const user = useAuth();

    const LogIn = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        const formData = new FormData(e.currentTarget);
        const body = {
            UserName: formData.get('username'),
            Password: formData.get('password')
        }
        try {
            const response = await axios.post<ILoginResponse>('auth', body);
            await dispatch(signIn({...response.data, isAuthenticated:true}));
            console.log(user);
            navigate('/');
        }
        catch(error:any) {
            
        }
        

    }

    return (
        <form onSubmit={LogIn}>
            <input type="text" placeholder='username' name='username'/>
            <input type="password" placeholder='password' name='password' />
            <button type='submit'>Log In</button>
        </form>
    );
}

export default Login;