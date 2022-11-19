import IChat from '../../@types/IChat';
import side from '../../styles/side_panel/side.module.css';

function ChatListElement({activeChat, chat} : {activeChat: string,
    chat: IChat}) {
        
    return (
        <div className={activeChat === chat.chatId ? `${side.chat} ${side.active}` :
            `${side.chat}`} >
            <img src='' className={side.chat_img} alt='asap'/>
            <div className={`${side.chat_content} ${side.chat_center}`}>
                <div>{chat.chatName}</div>
                <div>{chat.lastMessageType === "message" ? `${chat.lastMessageSender}: ${chat.lastMessageText}` :
                    `${chat.lastMessageSender} ${chat.lastMessageText}`}</div>
            </div>
        </div>
    );
}

export default ChatListElement;