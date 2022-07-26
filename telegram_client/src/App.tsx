import * as signalR from '@microsoft/signalr';
import { useEffect } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Authentication from './components/auth/Authentication';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import RequireAuth from './components/auth/RequireAuth';
import ExpandedChat from './components/ExpandedChat/ExpandedChat';
import Home from './components/Home';
import { useAppSelector } from './hooks/useAppSelector';


function App() {

  return (
  <BrowserRouter>
    <Routes>
      <Route
       path='/'
       element={
        <RequireAuth>
           <Home/>
        </RequireAuth>
       } >
          <Route path=':chatId' element={<ExpandedChat/>} />
       </Route>
       
       <Route path='auth' element={<Authentication/>}>
          <Route index element={<Login/>} />
          <Route path='reg' element={<Register/>} />
       </Route>

    </Routes>
  </BrowserRouter>
  );

}

export default App;
