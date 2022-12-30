import { useNavigate } from 'react-router-dom';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from './../../@types/IUser.d';
import IChat from '../../@types/IChat';
import ISearchText from '../../@types/ISearchText';

const initialState: ISearchText = {chatsSearchText: '', contactsSearchText: ''}

export const sidePanelSearchInputSlice = createSlice({
    name:'searchInput',
    initialState,
    reducers: {

        setChatsSearchText(state, action: PayloadAction<string>) {
            state.chatsSearchText = action.payload;
        },
        setContactsSearchText(state, action: PayloadAction<string>) {
            state.contactsSearchText = action.payload;
        }
    }
});

export const {setChatsSearchText, setContactsSearchText} = sidePanelSearchInputSlice.actions;

export default sidePanelSearchInputSlice.reducer;