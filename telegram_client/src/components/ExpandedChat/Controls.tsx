import React from 'react';
import msgsHeader from '../../styles/messages_panel/header.module.css';

function Controls() {
    return (
        <div className={msgsHeader.controls}>
                <svg xmlns="http://www.w3.org/2000/svg">
                    <path d="M9.99997 2.5C11.3979 2.49994 12.7681 2.89061 13.9559 3.62792C15.1436 4.36523 16.1016 5.41983 16.7218 6.6727C17.342 7.92558 17.5997 9.32686 17.4658 10.7184C17.3319 12.11 16.8117 13.4364 15.964 14.548L20.707 19.293C20.8863 19.473 20.9904 19.7144 20.9982 19.9684C21.006 20.2223 20.9168 20.4697 20.7487 20.6603C20.5807 20.8508 20.3464 20.9703 20.0935 20.9944C19.8406 21.0185 19.588 20.9454 19.387 20.79L19.293 20.707L14.548 15.964C13.601 16.6861 12.4956 17.1723 11.3234 17.3824C10.1512 17.5925 8.9458 17.5204 7.80697 17.1721C6.66814 16.8238 5.62862 16.2094 4.77443 15.3795C3.92023 14.5497 3.27592 13.5285 2.8948 12.4002C2.51368 11.2719 2.40672 10.0691 2.58277 8.89131C2.75881 7.7135 3.2128 6.59454 3.90717 5.62703C4.60153 4.65951 5.51631 3.87126 6.57581 3.32749C7.63532 2.78372 8.80908 2.50006 9.99997 2.5ZM9.99997 4.5C8.54128 4.5 7.14233 5.07946 6.11088 6.11091C5.07943 7.14236 4.49997 8.54131 4.49997 10C4.49997 11.4587 5.07943 12.8576 6.11088 13.8891C7.14233 14.9205 8.54128 15.5 9.99997 15.5C11.4587 15.5 12.8576 14.9205 13.8891 13.8891C14.9205 12.8576 15.5 11.4587 15.5 10C15.5 8.54131 14.9205 7.14236 13.8891 6.11091C12.8576 5.07946 11.4587 4.5 9.99997 4.5Z"/>
                </svg>
                <svg xmlns="http://www.w3.org/2000/svg">
                    <path d="M7.05646 2.41844L8.22346 2.06668C9.54596 1.66804 10.959 2.31227 11.5253 3.5721L12.427 5.57782C12.9097 6.65165 12.6553 7.91366 11.7943 8.71661L10.3 10.1101C10.2563 10.1508 10.2286 10.2058 10.222 10.2652C10.1777 10.6623 10.4469 11.4357 11.0671 12.51C11.5182 13.2913 11.9264 13.8391 12.2739 14.1473C12.516 14.362 12.6493 14.4084 12.7061 14.3915L14.7164 13.7769C15.842 13.4328 17.0618 13.8431 17.7505 14.7976L19.0312 16.5726C19.8373 17.6898 19.6924 19.2311 18.6921 20.1784L17.8057 21.0178C16.8493 21.9236 15.4877 22.2611 14.219 21.907C11.4649 21.1383 8.99559 18.8141 6.78372 14.9831C4.56877 11.1467 3.79158 7.84222 4.50803 5.07043C4.8359 3.80195 5.80203 2.79656 7.05646 2.41844ZM7.48936 3.85461C6.7367 4.08148 6.15702 4.68472 5.9603 5.44581C5.35765 7.77732 6.04651 10.7062 8.08276 14.2331C10.1163 17.7552 12.3052 19.8155 14.6223 20.4622C15.3835 20.6747 16.2004 20.4722 16.7743 19.9287L17.6606 19.0893C18.1153 18.6587 18.1812 17.9581 17.8148 17.4503L16.5341 15.6753C16.221 15.2415 15.6666 15.0549 15.1549 15.2114L13.1396 15.8275C11.9699 16.1762 10.9082 15.2347 9.76811 13.26C8.9998 11.9293 8.64171 10.9006 8.73128 10.0987C8.77768 9.68322 8.97125 9.29812 9.27697 9.01303L10.7713 7.61958C11.1627 7.2546 11.2783 6.68096 11.0589 6.19286L10.1572 4.18714C9.89977 3.61449 9.25749 3.32165 8.65636 3.50285L7.48936 3.85461Z" />
                </svg>
                <svg xmlns="http://www.w3.org/2000/svg">
                    <path d="M12 7.75C11.0335 7.75 10.25 6.9665 10.25 6C10.25 5.0335 11.0335 4.25 12 4.25C12.9665 4.25 13.75 5.0335 13.75 6C13.75 6.9665 12.9665 7.75 12 7.75Z" /><path d="M12 13.75C11.0335 13.75 10.25 12.9665 10.25 12C10.25 11.0335 11.0335 10.25 12 10.25C12.9665 10.25 13.75 11.0335 13.75 12C13.75 12.9665 12.9665 13.75 12 13.75Z" /><path d="M10.25 18C10.25 18.9665 11.0335 19.75 12 19.75C12.9665 19.75 13.75 18.9665 13.75 18C13.75 17.0335 12.9665 16.25 12 16.25C11.0335 16.25 10.25 17.0335 10.25 18Z" />
                </svg>
        </div>
    );
}

export default Controls;