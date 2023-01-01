import { ActionCreatorWithPayload } from '@reduxjs/toolkit';
import React, { useEffect } from 'react';
import { useAppDispatch } from '../../../hooks/useAppDispatch';
import { useAppSelector } from '../../../hooks/useAppSelector';
import SearchIcon from '../../../icons/SearchIcon';
import search from './CustomSearch.module.css';

function CustomSearch({isSearchActive, setIsSearchActive, placeholder, setSearchText, searchText}:
    {isSearchActive:boolean, 
    setIsSearchActive:React.Dispatch<React.SetStateAction<boolean>>, placeholder: string,
    setSearchText: ActionCreatorWithPayload<string, string>, searchText: string}) {

    const dispatch = useAppDispatch();
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
            <SearchIcon className={searchSvgClasses.join(' ')} />
            <input 
                type="text"
                placeholder={placeholder}
                id={search.input}
                value={searchText}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => dispatch(setSearchText(e.target.value))}
            />
        </label>
    );
}

export default CustomSearch;