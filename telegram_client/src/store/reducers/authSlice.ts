import { useNavigate } from 'react-router-dom';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from './../../@types/IUser.d';

const initialState: IUser = {
    userId: '',
    userName: '',
    role: '',
    isAuthenticated: false,
    accessToken: ''
}

export const authSlice = createSlice({
    name:'auth',
    initialState,
    reducers: {

        authenticate(state, action:PayloadAction<IUser>) {
            state.userId = action.payload.userId;
            state.role = action.payload.role;
            state.userName = action.payload.userName;
            state.isAuthenticated = action.payload.isAuthenticated;
            state.accessToken = action.payload.accessToken;
        },

        signOut(state) {
            state.userId = '';
            state.role = '';
            state.userName = '';
            state.isAuthenticated = false;
            state.accessToken = ''
        }
    }
});

export const {authenticate, signOut} = authSlice.actions;

export default authSlice.reducer;