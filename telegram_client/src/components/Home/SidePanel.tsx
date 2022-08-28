import React, { useState } from 'react';
import side from '../../styles/side_panel/side.module.css';
import ContactList from './ContactList';
import ChatList from './ChatList';
import SidePanelHeader from './SidePanelHeader';

function SidePanel() {

    const [selectedOption, setSelectedOption] = useState<string>('');

    return (
        <div className={side.side_panel}> 

            <SidePanelHeader selectedOption={selectedOption} setSelectedOption={setSelectedOption}/>
            
            {selectedOption === 'Contacts' && <ContactList/>}
            {selectedOption === '' && <ChatList/>}
        </div>
    );
}

export default SidePanel;