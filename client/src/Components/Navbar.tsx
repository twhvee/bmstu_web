import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Offcanvas from 'react-bootstrap/Offcanvas';
import '../App.css';
import React, { useState } from 'react';
import Menu from './Menu';
import { Dispatch, SetStateAction, FunctionComponent } from 'react';
import {userst} from "../Pages/Auth";
import { useRootStore } from '..';
import {UserAPI} from '../services/UserService';

interface MenuLink{
  value: string;
  href: string;
}

interface Props {
  items: MenuLink[];
  active : boolean;
  setActive: Dispatch<SetStateAction<boolean | null>>;
}
export default function Navbar() {

  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)


 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  const usertoken = localStorage.getItem('token')
 
  const {userstore} = useRootStore()
  console.log(userstore.isAuth)
  const [menuActive, setMenuActive] = useState<boolean | null>(false)
  var itemsArr : MenuLink[] = []

  if (users?.access_role === "admin"){
    itemsArr  = [
      {
        value: 'ГЛАВНАЯ',
        href: '/home',
      },
      {
        value: 'РЕЦЕНЗИИ',
        href: '/reviews',
      },
      {
        value: 'КНИГИ',
        href: '/books'
      },
      {
        value: 'ПРОФИЛЬ',
        href: '/profile'
      },
      {
        value: 'ПОЛЬЗОВАТЕЛИ',
        href: '/users',
      }
    ]

  }
  else if (usertoken !== null){
    itemsArr  = [
      {
        value: 'ГЛАВНАЯ',
        href: '/home',
      },
      {
        value: 'РЕЦЕНЗИИ',
        href: '/reviews',
      },
      {
        value: 'КНИГИ',
        href: '/books'
      },
      {
        value: 'ПРОФИЛЬ',
        href: '/profile'
      },
    ]
  }
  else{
     itemsArr  = [
      {
        value: 'ГЛАВНАЯ',
        href: '/home',
      },
      {
        value: 'РЕЦЕНЗИИ',
        href: '/reviews',
      },
      {
        value: 'КНИГИ',
        href: '/books'
      },
      {
        value: 'ВОЙТИ',
        href: '/auth',
      }
    ]
  }

  function onclick () {
    window.location.assign('http://localhost:3000/home/');
  }
  
  return (
    <>
      <nav>
        <div className="nav-wrapper">
          <p className="Logo-nav" onClick={onclick}> RevWorld</p>
          <div className="burger-btn" onClick ={()=> setMenuActive(!menuActive)}>
            <i id="menu" className="material-icons">dehaze</i>
          </div>
        </div>
      </nav>
      <Menu active={menuActive} setActive = {setMenuActive} items={itemsArr} />
      
    </>
  )
}
