import React, { useState } from 'react';
import side from '../../styles/side_panel/side.module.css';
import ContactList from './ContactList';
import ChatList from './ChatList';
import SidePanelHeader from './SidePanelHeader';
import AddButton from './AddButton';
import AddContactIcon from '../../icons/AddContactIcon';
import ModalWindow from './ModalWindow';
import ContactsAddForm from './ContactsAddForm';

function SidePanel() {

    const [selectedOption, setSelectedOption] = useState<string>('');
    const [modal, setModal] = useState(false);


    return (
        <div className={side.side_panel}> 

            <SidePanelHeader selectedOption={selectedOption} setSelectedOption={setSelectedOption}/>
            
            {selectedOption === 'Contacts' && <ContactList modal={modal} setModal={setModal}/>}
            {selectedOption === '' && <ChatList modal={modal} setModal={setModal}/>}

            <AddButton addCallback={() => setModal(true)}>
                <AddContactIcon/>
            </AddButton>

        </div>
    );
}

export default SidePanel;