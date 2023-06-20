import React, {useState} from 'react'
import { Container, Row, Col} from 'react-bootstrap';
import Jumbotron from '../Components/Jumbotron';
import '../HomePage.css';
import book from '../book.jpg';
import {PostAPI} from "../services/BookService";
import BookItem from "../Components/BookItem";
import {IBook} from "../models/IBook";
import BookCard from '../Components/BookCard';

export default function HomePage() {

  const [limit, setLimit] = useState(4);
  const {data: books, error, isLoading, refetch} =  PostAPI.useFetchAllBooksQuery(limit)

  function onclick () {
    window.location.assign('http://localhost:3000/auth/');
  }

  const handleRemove = (book : IBook) => {
    //deleteBook(book)
  }
  
  return (
    <div>
      <div className="blockRev">
        <p className="blockRev-text">
            ОГРОМНАЯ БАЗА <br/>
          КНИЖНЫХ РЕЦЕНЗИЙ 
        </p>
         <button className="buttonHome"  onClick={() => onclick()}>ПЕРЕЙТИ</button>
    
      </div>
      <Container className="blockAbout">
        <Row >
            <i id="menu" className="material-icons">school</i> 
        </Row>
        <Row >
           <h3>Заголовок о том какие мы классные</h3>
      
        </Row>
        <Row>
          <Col className="blocktext">
            <p>
            Maecenas feugiat hendrerit turpis at rhoncus. Phasellus at ligula et nisl consectetur scelerisque. Nulla tempus laoreet pulvinar. Donec Maecenas feugiat hendrerit turpis at rhoncus. Phasellus at ligula et nisl consectetur scelerisque. Nulla tempus laoreet pulvinar. Donec Maecenas feugiat hendrerit turpis at rhoncus. Phasellus at ligula et nisl consectetur scelerisque. Nulla tempus laoreet pulvinar. Donec 
            </p>
          </Col>
          <Col  className="blocktext">
          <p>
          laoreet sapien eu metus. Donec ac massa fringilla, eleifend odio vel, tincidunt augue. Sed dictum eleifend.Maecenas feugiat hendrerit turpis at rhoncus. Phasellus at ligula et nisl consectetur scelerisque. Nulla tempus laoreet pulvinar. Donec Maecenas feugiat hendrerit turpis at rhoncus. Phasellus at ligula et nisl consectetur scelerisque. Nulla tempus laoreet pulvinar. Donec 
          </p>
          </Col>
          
        </Row>
      </Container>
      <Jumbotron/>
      <Container className="blockAbout">
        <Row >
            <i id="menu" className="material-icons">school</i> 
        </Row>
        <Row >
           <h3>НАШИ КНИГИ</h3>
      
        </Row>
        <Row>
          {books && books.slice(2, 6).map(book =>
                        <BookCard key={book.bookId} book={book} remove={handleRemove}/>
                    )}
        </Row>
       
      </Container>
    
    </div>
  )
}