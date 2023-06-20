import React from 'react'
import { Container } from 'react-bootstrap'
import '../App.css';


export default function Footer() {
  return (
    <Container fluid style={{backgroundColor: '#2c2c2c', color: '#957230'}}>
        <Container fluid className='footer_text'>
            <h5>RevWorld</h5>
        </Container>

    </Container>
  )
}
