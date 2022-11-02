import { useNavigate } from 'react-router-dom';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from './../../@types/IUser.d';
import IChat from '../../@types/IChat';

const initialState: IChat[] = []

export const chatListSlice = createSlice({
    name:'chatList',
    initialState,
    reducers: {

        setChats(state, action:PayloadAction<IChat[]>) {
            return action.payload;
        }
    }
});

export const {setChats} = chatListSlice.actions;

export default chatListSlice.reducer;