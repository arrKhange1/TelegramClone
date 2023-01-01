import React from 'react';
import CallIcon from '../../icons/CallIcon';
import MoreIcon from '../../icons/MoreIcon';
import SearchIcon from '../../icons/SearchIcon';
import msgsHeader from '../../styles/messages_panel/header.module.css';

function Controls() {
    return (
        <div className={msgsHeader.controls}>
            <SearchIcon className={msgsHeader.search_icon} />
            <CallIcon className={msgsHeader.call_icon}/>
            <MoreIcon className={msgsHeader.more_icon} />
        </div>
    );
}

export default Controls;