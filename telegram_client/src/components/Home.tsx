import home from '../styles/home/home.module.css';
import {resize} from '../services/ResizeService';
import SidePanel from './SidePanel/SidePanel';
import { Outlet } from 'react-router-dom';
import { useAppSelector } from '../hooks/useAppSelector';
import SignalRService from '../services/SignalRService';
import { useEffect } from 'react';

function Home() { 

    return (
        <div className={home.home}>

            <SidePanel/>
            <div className={home.border} onMouseDown={resize}></div>
            <Outlet/>

        </div>
    );
}

export default Home;