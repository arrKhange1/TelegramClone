import React, { useEffect, useRef, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import RequireAuth from './components/auth/RequireAuth';
import Home from './components/Home';
import TestPrivate from './components/TestPrivate';
import { useAuth } from './hooks/useAuth';


function App() {

  return (
  <BrowserRouter>
    <Routes>
      <Route
       path='/'
       element={
        <RequireAuth>
          <TestPrivate/> 
        </RequireAuth>
       } />
       
      <Route path='/login' element={<Login/>} />
      <Route path='/register' element={<Register/>} />
    </Routes>
  </BrowserRouter>
  );

}

export default App;
