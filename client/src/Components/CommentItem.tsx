import React, {FC, useState} from 'react'
import {Row, Image, Col} from "react-bootstrap";
import '../Reviews.css';
import '../Comment.css';
import {useNavigate} from "react-router-dom";
import { IReview } from '../models/IReview';
import { IComment } from '../models/IComment';
import {UserAPI} from '../services/UserService';

interface InterComment {
    comment : IComment;
    remove : (comment : IComment) => void,
    like : (like : IComment) => void};

    
const CommentItem : FC<InterComment> = ({comment, remove, like }) => {

  const name  = localStorage.getItem('user')
  const str = '' + name
  const [username, setUsername] = useState(str)
  

 
  var {data : users} = UserAPI.useFetchOneUserQuery(username)

  var role = null
  if (users?.access_role == 'admin'){
    role = true
  }

  const history = useNavigate()
  //console.log("reviews" + '/' + props.rev.ReviewId)


 const handleRemove = (event : React.MouseEvent) => {
   event.stopPropagation()
   remove(comment)

 }


 const clicklike = (event : React.MouseEvent) => {
  event.stopPropagation()
  like(comment)

}

 //const data = comment.public_date.slice(0,10).replaceAll('-', '.')

  return ( 
    <div className='blockcom'>
      {
            role ?
            <div>
            <button className='deletecom' onClick={handleRemove} >
            <i className="material-icons">delete</i>
            </button>
            </div>
            :
            <p></p>
        }
        
        <div className='ComCard' >
       
          <div className='blockuserinfo'>
              <Image className="imgavatar" src={comment.user.avatar}/>
              <p className='logincom'>{comment.user.login}</p>             
          </div>
          
          <div className='blockcomment'>
                  <p className="comDate">{comment.public_date.toLocaleString().slice(0,10).replaceAll('-', '.')}</p> 
                  <p className="textCom">{comment.comment_data}</p>
  
          </div>
          <div className="butblock">   
          {
            users ?
            <div className="butLike" onClick={clicklike}>
                      <i className="material-icons">favorite_border</i>
                      <p>{comment.numLikes}</p>
                  </div> 
              :
              <div className="butLike">
                      <i className="material-icons">favorite_border</i>
                      <p>{comment.numLikes}</p>
                  </div> 
          }          
                           
          </div>    
    </div>
        
    </div>
    
  )
}
export default CommentItem;