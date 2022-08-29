import React, { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import home from '../../styles/home/home.module.css';
import side from '../../styles/side_panel/side.module.css';
import ContactListElement from './ContactListElement';
import IContact from '../../@types/IContact';

function ContactList() {

    const contacts: IContact[] = [
        {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Vitya', 
          last_seen: 'yesterday'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Sasha', 
          last_seen: '2:40 PM'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'name4', 
          last_seen: '11:10 AM'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Dasha', 
          last_seen: 'today'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Petya', 
          last_seen: '1:40 PM'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Vasya', 
          last_seen: 'today'},
          {img: 'https://i0.wp.com/networthheightsalary.com/wp-content/uploads/2020/02/A-Guide-Through-the-List-of-ASAP-Rocky’s-Ex-Girlfriends-and-Associations-1200x900.jpg', name:'Vasya', 
          last_seen: 'today'},
    ]

    const custom_scroll: string = ` ${home.bar_back} ${home.bar_thumb}`;

    const chatId: string = useParams().chatId!;
    const [activeChat, setActiveChat] = useState(chatId);
    useEffect(() => {
        setActiveChat(chatId);
    }, [chatId])

    return (
        <div className={side.chats + custom_scroll}>
            {contacts.map(contact => 
                <Link to={contact.name} className={side.chat_open_link}
                onClick={() => 
                    setActiveChat(contact.name)
                }>
                    <ContactListElement activeChat={activeChat} contact={contact}/>
                </Link>
                
            )}
        </div>
    );
}

export default ContactList;