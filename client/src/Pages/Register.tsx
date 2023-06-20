import React, {useState} from 'react'
import { Container, Row, Col, Form, Button} from 'react-bootstrap';
import '../AuthStyle.css'
import { registration } from '../http/UserAPi';
import {useNavigate} from "react-router-dom";
import { UserAPI } from '../services/UserService';
import {AddModel} from '../models/IUser'

export default function HomePage() {

  function onclick () {
    window.location.assign('http://localhost:3000/auth/');
  }
  

  const history = useNavigate ()
  const [Login, setLogin] = useState('')
  const [Password, setPassword] = useState('')
  
  const [Avatar, setAvatar] = useState('')
  const [Type, setType] = useState('')
  const [Email, setEmail] = useState('')
  const {data: users, error, isLoading, refetch} =  UserAPI.useFetchAllUsersQuery(100)
    const [createUser, {}] = UserAPI.useCreateUserMutation()
   const handleCreate = async (e: any) => {
       e.preventDefault();

       if (Login === ''|| Email === ''|| Avatar === '' || Type === '' || Password === ''){
            
        alert("Пожалуйста заполните все поля")
       }
      else{
          
          if (users){
          for(var i = 0; i < users?.length; i++){
              if (users[i].email === Email){
                  alert("Пользователь с такой почтой уже зарегистрирован")
                  break
              }
              
          } 
          for(var j = 0; j < users?.length; j++){
            if (users[j].login === Login){
                alert("Пользователь с таким логином уже зарегистрирован")
                break
            }
            
        } 
        
      }
  }
       const login = Login  
       const email = Email
       const avatar = Avatar 
       const type = Type
       const password = Password
       await createUser({login : login, email : email, avatar : avatar, type : type, password : password })
       history("/auth")
   }

  const click = async () => {
      
      try {

          let data;          
          data = await registration({login : "123", email : "@123", avatar : "https://r.mt.ru/r18/photoCD26/20795682120-0/jpeg/bp.jpeg", type: "Да", password : "3213"});   
          console.log(data)       
          history("/auth")
      } catch (e:any) {
          alert(e.response.data.message)
      }

  }
  
  
  return (
    <div className='authpage'>      
        <div className='main'>
          <div className="login-html">
            <h1 className='head'>Регистрация</h1>
            <div className="hr"></div>
                <Form className='formauth' onSubmit={handleCreate}>
                
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="labelauth">Логин</Form.Label>
                        <Form.Control className="inputauth"  placeholder="Введите логин"  value={Login}
                        onChange={e => setLogin(e.target.value)}/>               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="labelauth">Почта</Form.Label>
                        <Form.Control className="inputauth" type="email" placeholder="Введите почту" value={Email}
                        onChange={e => setEmail(e.target.value)} />               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="labelauth">Аватар</Form.Label>
                        
                        <Form.Control className="inputauth"  placeholder="Введите путь изображения для аватарки" value={Avatar}
                        onChange={e => setAvatar(e.target.value)}/>               
                    </Form.Group>

                    <p className="labelauth">Зарегистрироваться как автор?</p>
                      <div className="radio">
                          <div className="rad">
                              <label className="labelauth" asp-for="Type">Да</label>
                              <input type="radio" className="inputr" value="Да" asp-for="Type" 
                        onChange={e => setType(e.target.value)}/>
                              
                          </div>
                          <div className="rad">
                              <label className="labelauth" asp-for="Type">Нет</label>
                              <input type="radio" className="inputr" value="Нет" asp-for="Type" 
                        onChange={e => setType(e.target.value)}/>
                          </div>
                      </div>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="labelauth">Пароль</Form.Label>                   
                        <Form.Control className="inputauth" type="password" placeholder="Введите пароль" value={Password}
                        onChange={e => setPassword(e.target.value)}/>               
                    </Form.Group>
                    <div className="hr2"></div>
                    <Button className="butpush" variant="primary" type="submit">
                        РЕГИСТРАЦИЯ
                    </Button>
                </Form>
               

          </div>
      </div>
    </div>
  )
}
