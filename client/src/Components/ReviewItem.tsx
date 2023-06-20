import React, {FC, useState} from 'react'
import {Row, Image, Col} from "react-bootstrap";
import '../Reviews.css';
import {useNavigate} from "react-router-dom";
import { IReview } from '../models/IReview';
import {UserAPI} from '../services/UserService';

interface InterReview {
    review : IReview;
    remove : (review : IReview) => void;
    like : (review : IReview) => void};

    
const ReviewItem : FC<InterReview> = ({review, remove, like }) => {
  const history = useNavigate()
  //console.log("reviews" + '/' + props.rev.ReviewId)

  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)
  

 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  var role = null
  if (users?.access_role == 'admin'){
    role = true
  }

  
  const clicklike = (event : React.MouseEvent) => {
    event.stopPropagation()
    like(review)
  
  }

 const handleRemove = (event : React.MouseEvent) => {
   event.stopPropagation()
   remove(review)

 }

 //const data = review.public_date.slice(0,10).replaceAll('-', '.')
  return ( 
    <Row className='blockrev'>
        {
            role ?
            <div>
            <button className='deleterev' onClick={handleRemove} >
            <i className="material-icons">delete</i>
            </button>
            </div>
            :
            <p></p>
        }
       
        <div className='RevCard' >
       
        <div className='blockuser'>
            <Image className="imgUser" src={review.user.avatar}/>
            <p className='UserName'>{review.user.login}</p>          
        </div>
        <div className="tagblock">
                    {review.tags && review.tags.map(tag  =>
                    <p className='tagtext'>#{tag.tagName}</p>
                        )}
                </div>
        <div className="tagblock"> {review.raitingBook}<i id="menu" className="material-icons">grade</i></div>
        <div className='blockcontent'>
            <Col className="contentrev">
                <div className="titleblock">
                    <p className="revTitle">{review.title}</p>
                    <p className="revDate">{review.public_date.toLocaleString().slice(0,10).replaceAll('-', '.')}</p>
                </div>
                 <p className="textRev">{review.review_data}</p>
            </Col>
            <Col classname="blockimg">
            <Image  width={230} height={270} src={review.book.path}/>
            </Col>
        </div>
        <div className="butblock">        
                <button className="butComment" onClick={() => history("/reviews" + "/" + review.reviewId)}>
                    <i className="material-icons">ichat_bubble_outline</i>
                </button>         
                {
                    users ?

                    <div className="butLike" onClick={clicklike}>
                        <i className="material-icons">favorite_border</i>
                        <p className='numlikes'>{review.numLikes}</p>
                    </div>  
                    :
                    <div className="butLike" >
                        <i className="material-icons">favorite_border</i>
                        <p className='numlikes'>{review.numLikes}</p>
                    </div>  
                }
                        
        </div>    
    </div>
        
    </Row>
    
  )
}
export default ReviewItem;