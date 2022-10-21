import axios, { AxiosError } from 'axios';
import { useNavigate } from 'react-router-dom';
import AuthService from '../services/AuthService';
import { setupStore } from '../store/store';
import { store } from '../index';
import refreshPromise  from './refreshTokenPromise'
import { setAccessToken } from '../store/reducers/authSlice';

export const API_URL = 'https://localhost:44351';

export const $api = axios.create({
    baseURL: API_URL
});

$api.interceptors.response.use(config => {
    return config;
}, async (error) => {
    const originRequest = error.config;
    if (error.response.status === 401 && error.config && !originRequest._isRetry) {
        originRequest._isRetry = true;

        if (!refreshPromise.refresh) {
            refreshPromise.refresh = axios.post<string>('auth/refresh').then(res => {
                console.log('send refresh from axios interceptor');
                refreshPromise.refresh = null;
                store.dispatch(setAccessToken(res.data));
            })
            
        }

        return refreshPromise.refresh.then(() => {
            return $api.request(originRequest)
            
        })
        .catch(async (e: AxiosError) => {
            if (e.response?.status === 401) {
                      console.log('refresh error'); // force logout
                      await AuthService.logout();
                      return;
                  }
        });
        



        // try {
        //     await axios.post('auth/refresh');
        //     const resp = await $api.request(originRequest);
        //     console.log('access token expired, new pair generated');
        //     return resp;
        // } catch(e) {
        //     if ((e as AxiosError).response?.status === 401) {
        //         console.log('refresh error'); // force logout
        //         await AuthService.logout();
        //     }
        // }
        
    }
    throw error; // if not 401 status code
})
