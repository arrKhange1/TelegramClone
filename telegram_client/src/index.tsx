import React from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import App from './App';
import { useAppDispatch } from './hooks/useAppDispatch';
import { signIn } from './store/reducers/authSlice';
import { setupStore } from './store/store';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const store = setupStore();
const userInfo = localStorage.getItem('userInfo');
if (userInfo)
  store.dispatch(signIn(JSON.parse(userInfo)));


root.render(
  <Provider store={store}>
    <App/>
  </Provider>
  
    
);


