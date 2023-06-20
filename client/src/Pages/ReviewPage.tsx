import React, {useState} from 'react';
import { ReviewAPI } from '../services/ReviewService';
import { IReview } from '../models/IReview';
import ReviewItem from '../Components/ReviewItem';
import { CommentAPI } from '../services/CommentService';
import { Container, Row ,Form, Button } from 'react-bootstrap';
import { IComment } from '../models/IComment';
import CommentItem from '../Components/CommentItem';
import '../Reviews.css'
import '../Comment.css'
import { useParams } from 'react-router-dom';
import { UserAPI } from '../services/UserService';


interface ParamTypes {
  id: string
}

export default function ReviewPage() {

  const [deleteComment, {}] = CommentAPI.useDeleteCommentMutation()

  const handleRemove = (comment : IComment) => {
      deleteComment(comment)
  }
  const {id} = useParams()
  var str ="" + id
  var idrev: number = +str;

  const [Data, setData] = useState('')

   const [createComment, {}] = CommentAPI.useCreateCommentMutation()
    const handleCreate = async (e: any) => {
        e.preventDefault();
        console.log("jopa")
        const comment_data = Data     
        await createComment({
          userId: users?.userId, 
          reviewId: idrev, 
          numLikes: 0,
          comment_data: comment_data, 
          public_date: new Date()} as IComment)
    }

  const [deleteReview, {}] = ReviewAPI.useDeleteReviewMutation()

  const handleRemoverev = (review : IReview) => {
        deleteReview(review)
  }

  const {data : reviews,  error, isLoading, refetch} = ReviewAPI.useFetchOneReviewQuery(idrev)
  console.log(reviews)
  const {data : comments} = CommentAPI.useFetchOneCommentQuery(idrev)

  const name  = localStorage.getItem('user')
  const struser = '' + name
  const [username, setUsername] = useState(struser)
  

 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  const [likeComment, {}] = CommentAPI.useLikeCommentMutation()

    const handleLike = (comment : IComment) => {
        likeComment(comment)
    }

    const [likeReview, {}] = ReviewAPI.useLikeReviewMutation()

    const handleLikereview = (review : IReview) => {
        likeReview (review)
    }


  
  return (
    <div className="wrapcom">
          {reviews ?
                 <ReviewItem key={reviews.reviewId}  review={reviews} remove={handleRemoverev} like={handleLikereview }/>
                 :
                 <p></p>
          }
          {
            users ?
                <Form className="formcom" onSubmit={handleCreate}>
                <Form.Group className="mb-3" controlId="formBasicname">
                    <Form.Control className="inputcom"  placeholder="Введите текст" value={Data}
                    onChange={e => setData(e.target.value)} />               
                </Form.Group>
                <Button className="addcom"  variant="primary" type="submit">
                    ДОБАВИТЬ
                </Button>
            </Form>
            :
            <p></p>
          }
        
          <Row className="colcomment">
            {comments && comments.map(com  =>
                <CommentItem key={com.reviewId}  comment={com} remove={handleRemove} like={handleLike}/>
            )}
        </Row>
    </div>
  )
}
