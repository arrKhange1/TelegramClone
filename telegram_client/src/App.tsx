import React, { useEffect, useRef, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './components/auth/Login';
import RequireAuth from './components/auth/RequireAuth';
import Home from './components/Home';


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
       
       } />
      
      <Route path='/login' element={<Login/>} />
    </Routes>
  </BrowserRouter>
  );

}

export default App;
