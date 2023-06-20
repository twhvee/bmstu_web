import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/dist/query/react";
import { IToken } from "../models/IToken";
import { AddModel, AuthModel, IUser } from "../models/IUser";


export const UserAPI = createApi({
    reducerPath: 'UserAPI',
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000/api/v1'}),
    tagTypes: ['User'],
    endpoints: (build) => ({
        fetchAllUsers: build.query<IUser[], number>({
            query: (limit: number = 50) => ({
                url: `/users`,
                params: {
                    _limit: limit
                }
            }),
            providesTags: result => ['User']
        }),
        fetchOneUser: build.query<IUser, string>({
            query: (login) => ({
                url: `/users/${login}`,
            }),
            providesTags: result => ['User']
        }),
        
        deleteUser: build.mutation<IUser, IUser>({
            query: (user) => ({
                url: `/users/${user.userId}`,
                method: 'DELETE',
            }),
            invalidatesTags: ['User']
        }),
        createToken : build.mutation<IToken, AuthModel>({
            query:(user) => ({
                url: `/users/auth`,
                method: 'POST',
                body: user,
            }),
            invalidatesTags: ['User']
        }),
      
        createUser : build.mutation<AddModel, AddModel>({
            query:(user) => ({
                url: `/users/register`,
                method: 'POST',
                body: user,
            }),
            invalidatesTags: ['User']
        }),
      
        
        
      
    })
})