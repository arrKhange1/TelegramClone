import axios, { AxiosError } from 'axios';
import { useNavigate } from 'react-router-dom';
import AuthService from '../services/AuthService';
import { setupStore } from '../store/store';

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
        try {
            await axios.post('auth/refresh');
            const resp = await $api.request(originRequest);
            console.log('access token expired, new pair generated');
            return resp;
        } catch(e) {
            if ((e as AxiosError).response?.status === 401) {
                console.log('refresh error'); // force logout
                await AuthService.logout();
            }
        }
        
    }
    throw error; // if not 401 status code
})
