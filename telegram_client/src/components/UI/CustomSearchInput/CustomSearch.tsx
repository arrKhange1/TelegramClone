import React, { useEffect } from 'react';
import search from './CustomSearch.module.css';

function CustomSearch({isSearchActive, setIsSearchActive}:
    {isSearchActive:boolean, 
    setIsSearchActive:React.Dispatch<React.SetStateAction<boolean>>}) {

    const searchClasses: string[] = [search.search_input];
    const searchSvgClasses: string[] = [search.search_svg];

    if (isSearchActive) {
        searchClasses.push(search['search_input-active']);
        searchSvgClasses.push(search['search_svg-active'])
    }

    useEffect(() => {
        function toggleOffSearch() {
            setIsSearchActive(false);
        }

        document.addEventListener('click', toggleOffSearch);
        
        return function cleanup() {
            document.removeEventListener('click', toggleOffSearch);
        }
    }, [])


    return (
        <label htmlFor={search.input} className={searchClasses.join(' ')} onClick={(e:React.MouseEvent<HTMLLabelElement>) => {setIsSearchActive(true); e.stopPropagation()}}>
            <svg className={searchSvgClasses.join(' ')} xmlns="http://www.w3.org/2000/svg">
                <path d="M9.99997 2.5C11.3979 2.49994 12.7681 2.89061 13.9559 3.62792C15.1436 4.36523 16.1016 5.41983 16.7218 6.6727C17.342 7.92558 17.5997 9.32686 17.4658 10.7184C17.3319 12.11 16.8117 13.4364 15.964 14.548L20.707 19.293C20.8863 19.473 20.9904 19.7144 20.9982 19.9684C21.006 20.2223 20.9168 20.4697 20.7487 20.6603C20.5807 20.8508 20.3464 20.9703 20.0935 20.9944C19.8406 21.0185 19.588 20.9454 19.387 20.79L19.293 20.707L14.548 15.964C13.601 16.6861 12.4956 17.1723 11.3234 17.3824C10.1512 17.5925 8.9458 17.5204 7.80697 17.1721C6.66814 16.8238 5.62862 16.2094 4.77443 15.3795C3.92023 14.5497 3.27592 13.5285 2.8948 12.4002C2.51368 11.2719 2.40672 10.0691 2.58277 8.89131C2.75881 7.7135 3.2128 6.59454 3.90717 5.62703C4.60153 4.65951 5.51631 3.87126 6.57581 3.32749C7.63532 2.78372 8.80908 2.50006 9.99997 2.5ZM9.99997 4.5C8.54128 4.5 7.14233 5.07946 6.11088 6.11091C5.07943 7.14236 4.49997 8.54131 4.49997 10C4.49997 11.4587 5.07943 12.8576 6.11088 13.8891C7.14233 14.9205 8.54128 15.5 9.99997 15.5C11.4587 15.5 12.8576 14.9205 13.8891 13.8891C14.9205 12.8576 15.5 11.4587 15.5 10C15.5 8.54131 14.9205 7.14236 13.8891 6.11091C12.8576 5.07946 11.4587 4.5 9.99997 4.5Z"/>
            </svg>
            <input type="text" placeholder='Search' id={search.input}/>
        </label>
    );
}

export default CustomSearch;