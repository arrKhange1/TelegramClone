import classes from '../styles/home/home.module.css';

let lastX: number;
let chat_panel: any;

export const resize = (e: any) => {
    chat_panel = document.querySelector('.' + classes.chat_panel)!;
    console.log('.' + classes.chat_panel, chat_panel);
    if (e.button === 0) {
        lastX = e.clientX;
        console.log(lastX);
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
        console.log(chat_panel.style.width); // solve problem with quarter mil renders
        lastX = e.clientX;
    }
}