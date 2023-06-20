
import React, {useContext, useEffect, useState} from 'react';
import {observer} from "mobx-react-lite";
import {RootStateContext} from "../index"
import {Row} from "react-bootstrap";
import '../App.css';

import { fetchBooks } from '../http/BookApi';

import {PostAPI} from "../services/BookService";
import BookItem from "./BookItem";
import {IBook} from "../models/IBook";

const BookList = () => {
    const [limit, setLimit] = useState(10);
    const {data: books, error, isLoading, refetch} =  PostAPI.useFetchAllBooksQuery(limit)
    const [deleteBook, {}] = PostAPI.useDeleteBookMutation()

    //console.log(books)
    
   // useEffect(() => {
        // setTimeout(() => {
        // setLimit(3)
        // }, 2000)
    //}, [])

    const handleRemove = (book : IBook) => {
        deleteBook(book)
    }

    return (
        <Row className="bookBlock">
             {books && books.map(book =>
                    <BookItem key={book.bookId} book={book} remove={handleRemove}/>
                )}
        </Row>
                
    );
};

export default BookList;
