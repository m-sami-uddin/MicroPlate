import store from 'Store';
import axios, { AxiosInstance } from 'axios';

export const AuthApiClient = axios.create({
    baseURL: process.env.REACT_APP_AUTH_BASE_URL,
    // ... other options
});

export const ServicesApiClient = axios.create({
    baseURL: process.env.REACT_APP_API_BASE_URL,
    headers: {


    }
    // ... other options
});
ServicesApiClient.interceptors.request.use(
    (config) => {
        const { accessToken } = store.getState().auth.user;
        if (accessToken) {
            config.headers.Authorization = `Bearer ${accessToken}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);


export const get = async (client: AxiosInstance, url: string, params: Record<string, any>): Promise<any> => {
    return await client.get(url, { params });
};

export const post = async (client: AxiosInstance, url: string, data: any): Promise<any> => {
    return await client.post(url, data);
};