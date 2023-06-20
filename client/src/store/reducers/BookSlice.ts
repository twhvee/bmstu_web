import {IBook} from '../../models/IBook';
import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import { defineProperty } from 'mobx';
import { fetchBooks } from './ActionCreator';

interface BookState {
    books: IBook[];
    isLoading : boolean;
    error : string;
}
   
const initialState : BookState = {
    books : [],
    isLoading: false,
    error: ''
}



export const bookSlice = createSlice( {
    name : 'book',
    initialState,
    reducers: {},
    /*
        booksFetching(state) {
            state.isLoading = true;
        },
        booksFetchingSuccess(state, action :PayloadAction<IBook[]>) {
            state.isLoading = false;
            state.error='';
            state.books = action.payload;
        },
        booksFetchingError(state, action : PayloadAction<string>) {
            state.isLoading = true;
            state.error = action.payload
        }

    },
    */
    extraReducers: {
        [fetchBooks.fulfilled.type]: (state, action :PayloadAction<IBook[]>) =>{
            state.isLoading = false;
            state.error='';
            state.books = action.payload;
        }, 
        [fetchBooks.pending.type]: (state) =>{
            state.isLoading = true;
            
        }, 
        [fetchBooks.rejected.type]: (state, action :PayloadAction<string>) =>{
            state.isLoading = false;
            state.error= action.payload;
            
        }
    } 
})

export default bookSlice.reducer;

