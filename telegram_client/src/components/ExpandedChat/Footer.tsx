import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import { useAuth } from '../../hooks/useAuth';
import { $api } from '../../http/axios';
import footer from '../../styles/messages_panel/footer.module.css';



function Footer({textMsg, setTextMsg, sendMsg} : {sendMsg: (e:React.MouseEvent<HTMLDivElement>) => Promise<void>,
        textMsg: string, setTextMsg: React.Dispatch<React.SetStateAction<string>>}) {

    const chatId = useParams().chatId;
    const user = useAuth();

    const record = (e: React.MouseEvent<HTMLDivElement>) => {

    };

    return (
        <div className={footer.container}>
            <div className={footer.message}>
                <div className={footer.message_container}>
                    <img  src="imgs/smile.png" alt="" />
                </div>

                <label className={footer.message_input}>
                    <input
                      type="text"
                     placeholder='Message'
                     onChange={
                        (e: React.ChangeEvent<HTMLInputElement> ) =>
                         setTextMsg(e.target.value)}
                     />
                </label>
                
                <div className={footer.message_container}>
                    <img  src="imgs/attachment.png" alt="" />
                </div>
                
            </div>
            <div className={footer.send} onClick={textMsg ?
                sendMsg : record}>
                {textMsg ? 
                <svg xmlns="http://www.w3.org/2000/svg"  viewBox="0 0 16 16">
                    <path d="M15.854.146a.5.5 0 0 1 .11.54l-5.819 14.547a.75.75 0 0 1-1.329.124l-3.178-4.995L.643 7.184a.75.75 0 0 1 .124-1.33L15.314.037a.5.5 0 0 1 .54.11ZM6.636 10.07l2.761 4.338L14.13 2.576 6.636 10.07Zm6.787-8.201L1.591 6.602l4.339 2.76 7.494-7.493Z"/>
                </svg> :
                <svg xmlns="http://www.w3.org/2000/svg"   viewBox="0 0 16 16">
                    <path d="M3.5 6.5A.5.5 0 0 1 4 7v1a4 4 0 0 0 8 0V7a.5.5 0 0 1 1 0v1a5 5 0 0 1-4.5 4.975V15h3a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1h3v-2.025A5 5 0 0 1 3 8V7a.5.5 0 0 1 .5-.5z"/>
                    <path d="M10 8a2 2 0 1 1-4 0V3a2 2 0 1 1 4 0v5zM8 0a3 3 0 0 0-3 3v5a3 3 0 0 0 6 0V3a3 3 0 0 0-3-3z"/>
                </svg>}
            </div>
            
        </div>
    );
}

export default Footer;