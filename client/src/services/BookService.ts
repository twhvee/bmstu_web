import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/dist/query/react";
import {IBook} from "../models/IBook";


export const PostAPI = createApi({
    reducerPath: 'PostAPI',
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000/api/v1'}),
    tagTypes: ['Post'],
    endpoints: (build) => ({
        fetchAllBooks: build.query<IBook[], number>({
            query: (limit: number = 50) => ({
                url: `/books`,
                params: {
                    _limit: limit
                }
            }),
            providesTags: result => ['Post']
        }),
        createBook : build.mutation<IBook, IBook>({
            query:(book) => ({
                url: `/books`,
                method: 'POST',
                body: book,
            }),
            invalidatesTags: ['Post']
        }),
        deleteBook: build.mutation<IBook, IBook>({
            query: (book) => ({
                url: `/books/${book.bookId}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['Post']
        }),
      
    })
})