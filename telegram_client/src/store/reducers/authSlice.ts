import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from './../../@types/IUser.d';

const initialState: IUser = {
    accessToken:'',
    refreshToken: '',
    userName: '',
    role: '',
    isAuthenticated: false
}

export const authSlice = createSlice({
    name:'auth',
    initialState,
    reducers: {
        signIn(state, action:PayloadAction<IUser>) {
            state.isAuthenticated = action.payload.isAuthenticated;
            state.role = action.payload.role;
            state.userName = action.payload.userName;
            state.accessToken = action.payload.accessToken;
            state.refreshToken = action.payload.refreshToken;
        }
    }
});

export const {signIn} = authSlice.actions;

export default authSlice.reducer;