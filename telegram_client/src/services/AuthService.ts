import { setupStore } from './../store/store';
import { useAppDispatch } from './../hooks/useAppDispatch';
import { FormEvent } from 'react';
import { ILoginResponse, IUser } from '../@types/IUser';
import { $api } from '../http/axios';
import axios from 'axios';
import { authenticate, signOut } from '../store/reducers/authSlice';
import { store } from '../index';

export default class AuthService {

    static async login(e: FormEvent<HTMLFormElement>){

        const body = {
            UserName: new FormData(e.currentTarget).get('username'),
            Password: new FormData(e.currentTarget).get('password')
        }
        const response = await $api.post<ILoginResponse>('auth/login', body);
        localStorage.setItem('userInfo', JSON.stringify({...response.data, isAuthenticated: true}));
        await store.dispatch(authenticate({...response.data, isAuthenticated: true}))
    }

    static async register(e: FormEvent<HTMLFormElement>) {

        const body = {
            UserName: new FormData(e.currentTarget).get('username'),
            Password: new FormData(e.currentTarget).get('password'),
            ConfirmPassword: new FormData(e.currentTarget).get('confirm')
        }

        const response = await $api.post<ILoginResponse>('auth/register', body);
        localStorage.setItem('userInfo', JSON.stringify({...response.data, isAuthenticated: true}));
        await store.dispatch(authenticate({...response.data, isAuthenticated: true}))
    }

    static async logout() {
        await axios.post('auth/logout');
        localStorage.removeItem('userInfo');
        store.dispatch(signOut());
    }
    
    
}