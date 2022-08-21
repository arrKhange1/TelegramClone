import React from 'react';
import { IOption } from '../../@types/IOption';
import side from '../../styles/side_panel/side.module.css';
import CustomPopup from '../UI/CustomPopup/CustomPopup';
import PopupBackArrow from '../UI/CustomPopup/PopupBackArrow';

function SidePanelHeader({selectedOption, setSelectedOption} :
     {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    selectedOption: string}) {

    const options: IOption[] = [
        {name: 'Contacts'}
    ];

    return (
        <div className={side.search}>
            {selectedOption ? <PopupBackArrow setSelectedOption={setSelectedOption}/>  :
                <CustomPopup setSelectedOption={setSelectedOption} options={options}/>
            }
        </div>
    );
}

export default SidePanelHeader;