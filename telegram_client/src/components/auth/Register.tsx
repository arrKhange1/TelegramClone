import axios from 'axios';
import React, { FormEvent } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import { ILoginResponse } from '../../@types/IUser';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { signIn } from '../../store/reducers/authSlice';

function Register() {

    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const register = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const formData = new FormData(e.currentTarget); // туду: мб сделать в один метод логин и рег
        const body = {
            UserName: formData.get('username'),
            Password: formData.get('password')
        };

        try {
            const response = await axios.post<ILoginResponse>("auth/register", body);
            await dispatch(signIn({...response.data, isAuthenticated:true}));
            navigate('/');
        }
        catch (e:any) {

        }
    }

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