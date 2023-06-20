import React from 'react';
import { Container} from "react-bootstrap";
import '../App.css';
import catback from '../book.jpg';
import styled from 'styled-components';

const Styles = styled.div `
    .jumbo{
        background :url(${catback}) no-repeat fixed bottom;
        background-size: cover;
        color: #efefef;
        height: 400px;
        position: relative;
        z-index: -2;
    }

    .overlay{
        background-color: #000;
        opacity: 0.6;
        position: absolute;
        top: 0;
        left: 0;
        bottom: 0;
        right: 0;
        z-index: -1;
    }
`
function redclick () {
    window.location.assign('http://localhost:3000/register/');
  }
  
const Jumbotron = () => (
    <Styles>
    <div className="jumbotron jumbo">
        <div className="overlay"></div>
        <Container className='JumboBlock'>
        <h1>ВЫ НАЧИНАЮЩИЙ АВТОР? ПОЛУЧИТЕ ОТЗЫВЫ НА СВОЮ НОВУЮ КНИГУ</h1>
        <button className="buttonHome"  onClick={() => redclick()}>РЕГИСТРАЦИЯ</button>
        </Container>     
    </div>
    </Styles>
)

export default Jumbotron;