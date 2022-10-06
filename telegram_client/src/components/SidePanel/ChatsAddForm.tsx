import React, { ChangeEvent, useEffect, useState } from 'react';
import IContact from '../../@types/IContact';
import { useAuth } from '../../hooks/useAuth';
import ContactsService from '../../services/ContactsService';
import modalForm from '../../styles/side_panel/modalform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormButton from '../UI/FormButton/FormButton';

function ChatsAddForm({setModal} : {
    setModal:React.Dispatch<React.SetStateAction<boolean>>,
        }) {

    const user = useAuth();
    const [contacts, setContacts] = useState<IContact[]>();
    const [chatToAdd, setChatToAdd] = useState<string>('');
        
    const fetchContacts = async () => { // maybe from redux
        const response = await ContactsService.getContacts(user.userId);
        setContacts([...response.data]);
    }

    useEffect(() => {
        fetchContacts();
    }, []);
    
    const addGroupChat = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const formData = new FormData(e.target as HTMLFormElement);
        const membersToAdd: FormDataEntryValue[] = formData.getAll('ids');
        const groupName = formData.get('groupName');

        console.log(membersToAdd, groupName);
    }

    return (
        <form className={modalForm.form} onSubmit={addGroupChat}>
            <header className={modalForm.form_header}>New Group Chat</header>
            <label>
                <FormInput 
                    value={chatToAdd}
                    name={'groupName'}
                    placeholder='group name'
                    onChange={(e:ChangeEvent<HTMLInputElement>) => setChatToAdd(e.target.value)}
                />
            </label>
            <p>Choose members from your contacts:</p>
            {
            contacts?.map(contact => 
                <label key={contact.contactId}>
                    <input type="checkbox" name='ids' value={contact.contactId}/>
                    {contact.contactName}
                </label>
                )
            }
            <footer className={modalForm.form_footer}>
                <FormButton onClick={() => setModal(false)}>CANCEL</FormButton>
                <FormButton onClick={() => setModal(false)}>DONE</FormButton>
            </footer>
        </form>
    );
}

export default ChatsAddForm;