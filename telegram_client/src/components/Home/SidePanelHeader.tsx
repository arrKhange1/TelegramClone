import React from 'react';
import { IOption } from '../../@types/IOption';
import side from '../../styles/side_panel/side.module.css';
import CustomPopup from '../UI/CustomPopup/CustomPopup';

function SidePanelHeader({selectedOption, setSelectedOption} : {setSelectedOption:React.Dispatch<React.SetStateAction<string>>,
    selectedOption: string}) {

    const options: IOption[] = [
        {name: 'Contacts'}
    ];

    return (
        <div className={side.search}>
            {selectedOption ? <button type='button' onClick={() => setSelectedOption('')}>back</button> :
                <CustomPopup setSelectedOption={setSelectedOption} options={options}/>
            }
        </div>
    );
}

export default SidePanelHeader;