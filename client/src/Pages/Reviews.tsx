import React, { useState } from 'react'
import { Container, Row } from 'react-bootstrap';
import RevComStore from '../store/RevComStore';
import ReviewList from '../Components/ReviewList';
import '../Reviews.css';
import ReviewItem from '../Components/ReviewItem';
import {ReviewAPI} from "../services/ReviewService";
import { IReview } from '../models/IReview';
import { click } from '@testing-library/user-event/dist/click';

export default function Reviews() {
  
  const [tag, setTag] = useState('')
  /*
  var num = 0
  
  const handle =() => {
    num = 1 
    //console.log(num)
 }
 */
    const [limit, setLimit] = useState(100)
    
    const [flag, setFlag] = useState(false)

    var {data : reviews,  error, isLoading, refetch} = ReviewAPI.useFetchAllReviewsQuery(limit)

   
    const {data : reviewstag} = ReviewAPI.useFetchReviewsByTagQuery(tag)
    

    
    var lst : IReview[] = []

    
    const [deleteReview, {}] = ReviewAPI.useDeleteReviewMutation()

    const handleRemove = (review : IReview) => {
        deleteReview(review)
    }

    const handleSearch = (review : IReview) => {
      deleteReview(review)
  }

  const clickfind  = () =>{
    if (reviewstag){
      setFlag(true)
    }
  
  }

  const [likeReview, {}] = ReviewAPI.useLikeReviewMutation()

  const handleLikereview = (review : IReview) => {
      likeReview (review)
  }


  return (
      <Container className='container-wraprev'>
        <div className="search">
            <input  type="search" value={tag} onChange={e => setTag(e.target.value)}/>
            <button className="iconclass" onClick={clickfind} >
            <i className="material-icons" >search</i>
            </button>               
        </div>
        {
          flag ?
          <Row style={{display: 'flex'}}>
          {reviewstag && reviewstag.map(rev  =>
              <ReviewItem key={rev.reviewId}  review={rev} remove={handleRemove} like={handleLikereview}/>
          )}
      </Row>
      :
          <Row style={{display: 'flex'}}>
          {reviews && reviews.map(rev  =>
              <ReviewItem key={rev.reviewId}  review={rev} remove={handleRemove} like={handleLikereview}/>
          )}
      </Row>
        }
    </Container>

  )
}
