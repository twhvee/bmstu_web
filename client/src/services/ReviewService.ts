 import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/dist/query/react";
import {IReview, IReviewAdd} from "../models/IReview";


export const ReviewAPI = createApi({
    reducerPath: 'ReviewAPI',
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000/api/v1'}),
    tagTypes: ['Review'],
    endpoints: (build) => ({
        fetchAllReviews: build.query<IReview[], number>({
            query: (limit: number = 50) => ({
                url: `/reviews`,
                params: {
                    _limit: limit
                }
            }),
            providesTags: result => ['Review']
        }),
        fetchOneReview: build.query<IReview, number>({
            query: (reviewId) => ({
                url: `/reviews/${reviewId}`,
            }),
            providesTags: result => ['Review']
        }),
        likeReview : build.mutation<IReview, IReview>({
            query:(review) => ({
                url: `/reviews/${review.reviewId}`,
                method: 'PATCH',
            }),
            invalidatesTags: ['Review']
        }),
        createReview : build.mutation<IReviewAdd, IReviewAdd>({
            query:(review) => ({
                url: `/reviews`,
                method: 'POST',
                body: review,
            }),
            invalidatesTags: ['Review']
        }),
        updateReview : build.mutation<IReview, IReview>({
            query:(review) => ({
                url: `/reviews/${review.reviewId}`,
                method: 'PATCH',
                body: review.reviewId,
            }),
            invalidatesTags: ['Review']
        }),
        deleteReview: build.mutation<IReview, IReview>({
            query: (review) => ({
                url: `/reviews/${review.reviewId}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['Review']
        }),
        fetchReviewsByTag: build.query<IReview[], string>({
            query: (tag: string ) => ({
                url: `/reviews/findByTags`,
                params: {
                    tag: tag
                }
            }),
            providesTags: result => ['Review']
        }),
      

        
    })
})