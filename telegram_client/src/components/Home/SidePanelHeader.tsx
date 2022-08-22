import React, { useState } from 'react';
import { IOption } from '../../@types/IOption';
import side from '../../styles/side_panel/side.module.css';
import CustomPopup from '../UI/CustomPopup/CustomPopup';
import PopupBackArrow from '../UI/CustomPopup/PopupBackArrow';
import CustomSearch from '../UI/CustomSearchInput/CustomSearch';

function SidePanelHeader({selectedOption, setSelectedOption} :
     {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    selectedOption: string}) {

    const [isSearchActive, setIsSearchActive] = useState(false);
    
    const options: IOption[] = [
        {name: 'Contacts'}
    ];

    return (
        <div className={side.search} >
            {selectedOption || isSearchActive ? <PopupBackArrow setSelectedOption={setSelectedOption}/>  :
                <CustomPopup setSelectedOption={setSelectedOption} options={options}/>
            }
            <CustomSearch isSearchActive={isSearchActive} setIsSearchActive={setIsSearchActive}/>
        </div>
    );
}

export default SidePanelHeader;