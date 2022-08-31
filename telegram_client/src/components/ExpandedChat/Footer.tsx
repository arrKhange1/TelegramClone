import React from 'react';
import footer from '../../styles/messages_panel/footer.module.css';

function Footer() {
    return (
        <div className={footer.container}>
            <div className={footer.message}>
                <div className={footer.message_container}>
                    <img  src="imgs/smile.png" alt="" />
                </div>

                <label className={footer.message_input}>
                    <input  type="text" placeholder='Message' />
                </label>
                
                <div className={footer.message_container}>
                    <img  src="imgs/attachment.png" alt="" />
                </div>
                
            </div>
            <div className={footer.send}>
                <img src="imgs/voice_record.png" alt="" />
            </div>
            
        </div>
    );
}

export default Footer;