import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/dist/query/react";
import {IComment} from "../models/IComment";


export const CommentAPI = createApi({
    reducerPath: 'CommentAPI',
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000/api/v1'}),
    tagTypes: ['Comment'],
    endpoints: (build) => ({
        fetchOneComment: build.query<IComment[], number>({
            query: (reviewId) => ({
                url: `/comments/${reviewId}`,
            }),
            providesTags: result => ['Comment']
        }),
        
        createComment : build.mutation<IComment, IComment>({
            query:(comment) => ({
                url: `/comments`,
                method: 'POST',
                body: comment,
                credentials: 'include',
            }),
            invalidatesTags: ['Comment']
        }),
        likeComment : build.mutation<IComment, IComment>({
            query:(comment) => ({
                url: `/comments/${comment.commentId}`,
                method: 'PATCH',
                credentials: 'include',
            }),
            invalidatesTags: ['Comment']
        }),
        deleteComment: build.mutation<IComment, IComment>({
            query: (comment) => ({
                url: `/comments/${comment.commentId}`,
                method: 'DELETE',
                credentials: 'include',
            }),
            invalidatesTags: ['Comment']
        }),
      
    })
})