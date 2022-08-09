import React from 'react';
import { Outlet } from 'react-router-dom';

function Authentication() {
    
    return (
        <div style={{background:'blue'}}>
            <Outlet/>
        </div>
    );
}

export default Authentication;