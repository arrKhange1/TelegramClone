import home from '../../styles/home/home.module.css';
import {resize} from '../../services/ResizeService';
import SidePanel from './SidePanel';
import { Outlet } from 'react-router-dom';

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