import React from 'react'
import { Container, Row } from 'react-bootstrap';
import RevComStore from '../store/RevComStore';
import ReviewItem from '../Components/BookList';
import UserList from '../Components/UserList';




export default function Reviews() {
  return (
      <Container className='container-wrapuser'>
        <h2 className='TitleUser'> Пользователи </h2>
        <UserList/>

    </Container>

  )
}