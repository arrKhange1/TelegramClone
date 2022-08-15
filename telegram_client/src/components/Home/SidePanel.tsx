import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import classes from '../../styles/side_panel/side.module.css';
import home from '../../styles/home/home.module.css';
import Contacts from './Contacts';
import Chats from './Chats';
import CustomPopup from '../UI/CustomPopup/CustomPopup';
import PopupElement from '../UI/CustomPopup/PopupElement';
import popup from '../UI/CustomPopup/CustomPopup.module.css';

function SidePanel() {

    const [isContacts, setIsContacts] = useState(false);

    return (
        <div className={classes.side_panel}> 

            <div className={classes.search}>
                <CustomPopup setIsContacts={setIsContacts}/>
            </div>
            
            {isContacts ? <Contacts/> : <Chats/>}
        </div>
    );
}

export default SidePanel;