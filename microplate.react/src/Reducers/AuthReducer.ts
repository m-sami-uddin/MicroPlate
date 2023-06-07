import { LOGIN_SUCCESS } from "../Constants/AuthConstants";
import { ERROR, LOADING } from '../Constants/CommonConstants';
import { InitialState } from './../Store';

const authReducer = (state = InitialState.auth, action: any) => {
    switch (action.type) {
        case LOADING:
            return {
                ...state,
                loading: true,
            };
        case LOGIN_SUCCESS:
            return {
                ...state,
                isAuthenticated: true,
                user: action.payload,
                loading: false,
            };
        case ERROR:
            return {
                ...state,
                isAuthenticated: false,
                user: null,
                error: action.payload,
                loading: false,
            };
        default:
            return state;
    }
};

export default authReducer;