import { AppDispatch } from "../store";
import axios from "axios";
import { IBook } from "../../models/IBook";
import {bookSlice} from './BookSlice';
import { createAsyncThunk } from "@reduxjs/toolkit";


function getErrorMessage(error: unknown) {
    if (error instanceof Error) return error.message
    return String(error)
}
/*

export const fetchBooks = () =>  async (dispatch : AppDispatch) =>{
    try {
        dispatch(bookSlice.actions.booksFetching())
        const response  = await axios.get<IBook[]>('http://localhost:5000/api/v1/books')
        //console.log(response
        
        dispatch(bookSlice.actions.booksFetchingSuccess(response.data))
        
    } catch (e) {
        dispatch(bookSlice.actions.booksFetchingError(getErrorMessage(e)))
    }
}
*/
export const fetchBooks = createAsyncThunk(
    'user/fetchAll',
    async(_, thunckAPI) => {
        try {
            const response = await axios.get<IBook[]>('http://localhost:5000/api/v1/books')
            return response.data;
            
        } catch (e) {
            return thunckAPI.fulfillWithValue("не удалось загрузить данные")
        }
       
    }
)



