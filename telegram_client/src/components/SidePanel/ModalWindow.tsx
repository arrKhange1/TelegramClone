import React, { useEffect, useState } from 'react';


function ModalWindow({children} : {children : JSX.Element}) {
    
    return (
        <div>
            {children}
        </div>
    )
}

export default ModalWindow;