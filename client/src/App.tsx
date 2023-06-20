import React from 'react';
import logo from './logo.svg';
import './App.css';
import AppRouter from './Components/AppRouter';
import { BrowserRouter } from 'react-router-dom';
import Footer from './Components/Footer';
import Navbar from './Components/Navbar';
import {observer} from "mobx-react-lite";

const App = observer(() => {
  return (
    <BrowserRouter>
      <Navbar/> 
      <AppRouter/> 
    </BrowserRouter>

  );
})

export default App;
