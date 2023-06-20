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

const BookCard : FC<InterBook> = ({book, remove }) => {
  return (
    <Col md={3}>
      
        <div className="cardBook">
              <Image width={130} height={180} src={book.path}/>
              <p className="TextBookName">{book.bookName}</p>
              <p className="TextAuthor">{book.author}</p>

          </div>  
      
                     
    </Col>
  )
}

export default  BookCard;