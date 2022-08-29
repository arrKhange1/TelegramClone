import IChat from '../../@types/IChat';
import side from '../../styles/side_panel/side.module.css';

function ChatListElement({activeChat, chat} : {activeChat: string,
    chat: IChat}) {
    
    return (
        <div className={activeChat === chat.name ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <img src={chat.img} className={side.chat_img} alt='asap'/>
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{chat.name}</div>
                <div>{chat.last_msg}</div>
            </div>
            <div className={`${side.chat_content} ${side.chat_end}`}>
                <div>{chat.last_msg_date}</div>
                <div>{chat.unread_msgs}</div>
            </div>
        </div>
    );
}

export default ChatListElement;