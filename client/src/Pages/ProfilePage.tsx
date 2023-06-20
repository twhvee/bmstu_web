import React, {useState} from 'react'
import BookForm from '../Components/BookForm'
import ReviewForm from '../Components/ReviewForm'
import UserItem from '../Components/UserItem'
import UserStore from '../store/UserStore'
import {Image} from 'react-bootstrap';
import '../App.css'
import { UserAPI } from '../services/UserService'




export default function ProfilePage() {
  //const UserModel = new UserStore()
  //const user = UserModel.users[0];
  
 
  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)

  if (name){
    //setUsername(name)
    
  }

 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)
  
  var role = null
  if (users?.access_role !== 'user'){
    role = true
  }

  //console.log(users)
  const clickout  = () =>{
    localStorage.removeItem('token');
    localStorage.removeItem('user');

    window.location.assign('http://localhost:3000/home/');
  }
  return (
    <div className="profileblock">
       <div className='userblockprofile'>
        <div className="userbackprofile"></div>
        <div className="useravatar">
          {users ?
             <Image className="avatar" src={users.avatar} />     
             :    
             <Image className="avatar" src={""} />
          }  
        </div>
        {users ?
          <div>
            <div className="usernameprofile">{users.login}</div>
              <div className="useremail">{users.email}</div>  
          </div>              
             :    
             <Image className="avatar" src={""} />
          }  
        
      
    </div>
    <button className="signout" onClick={clickout}>
        ВЫЙТИ
    </button>
       {role ?
            <div>
            <ReviewForm/>
            <BookForm/>
         </div>
            :
            <ReviewForm/>
       }
      
    </div>
  )
}
