import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Authentication from './components/auth/Authentication';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import RequireAuth from './components/auth/RequireAuth';
import TestPrivate from './components/TestPrivate';


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
       
       <Route path='auth' element={<Authentication/>}>
          <Route index element={<Login/>} />
          <Route path='reg' element={<Register/>} />
       </Route>

    </Routes>
  </BrowserRouter>
  );

}

export default App;
