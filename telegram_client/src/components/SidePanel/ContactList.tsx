import React, { useEffect, useMemo, useState } from 'react';
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
import AddContactIcon from '../../icons/AddIcon';
import ContactsAddForm from './ContactsAddForm';
import ModalWindow from './ModalWindow';
import { setContacts, addContacts } from '../../store/reducers/contactListSlice';
import { useAppDispatch } from '../../hooks/useAppDispatch';
import ISearchText from '../../@types/ISearchText';
import { setChatsSearchText, setContactsSearchText } from '../../store/reducers/sidePanelSearchInputSlice';

function ContactList({modal, setModal} : { modal: boolean,
     setModal: React.Dispatch<React.SetStateAction<boolean>> }) {
        
    const user: IUser = useAuth();
    const dispatch = useAppDispatch();

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState(chatId);
    
    const contacts = useAppSelector(state => state.contactListReducer);
    const searchInput: ISearchText = useAppSelector(state => state.sidePanelSearchInputReducer);
    const [contactToAdd, setContactToAdd] = useState('');

    const fetchContacts = async () => {
        const response = await ContactsService.getContacts(user.userId);
        console.log(response);
        dispatch(setContacts([...response.data]));
    }

    const filteredContacts = useMemo(() => {
        return contacts.filter(contact => contact.contactName.includes(searchInput.contactsSearchText));
    }, [searchInput.contactsSearchText, contacts]);


    useEffect(() => {
        dispatch(setChatsSearchText(''));
        fetchContacts();
    }, []);

    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    useEffect(() => {
        if (!modal)
            setContactToAdd('');
    }, [modal])

    const addContact = async () => {
        const response = await ContactsService.addContact(user.userId, contactToAdd);
        dispatch(addContacts(response.data));
        setModal(false);
        dispatch(setContactsSearchText(''));
    }

    return (
        <div className={side.chats + custom_scroll}>
            {filteredContacts.length ? filteredContacts.map(contact => 
                <Link key={contact.contactId} to={contact.contactId} className={side.chat_open_link}
                onClick={() => 
                    setActiveChat(contact.contactId)
                }>
                    <ContactListElement activeChat={activeChat} contact={contact}/>
                </Link>
                
            ) : <div>no contacts</div> }

            <ModalWindow modal={modal} setModal={setModal}>
                <ContactsAddForm 
                setModal={setModal}
                cb={addContact}
                setContactName={setContactToAdd}
                contactName={contactToAdd}
                />
            </ModalWindow>
        </div>
    );
}

export default ContactList;