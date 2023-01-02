import React from 'react';
import classes from '../styles/side_panel/side.module.css';

let lastX: number;
let chat_panel: any;

export const resize = (e: React.MouseEvent<HTMLDivElement>) => {
    chat_panel = document.querySelector('.' + classes.side_panel)!;
    if (e.button === 0) {
        lastX = e.clientX;
        window.addEventListener('mousemove', moving);
        e.preventDefault();
    }
}

const moving = (e: MouseEvent) => {
    if (e.buttons === 0) 
        window.removeEventListener('mousemove', moving);
    else {
        const dist: number = e.clientX - lastX;
        let newWidth: number = chat_panel.offsetWidth + dist;
        chat_panel.style.width = newWidth + 'px';
        lastX = e.clientX;
    }
}