import React from 'react';
import { IOption } from '../../@types/IOption';
import side from '../../styles/side_panel/side.module.css';
import CustomPopup from '../UI/CustomPopup/CustomPopup';

function SidePanelHeader({setSelectedOption} : {setSelectedOption:React.Dispatch<React.SetStateAction<string>>}) {

    const options: IOption[] = [
        {name: 'Contacts'}
    ];

    return (
        <div className={side.search}>
            <CustomPopup setSelectedOption={setSelectedOption} options={options}/>
        </div>
    );
}

export default SidePanelHeader;