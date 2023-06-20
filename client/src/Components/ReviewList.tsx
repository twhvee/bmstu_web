import React, {useContext, useState} from 'react';
import {observer} from "mobx-react-lite";
import {RootStateContext} from "../index"
import {Col, Row} from "react-bootstrap";
import ReviewItem from './ReviewItem';
import RevComStore from '../store/RevComStore';
import {ReviewAPI} from "../services/ReviewService";
import { IReview } from '../models/IReview';
import { NamedTupleMember } from 'typescript';

const ReviewList = observer(( props: {tagfind : string, num : number}) => {
    const [limit, setLimit] = useState(100)

    const {data : reviews,  error, isLoading, refetch} = ReviewAPI.useFetchAllReviewsQuery(limit)

    console.log(props.num)
    if (props.num === 1){
        const {data : reviews,  error, isLoading, refetch} = ReviewAPI.useFetchReviewsByTagQuery(props.tagfind)
    }
   
    const [tag, setTag] = useState("");
    
    const [deleteReview, {}] = ReviewAPI.useDeleteReviewMutation()

    const handleRemove = (review : IReview) => {
        deleteReview(review)
    }
    const [likeReview, {}] = ReviewAPI.useLikeReviewMutation()

    const handleLike = (review : IReview) => {
        likeReview(review)
    }


    return (
        <Row style={{display: 'flex'}}>
            {reviews && reviews.map(rev  =>
                <ReviewItem key={rev.reviewId}  review={rev} remove={handleRemove} like={handleLike}/>
            )}
        </Row>
    );
    
});

export default ReviewList;
