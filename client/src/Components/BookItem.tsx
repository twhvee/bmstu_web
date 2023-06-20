import React, {FC, useState} from 'react';

import {Col, Card, Image} from "react-bootstrap";
import BookList from './BookList';
import '../App.css';
import "../Books.css";
import { IBook } from '../models/IBook';
import {UserAPI} from '../services/UserService';

interface InterBook {
     book : IBook;
     remove : (book : IBook) => void
    }; 

const BookItem : FC<InterBook> = ({book, remove }) => {

  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)
  

 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  var role = null
  if (users?.access_role == 'admin'){
    role = true
  }

  const handleRemove = (event : React.MouseEvent) => {
    event.stopPropagation()
    remove(book)

  }
  return (
    <Col md={3}>
      <div className='blockbook'>
      {
            role ?
            <div>
            <button className="deletebook" onClick={handleRemove} >
            <i className="material-icons">delete</i>
            </button>
            </div>
            :
            <p></p>
        }
        <div className="cardBook">
              <Image width={130} height={180} src={book.path}/>
              <p className="TextBookName">{book.bookName}</p>
              <p className="TextAuthor">{book.author}</p>

          </div>  
      </div>
                     
    </Col>
  )
}

export default  BookItem;