import contactListReducer from './reducers/contactListSlice';
import chatsReducer from './reducers/chatListSlice';
import chatsSearchInputReducer from './reducers/chatsSearchInputSlice';
import { combineReducers, configureStore } from "@reduxjs/toolkit";
import authReducer from './reducers/authSlice';

const rootReducer = combineReducers({
    authReducer,
    chatsReducer,
    contactListReducer,
    chatsSearchInputReducer
});

export const setupStore = () => {
    return configureStore({
        reducer:rootReducer
    })
}

export type RootState = ReturnType<typeof rootReducer>;
export type AppStore = ReturnType<typeof setupStore>;
export type AppDispatch = AppStore['dispatch'];