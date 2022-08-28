import React from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { useAppSelector } from '../../hooks/useAppSelector';
import { useAuth } from '../../hooks/useAuth';

function RequireAuth({children} : {children: JSX.Element}) {

    const isAuth: boolean = useAuth().isAuthenticated;

    if (!isAuth) {
        return <Navigate to='/auth' />
    }

    return children;
}

export default RequireAuth;