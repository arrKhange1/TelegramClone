import React, { useEffect, useState } from 'react';
import { IOption } from '../../@types/IOption';
import { useAppSelector } from '../../hooks/useAppSelector';
import { setChatsSearchText, setContactsSearchText } from '../../store/reducers/sidePanelSearchInputSlice';
import side from '../../styles/side_panel/side.module.css';
import CustomPopup from '../UI/CustomPopup/CustomPopup';
import PopupBackArrow from '../UI/CustomPopup/PopupBackArrow';
import CustomSearch from '../UI/CustomSearchInput/CustomSearch';

function SidePanelHeader({selectedOption, setSelectedOption} :
     {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    selectedOption: string}) {

    const [isSearchActive, setIsSearchActive] = useState<boolean>(false);
    const searchInput = useAppSelector(state => state.sidePanelSearchInputReducer);

    const options: IOption[] = [
        {img: 'imgs/contacts_icon.png', name: 'Contacts'}
    ];

    return (
        <div className={side.search} >
            {selectedOption || isSearchActive ? <PopupBackArrow setSelectedOption={setSelectedOption}/>  :
                <CustomPopup setSelectedOption={setSelectedOption} options={options}/>
            }
            { selectedOption === 'Contacts' ? 
            <CustomSearch 
                isSearchActive={isSearchActive}     
                setIsSearchActive={setIsSearchActive} 
                placeholder="Type contact name here..."
                setSearchText = {setContactsSearchText} 
                searchText = {searchInput.contactsSearchText}
            /> :
            <CustomSearch 
                isSearchActive={isSearchActive} 
                setIsSearchActive={setIsSearchActive} 
                placeholder="Type chat name here..." 
                setSearchText = {setChatsSearchText} 
                searchText = {searchInput.chatsSearchText}
            /> }
        </div>
    );
}

export default SidePanelHeader;