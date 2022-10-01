import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';
import { $api } from '../http/axios';
import AuthService from '../services/AuthService';

function TestPrivate() {

     // for dev purposes
    const userRedux = useAuth();
    const userLocalStorage = localStorage.getItem('userInfo');

    const click = () => {
        const response = $api.get('api/tokentest/authorized');
        console.log('private route accessed: ', response);
    }

     // for dev purposes
    console.log('Login (redux):', userRedux);
    console.log('Login (localStorage): ', userLocalStorage);

    return (
        <div>
            <button
             type='button'
             onClick={click}
            > Test </button>

            <button
             type='button'
             onClick={async () => { await AuthService.logout(); }}
            > Logout </button>
        </div>
    );
}

export default TestPrivate;