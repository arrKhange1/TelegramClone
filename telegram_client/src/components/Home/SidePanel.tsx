import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import side from '../../styles/side_panel/side.module.css';
import home from '../../styles/home/home.module.css';
import Contacts from './Contacts';
import Chats from './Chats';
import CustomPopup from '../UI/CustomPopup/CustomPopup';
import PopupElement from '../UI/CustomPopup/PopupElement';
import popup from '../UI/CustomPopup/CustomPopup.module.css';
import SidePanelHeader from './SidePanelHeader';

function SidePanel() {

    const [selectedOption, setSelectedOption] = useState('');

    return (
        <div className={side.side_panel}> 

            <SidePanelHeader setSelectedOption={setSelectedOption}/>
            
            {selectedOption === 'Contacts' && <Contacts/>}
            {selectedOption === '' && <Chats/>}
        </div>
    );
}

export default SidePanel;