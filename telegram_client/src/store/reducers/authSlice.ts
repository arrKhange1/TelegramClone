import { useNavigate } from 'react-router-dom';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from './../../@types/IUser.d';

const initialState: IUser = {
    userName: '',
    role: '',
    isAuthenticated: false
}

export const authSlice = createSlice({
    name:'auth',
    initialState,
    reducers: {

        authenticate(state, action:PayloadAction<IUser>) {
            state.role = action.payload.role;
            state.userName = action.payload.userName;
            state.isAuthenticated = action.payload.isAuthenticated;
        },

        signOut(state) {
            state.role = '';
            state.userName = '';
            state.isAuthenticated = false;

        }
    }
});

export const {authenticate, signOut} = authSlice.actions;

export default authSlice.reducer;