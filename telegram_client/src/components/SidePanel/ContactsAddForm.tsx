import React, { ChangeEvent, useEffect, useState } from 'react';
import contacts from '../../styles/side_panel/contactsform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormSubmit from '../UI/FormSubmit/FormSubmit';

function ContactsAddForm({setModal, cb, setContactName} : {setModal:React.Dispatch<React.SetStateAction<boolean>>,
    cb: () => void, setContactName: React.Dispatch<React.SetStateAction<string>>}) {
    
    
    return (
        <div className={contacts.form}>
            <header className={contacts.form_header}>New Contact</header>
            <form className={contacts.form_content}>
                <FormInput 
                placeholder='username'
                onChange={(e:ChangeEvent<HTMLInputElement>) => setContactName(e.target.value)}
                />
            </form>
            <footer className={contacts.form_footer}>
                <FormSubmit onClick={() => setModal(false)}>CANCEL</FormSubmit>
                <FormSubmit onClick={cb}>DONE</FormSubmit>
            </footer>
        </div>
    )
}

export default ContactsAddForm;