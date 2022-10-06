import React, { ChangeEvent, useEffect, useState } from 'react';
import modalForm from '../../styles/side_panel/modalform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormButton from '../UI/FormButton/FormButton';

function ContactsAddForm({setModal, cb, setContactName, contactName} : {setModal:React.Dispatch<React.SetStateAction<boolean>>,
    cb: () => void, setContactName: React.Dispatch<React.SetStateAction<string>>,
    contactName: string}) {
    
    const addContact = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await cb();
    }

    // peredelat
    return (
        <form onSubmit={addContact} className={modalForm.form}> 
            <header className={modalForm.form_header}>New Contact</header>
            <main className={modalForm.form_content}>
                <FormInput 
                value={contactName}
                placeholder='username'
                onChange={(e:ChangeEvent<HTMLInputElement>) => setContactName(e.target.value)}
                name={'username'}
                />
            </main>
            <footer className={modalForm.form_footer}>
                <FormButton onClick={() => setModal(false)}>CANCEL</FormButton>
                <FormButton onClick={() => setModal(false)}>DONE</FormButton>
            </footer>
        </form>
    )
}

export default ContactsAddForm;