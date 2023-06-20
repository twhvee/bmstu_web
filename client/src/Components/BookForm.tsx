import React, {useState} from 'react'
import {Form, Button} from 'react-bootstrap'; 
import bookform from '../bookform.jpg'
import '../Form.css'
import { IBook } from '../models/IBook';
import { PostAPI } from '../services/BookService';




export default function BookForm() {
   const [BookName, setBookName] = useState('')
   const [Author, setAuthor] = useState('')
   const [Path, setPath] = useState('')
   const [flag, setFlag] = useState(0)
   const [flag2, setFlag2] = useState(0)

   console.log(BookName)
   const {data: books, error, isLoading, refetch} =  PostAPI.useFetchAllBooksQuery(100)
   const [createBook] = PostAPI.useCreateBookMutation()
    const handleCreate = async (e: any) => {
        e.preventDefault()
        
        console.log(BookName)
        console.log(Author)
        console.log(Path)
        if (BookName === ''|| Author === ''|| Path === ''){
            console.log("fdf")
            setFlag2(1)
            alert("Пожалуйста заполните все поля")
        }
        else{
            if (books){
            for(var i = 0; i < books?.length; i++){
                if (Path === books[i].path){
                    alert("Книга уже существует в базе")
                    break
                }
                
            } 
            if (i ===  books?.length)
            {
                alert("Книга успешно добавлена")
            }
        }

            
        }
        const bookname = BookName
        const author = Author
        const path = Path
        await createBook({bookName: bookname, author: author, path :path} as IBook)

  
        
           
        }
    
    
  return (
    <div className="addbook">
        <div className="titleaddbook">ДОБАВИТЬ КНИГУ</div>
        <div className="addcontentbook">
            <div className="imgbook">
                <img className="imgformbook" src={bookform}/>
            </div>
            <div className="formcontent">
                <Form onSubmit={handleCreate}>
                    <Form.Group className="mb-3" controlId="formBasicname">
                        <Form.Label className="label">Название</Form.Label>
                        <Form.Control className="input"  placeholder="Введите название" value={BookName}
                        onChange={e => setBookName(e.target.value)} />               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicauthor">
                        <Form.Label className="label">Автор</Form.Label>
                        <Form.Control className="input" placeholder="Введите автора" value={Author}
                        onChange={e => setAuthor(e.target.value)}/>               
                    </Form.Group>
                    <Form.Group className="mb-3" controlId="formBasicpath">
                        <Form.Label className="label">Обложка</Form.Label>
                        <Form.Control className="input" placeholder="Введите путь изображения для обложки" value={Path}
                        onChange={e => setPath(e.target.value)}/>               
                    </Form.Group>
                    <Button className="butpush"  variant="primary" type="submit">
                        Отправить
                    </Button>
                </Form>
            </div>
        </div>      
    </div>
  )
}
