import React, { ChangeEvent, useEffect, useState } from 'react';
import IContact from '../../@types/IContact';
import { useAuth } from '../../hooks/useAuth';
import ContactsService from '../../services/ContactsService';
import modalForm from '../../styles/side_panel/modalform.module.css';
import FormInput from '../UI/FormInput/FormInput';
import FormButton from '../UI/FormButton/FormButton';
import { $api } from '../../http/axios';
import axios from 'axios';

function ChatsAddForm({setModal} : {
    setModal:React.Dispatch<React.SetStateAction<boolean>>,
        }) {

    const user = useAuth();
    const [contacts, setContacts] = useState<IContact[]>();
    const [chatToAdd, setChatToAdd] = useState<string>('');
        
    const fetchContacts = async () => {
        const response = await ContactsService.getContacts(user.userId);
        console.log(response);
        setContacts([...response.data]);
    }

    useEffect(() => {
        fetchContacts();
    }, []);

    const addGroupChat = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const formData = new FormData(e.target as HTMLFormElement);
        const membersIds: FormDataEntryValue[] = formData.getAll('ids');
        const membersNames: FormDataEntryValue[] = formData.getAll('names');
        const groupName = formData.get('groupName');

        let payload = {
            groupName: groupName,
            membersIds:membersIds,
            membersNames:membersNames
          };
        await $api.post('https://localhost:44351/chats/addgroupchat', payload);

        console.log(membersIds, membersNames, groupName);
    }

    return (
        <form className={modalForm.form} onSubmit={addGroupChat}>
            <header className={modalForm.form_header}>New Group Chat</header>
            <main className={modalForm.form_content}>
                <label>
                    <FormInput 
                        value={chatToAdd}
                        name={'groupName'}
                        placeholder='group name'
                        onChange={(e:ChangeEvent<HTMLInputElement>) => setChatToAdd(e.target.value)}
                    />
                </label>
                <p>Choose members from your contacts:</p>
                <ul>
                    {
                    contacts?.map(contact => 
                        <label key={contact.contactId}>
                            <input type="checkbox" name='ids' value={contact.contactId}/>
                            {contact.contactName}
                            <input type="hidden" name='names' value={contact.contactName}/> 
                        </label>
                        )
                    }
                </ul>
            </main>
            <footer className={modalForm.form_footer}>
                <FormButton onClick={() => setModal(false)}>CANCEL</FormButton>
                <FormButton onClick={() => setModal(false)}>DONE</FormButton>
            </footer>
        </form>
    );
}

export default ChatsAddForm;