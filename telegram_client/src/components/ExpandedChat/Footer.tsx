import React, { HtmlHTMLAttributes, useEffect, useRef, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useAuth } from '../../hooks/useAuth';
import { $api } from '../../http/axios';
import AttachmentIcon from '../../icons/AttachmentIcon';
import SendIcon from '../../icons/SendIcon';
import SmileIcon from '../../icons/SmileIcon';
import VoiceRecordIcon from '../../icons/VoiceRecordIcon';
import footer from '../../styles/messages_panel/footer.module.css';



function Footer({textMsg, setTextMsg, sendMsg} : {sendMsg: (e:React.MouseEvent<HTMLDivElement>) => Promise<void>,
     textMsg: string, setTextMsg: React.Dispatch<React.SetStateAction<string>> }) {

    const chatId = useParams().chatId;
    const user = useAuth();

    const record = (e: React.MouseEvent<HTMLDivElement>) => {

    };

    return (
        <div className={footer.container}>
            <div className={footer.message}>
                <div className={footer.message_container}>
                    <SmileIcon className={footer.smile_icon} />
                </div>

                <label className={footer.message_input}>
                    <textarea
                        placeholder='Message'
                        value={textMsg}
                        onChange={
                            (e: React.ChangeEvent<HTMLTextAreaElement> ) =>
                            setTextMsg(e.target.value)}
                     />
                </label>
                
                <div className={footer.message_container}>
                    <AttachmentIcon className={footer.attachment_icon} />
                </div>
                
            </div>
            <div className={footer.send} onClick={textMsg ?
                sendMsg : record}>
                {textMsg ? 
                <SendIcon className={footer.send_icon} /> :
                <VoiceRecordIcon className={footer.voice_record_icon} /> }
            </div>
            
        </div>
    );
}

export default Footer;