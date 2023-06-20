import React, { useEffect } from 'react'
import { Container, Row, Image } from 'react-bootstrap';
import '../Books.css';
import BookList from '../Components/BookList';
import {useAppDispatch, useAppSelector} from '../hooks/redux';
import BookItem from '../Components/BookItem';
import '../App.css';


export default function Books() {
  //const dispatch = useAppDispatch()
  //var {books} = useAppSelector(state => state.bookReducer)

  //useEffect(() => {
   // dispatch(fetchBooks())
  //}, [])
 
  return (
    <Container className='container-wrapbook'>
        <h2 className='TitleBook'> КНИЖНАЯ БИБЛИОТЕКА </h2>
        
        <BookList/>

    </Container>   
  )
}

