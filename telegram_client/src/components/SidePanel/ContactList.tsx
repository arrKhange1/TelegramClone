import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import home from '../../styles/home/home.module.css';
import side from '../../styles/side_panel/side.module.css';
import ContactListElement from './ContactListElement';
import IContact from '../../@types/IContact';
import { useAppSelector } from '../../hooks/useAppSelector';
import { IUser } from '../../@types/IUser';
import { $api } from '../../http/axios';
import { useAuth } from '../../hooks/useAuth';
import ContactsService from '../../services/ContactsService';
import AddButton from './AddButton';
import AddContactIcon from '../../icons/AddContactIcon';

function ContactList() {
    const user: IUser = useAuth();
    
    const [contacts, setContacts] = useState<IContact[]>([]);
    useEffect(() => {
        const fetchContacts = async () => {
            const response = await ContactsService.getContacts(user.userId);
            setContacts([...response.data]);
        }
        fetchContacts();
    }, []);

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState(chatId);
    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    return (
        <div className={side.chats + custom_scroll}>
            {contacts.length ? contacts.map(contact => 
                <Link key={contact.contactId} to={contact.contactId} className={side.chat_open_link}
                onClick={() => 
                    setActiveChat(contact.contactId)
                }>
                    <ContactListElement activeChat={activeChat} contact={contact}/>
                </Link>
                
            ) : <div>no contacts</div> }

            <AddButton addCallback={() => console.log('contact')}>
                <AddContactIcon/>
            </AddButton>

        </div>
    );
}

export default ContactList;