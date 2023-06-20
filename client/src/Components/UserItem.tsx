import React, {FC} from 'react';
import {Image} from 'react-bootstrap';
import '../App.css'
import { IUser } from '../models/IUser';

interface InterUser {
      user : IUser;
      remove : (user : IUser) => void
     }; 
     

const UserItem : FC<InterUser> = ({user, remove }) => {

      const handleRemove = (event : React.MouseEvent) => {
        event.stopPropagation()
        remove(user)
    
      }
  return (
    <div className='userblock'>
      <button  className="deleteuser" onClick={handleRemove} >
          <i className="material-icons">delete</i>
        </button>
        <div className="userback"></div>
        <div className="useravatar">
            <Image className="avatar" src={user.avatar} />
        </div>
        <div className="username">{user.login}</div>
        <div className="useremail">{user.email}</div>
      
    </div>
  )
}

export default UserItem;
