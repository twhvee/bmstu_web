import React, {useState} from 'react';
import { Container, Form, Button} from 'react-bootstrap';
import '../AuthStyle.css'
import {observer} from "mobx-react-lite";
import {loginfunc, registration} from "../http/UserAPi";
import UserStore from '../store/UserStore';
import {useNavigate} from "react-router-dom";
import { useRootStore } from '..';
import { UserAPI } from '../services/UserService';
import { AuthModel } from "../models/IUser";
import { IToken } from "../models/IToken";
import jwt_decode from "jwt-decode";

export const userst = new UserStore();
 
const Auth = observer(() =>{
    //const userst = new UserStore();
    const {userstore} = useRootStore()
    const history = useNavigate ()
    const [login, setLogin] = useState('')
    const [password, setPassword] = useState('')
    
    /*
    const [createToken, {data}] = UserAPI.useCreateTokenMutation()
    const click = async (e: any) => {
        e.preventDefault();
        let user : AuthModel = {
            login : login,
            password : password
        }
       
        await createToken(user)
        const str = "" + data?.access_token
        const name = "" + data?.username
        console.log(data?.access_token) 

        localStorage.setItem('token', str)
        localStorage.setItem('user', name)
        window.location.assign('http://localhost:3000/home/');

    }
    */

    
    const click = async () => { 
        try {

            let data;  
            
            let user : AuthModel = {
                login : login,
                password : password
            }
            
            data = loginfunc(user);   
            //history("/home")
            
      
        } catch (e:any) {
            alert(e.response.data.message)
        }

    }
    
    
  function onclick () {
    window.location.assign('http://localhost:3000/register/');
  }
  return (
    <div className='authpage'>      
        <div className='main'>
          <div className="login-html">
            <h1 className='head'>АВТОРИЗАЦИЯ</h1>
            <div className="hr"></div>
                <Form className='formauth'>
                
                    <Form.Group className="mb-3" controlId="formBasicLogin">
                        <Form.Label className="labelauth">Логин</Form.Label>
                        <Form.Control className="inputauth"  placeholder="Введите логин" value={login}
                        onChange={e => setLogin(e.target.value)}/>               
                    </Form.Group>
                    

                  
                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label className="labelauth">Пароль</Form.Label>                   
                        <Form.Control className="inputauth" type="password" placeholder="Введите пароль" value={password}
                        onChange={e => setPassword(e.target.value)} />               
                    </Form.Group>
                    <div className="hr"></div>
                    <Button className="butpush" variant="primary" type="submit" onClick={click}>
                        ВОЙТИ
                    </Button>
                    <Button className="butpush" variant="primary" onClick={() => onclick()}>
                        РЕГИСТРАЦИЯ
                    </Button>
                </Form>
               

          </div>
      </div>
    </div>
      
  )

})

export default Auth;

