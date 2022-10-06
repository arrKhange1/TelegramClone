import React, { ChangeEvent, useEffect, useState } from 'react';
import modalForm from '../../styles/side_panel/modalform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormRegularButton from '../UI/FormRegularButton/FormRegularButton';
import FormSubmit from '../UI/FormSubmit/FormSubmit';

function ContactsAddForm({setModal, cb, setContactName, contactName} : {setModal:React.Dispatch<React.SetStateAction<boolean>>,
    cb: () => void, setContactName: React.Dispatch<React.SetStateAction<string>>,
    contactName: string}) {
    
    // peredelat
    return (
        <div className={modalForm.form}> 
            <header className={modalForm.form_header}>New Contact</header>
            <form className={modalForm.form_content}>
                <FormInput 
                value={contactName}
                placeholder='username'
                onChange={(e:ChangeEvent<HTMLInputElement>) => setContactName(e.target.value)}
                name={'username'}
                />
            </form>
            <footer className={modalForm.form_footer}>
                <FormRegularButton onClick={() => setModal(false)}>CANCEL</FormRegularButton>
                <FormSubmit>DONE</FormSubmit>
            </footer>
        </div>
    )
}

export default ContactsAddForm;