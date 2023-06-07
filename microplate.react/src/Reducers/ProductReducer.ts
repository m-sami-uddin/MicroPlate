import { CREATE_PRODUCT_SUCCESS, DELETE_PRODUCT_SUCCESS, GET_ALL_PRODUCTS_SUCCESS, UPDATE_PRODUCT_SUCCESS } from 'Constants/ProductConstants';
import { ERROR } from './../Constants/CommonConstants';

import { LOADING } from "Constants/CommonConstants";
import { Product } from 'Models/Product';
import { InitialState } from 'Store';



const productReducer = (state = InitialState.product, action: any) => {
    switch (action.type) {
        case LOADING:
            return {
                ...state,
                loading: true,
            };
        case GET_ALL_PRODUCTS_SUCCESS:
            return {
                ...state,
                products: action.payload,
                error: null,
                loading: false,
            };
        case CREATE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: [...state.products, action.payload],
                loading: false,
                error: null,
            };
        case UPDATE_PRODUCT_SUCCESS:
            const updatedProduct = action.payload;
            const updatedProducts = state.products.map((product: Product) =>
                product.id === updatedProduct.id ? updatedProduct : product
            );
            return {
                ...state,
                products: updatedProducts,
                loading: false,
                error: null,
            };
        case DELETE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: state.products.filter(
                    (product: Product) => product.id !== action.payload
                ),
                error: null,
                loading: false,
            };
        case ERROR:
            return {
                ...state,
                error: action.payload,
                loading: false,
            };
        default:
            return state;
    }
};

export default productReducer;