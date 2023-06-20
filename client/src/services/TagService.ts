import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/dist/query/react";
import {ITag} from "../models/ITag";


export const TagAPI = createApi({
    reducerPath: 'TagAPI',
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000/api/v1'}),
    tagTypes: ['Tag'],
    endpoints: (build) => ({
        fetchOneTag: build.query<ITag[], number>({
            query: (tagId) => ({
                url: `/tags/${tagId}`,
            }),
            providesTags: result => ['Tag']
        }),
        
        createTag : build.mutation<ITag, ITag>({
            query:(tag) => ({
                url: `/tags`,
                method: 'POST',
                body: tag,
            }),
            invalidatesTags: ['Tag']
        }),
      
    })
})