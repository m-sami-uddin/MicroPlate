import { LOGIN_SUCCESS } from "Constants/AuthConstants";
import { LoginRequestDto } from "Models/Auth";
import * as authService from 'Services/AuthService';
import { ERROR, LOADING } from './../Constants/CommonConstants';

export async function loginAction(loginRequest: LoginRequestDto) {
    return async (dispatch: any) => {
        try {
            dispatch({ type: LOADING });
            const response = await authService.login(loginRequest);
            const data = await response.json();
            console.log(data);
            dispatch({ type: LOGIN_SUCCESS, payload: data["user"] });
        } catch (error) {
            console.log(error);
            dispatch({ type: ERROR, payload: error })
        }
    };
};