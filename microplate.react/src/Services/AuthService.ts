import { LoginRequestDto, Register } from 'Models/Auth';
import axios from 'axios';

export const login = async (loginRequest: LoginRequestDto) => {
    const response = await axios.post('/api/auth/login', loginRequest);
    return response.data;
};

export const register = async (registerRequest: Register) => {
    const response = await axios.post('/api/auth/register', registerRequest);
    return response.data;
};
export const getUserInfo = async () => {
    const response = await axios.get('/api/user');
    return response.data;
};