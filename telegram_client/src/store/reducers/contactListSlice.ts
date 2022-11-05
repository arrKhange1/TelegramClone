import { useNavigate } from 'react-router-dom';
import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from '../../@types/IUser';
import IContact from '../../@types/IContact';

const initialState: IContact[] = []

export const contactListSlice = createSlice({
    name:'contactList',
    initialState,
    reducers: {

        setContacts(state, action:PayloadAction<IContact[]>) {
            return action.payload;
        },

        addContacts(state, action:PayloadAction<IContact>) {
            return [action.payload, ...state];
        }
    }
});

export const {setContacts, addContacts} = contactListSlice.actions;

export default contactListSlice.reducer;