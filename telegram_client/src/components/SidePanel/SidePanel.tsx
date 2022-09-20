import React, { useState } from 'react';
import side from '../../styles/side_panel/side.module.css';
import ContactList from './ContactList';
import ChatList from './ChatList';
import SidePanelHeader from './SidePanelHeader';
import AddButton from './AddButton';
import AddContactIcon from '../../icons/AddContactIcon';

function SidePanel() {

    const [selectedOption, setSelectedOption] = useState<string>('');

    return (
        <div className={side.side_panel}> 

            <SidePanelHeader selectedOption={selectedOption} setSelectedOption={setSelectedOption}/>
            
            {selectedOption === 'Contacts' && <ContactList/>}
            {selectedOption === '' && <ChatList/>}

            <AddButton addCallback={() => console.log('chat')}>
                <AddContactIcon/>
            </AddButton>
        </div>
    );
}

export default SidePanel;