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
        },

        cleanChatUnreadMsgs(state, action: PayloadAction<string>) {
            return [...state.map(chat => chat.chatId === action.payload ? {...chat, unreadMsgs: 0} : chat)]
        },

        replaceExistingChat(state, action: PayloadAction<IChat>) {
            
            return [action.payload, ...state.filter(chat => chat.chatId !== action.payload.chatId)];
        },

        addToChats(state, action: PayloadAction<IChat>) {
            return [action.payload, ...state];
        }
    }
});

export const {setChats, addToChats, cleanChatUnreadMsgs, replaceExistingChat} = chatListSlice.actions;

export default chatListSlice.reducer;