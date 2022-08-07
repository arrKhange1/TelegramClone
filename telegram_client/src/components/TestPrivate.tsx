import React from 'react';
import { useAuth } from '../hooks/useAuth';
import { $api } from '../http/axios';

function TestPrivate() {

    const user = useAuth();

    const click = () => {
        const response = $api.get('api/tokentest/authorized');
        console.log('private route accessed: ', response);
    }

    console.log(user);

    return (
        <div>
            <button
             type='button'
             onClick={click}
            > Test </button>
        </div>
    );
}

export default TestPrivate;