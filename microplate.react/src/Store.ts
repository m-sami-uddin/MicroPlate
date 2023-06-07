import { User } from 'Models/Auth';
import { applyMiddleware, combineReducers, createStore } from 'redux';
import thunk from 'redux-thunk';
import { Product } from './Models/Product';
import authReducer from './Reducers/AuthReducer';
import productReducer from './Reducers/ProductReducer';

const rootReducer = combineReducers({
    auth: authReducer,
    product: productReducer,
});
export interface AuthState {
    isAuthenticated: boolean;
    user?: User;
    error?: any;
    loading: boolean;
}
export interface ProductState {
    products: Product[];
    error?: any;
    loading: boolean;

}
interface State {
    auth: AuthState;
    product: ProductState;
}
export const InitialState: State = {
    auth: {
        isAuthenticated: false,
        user: undefined,
        error: null,
        loading: false,
    },
    product: {
        products: [],
        error: null,
        loading: false,
    },
};

const middleware = [thunk];

const store = createStore(
    rootReducer,
    InitialState,
    applyMiddleware(...middleware)
);

export default store;