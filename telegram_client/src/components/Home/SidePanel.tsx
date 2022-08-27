import React, { useState } from 'react';
import side from '../../styles/side_panel/side.module.css';
import Contacts from './Contacts';
import ChatList from './ChatList';
import SidePanelHeader from './SidePanelHeader';

function SidePanel() {

    const [selectedOption, setSelectedOption] = useState('');

    return (
        <div className={side.side_panel}> 

            <SidePanelHeader selectedOption={selectedOption} setSelectedOption={setSelectedOption}/>
            
            {selectedOption === 'Contacts' && <Contacts/>}
            {selectedOption === '' && <ChatList/>}
        </div>
    );
}

export default SidePanel;