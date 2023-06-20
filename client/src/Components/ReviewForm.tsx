import React, {useState} from 'react';
import {Form, Button} from 'react-bootstrap'; 
import rev from '../rev.jpg'
import '../Form.css'
import { ReviewAPI } from '../services/ReviewService';
import { PostAPI } from '../services/BookService';
import { UserAPI } from '../services/UserService';
import { IReviewAdd } from '../models/IReview';
import { isNumericLiteral } from 'typescript';


export default function ReviewForm() {


  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)
  
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  const [flag, setFlag] = useState(0)
   const {data : books} = PostAPI.useFetchAllBooksQuery(10)
   
   

   var [BookName, setBookName] = useState('')
   const [Tags, setTags] = useState('')
   var BookId = 0
   const [Title, setTitle] = useState('')
   const [Datatext, setDatatext] = useState('')
   const [Raiting, setRaiting] = useState('')
   const [Message, setMessage] = useState('Рецензия успешно добавлена')
   

   
   
   const [createReview, {}] = ReviewAPI.useCreateReviewMutation()
    const handleCreate = async (e: any) => {
        e.preventDefault();

        if (books){
            for (let i = 0; i < books.length; i++) {
                if (books[i].bookName === BookName){
                    setFlag(1)
                }
           }
           }

        var num = 0 
        if (users){
             num = 0 + users?.userId
        }
        const userId = num
        const tags = Tags
        const bookName = BookName
        const title =  Title 
        const raitingBook : number = +Raiting
        console.log(typeof(raitingBook))
        console.log(raitingBook)
        if (BookName === ''|| Title === ''|| Datatext === '' || Raiting === ''){
            
            alert("Пожалуйста заполните все поля")
        }
        else  if (raitingBook < 0 || raitingBook > 5 ){
            alert("Введен некорректный рейтинг")
            
        }
        else  if (isNaN(parseFloat(Raiting))){
            alert("Введен некорректный рейтинг")
            
        }
        else{
            
            if (books){
            for(var i = 0; i < books?.length; i++){
                if (books[i].bookName === BookName){
                    alert("Рецензия успешно добавлена")
                    break
                }
                
            } 
            if (i ===  books?.length)
            {
                alert("Данной книги нет в базе")
            }
        }
    }
       
    
        const numLikes = 0
        const review_data = Datatext
        const public_date = new Date()
        await createReview({userId: userId, bookName: bookName, title : title, raitingBook: raitingBook, review_data : review_data, tags: tags})
       
    }

  return (
    <div className="addrev">
        <div className="titleaddrev">ДОБАВИТЬ РЕЦЕНЗИЮ</div>
        <div className="addcontent">
            <div className="imgrev">
                <img className="imgformrev" src={rev}/>
            </div>
            <div className="formcontent">
                <Form onSubmit={handleCreate}>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="label">Название книги</Form.Label>
                        <Form.Control className="input"  placeholder="Введите название"  value={BookName}
                        onChange={e => setBookName(e.target.value)}/>               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="label">Заголовок</Form.Label>
                        <Form.Control className="input"  placeholder="Введите заголовок" value={Title}
                        onChange={e => setTitle(e.target.value)} />               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="label">Теги(через пробел)</Form.Label>
                        <Form.Control className="input" placeholder="Введите теги" value={Tags}
                        onChange={e => setTags(e.target.value)}/>               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="label">Содержание рецензии</Form.Label>
                        <div className='scroll'>
                            <Form.Control className="inputdata"  placeholder="Введите содержание" value={Datatext}
                        onChange={e => setDatatext(e.target.value)}/> 
                        </div>
                                      
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <Form.Label className="label">Оценка книги(от 1 до 5)</Form.Label>
                        <Form.Control  className="input" placeholder="Введите оценку" value={Raiting}
                        onChange={e => setRaiting(e.target.value)}/>
                    </Form.Group>
                    
                    <Button className="butpush" variant="primary" type="submit">
                        Отправить
                    </Button>
                </Form>
            </div>
        </div>      
    </div>
  )
  }
