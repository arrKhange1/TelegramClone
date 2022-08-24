import React from 'react';
import reusableList from './ReusableList.module.css';

function ReusableList({children, list} : {
    children: JSX.Element, list: any[] 
}) {
    return (
        <div className={reusableList.list}>
            {list.map(el => 
                React.cloneElement(children, el)
            )}
        </div>
    );
}

export default ReusableList;