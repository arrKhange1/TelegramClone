import axios, { AxiosError } from 'axios';

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
            $api.request(originRequest);
            console.log('access token expired, new pair generated');
        } catch(e) {
            console.log('refresh error'); // force logout
        }
        
    }
    throw error; // if not 401 status code
})
