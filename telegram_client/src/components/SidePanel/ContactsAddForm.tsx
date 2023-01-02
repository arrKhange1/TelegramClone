import React, { ChangeEvent, useEffect, useState } from 'react';
import modalForm from '../../styles/side_panel/modalform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormButton from '../UI/FormButton/FormButton';
import { useAuth } from '../../hooks/useAuth';
import ContactsService from '../../services/ContactsService';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import { addContacts } from '../../store/reducers/contactListSlice';
import { ActionCreatorWithPayload } from '@reduxjs/toolkit';

function ContactsAddForm({setModal, modal, setContactsSearchText} : {setModal:React.Dispatch<React.SetStateAction<boolean>>, 
    modal: boolean, setContactsSearchText: ActionCreatorWithPayload<string, string>}) {
    
    const user = useAuth();
    const dispatch = useAppDispatch();
    const [contactToAdd, setContactToAdd] = useState('');

    const addContact = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.target as HTMLFormElement);
        const contactToAdd = formData.get('username') as string;

        const response = await ContactsService.addContact(user.userId, contactToAdd);
        dispatch(addContacts(response.data));
        setModal(false);
        dispatch(setContactsSearchText(''));
    }

    useEffect(() => {
        if (!modal) {
            setContactToAdd('');
        }
    }, [modal])

    return (
        <form onSubmit={addContact} className={modalForm.form}> 
            <header className={modalForm.form_header}>New Contact</header>
            <main className={modalForm.form_content}>
                <FormInput 
                type='text'
                value={contactToAdd}
                onChange={(e:React.ChangeEvent<HTMLInputElement>) =>  setContactToAdd(e.target.value)}
                placeholder='username'
                name='username'
                />
            </main>
            <footer className={modalForm.form_footer}>
                <FormButton type='button' onClick={() => setModal(false)}>CANCEL</FormButton>
                <FormButton type='submit' onClick={() => setModal(false)}>DONE</FormButton>
            </footer>
        </form>
    )
}

export default ContactsAddForm;