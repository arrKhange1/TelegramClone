import React from 'react';
import side from '../../styles/side_panel/side.module.css';

function AddButton({addCallback, children} : {addCallback: () => void, children: JSX.Element}) {
    return (
        <button type='button' onClick={addCallback} className={side.add_button}>
            {children}
        </button>
    );
}

export default AddButton;