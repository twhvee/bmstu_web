import {$authHost, $host} from "./index";
import jwt_decode from "jwt-decode";
import ReviewList from "../Components/ReviewList";



export const createbook = async (book :{  BookName: string ,Author: string, Path: string }) => {
    const {data} = await $authHost.post('books', book)
    return data
}

type GetNumber = () => Promise<{ BookId: number, BookName: string ,Author: string, Path: string }[]>;

export const fetchBooks : GetNumber  = async () => {
    const {data} = await $host.get('books')
    return data
}

export const createrev = async (rev: {UserId: number, BookId: number, Title: string , NumLikes: number,Review_data: string, Public_date: Date, RaitingBook: number}) => {
    const {data} = await $authHost.post('reviews', ReviewList)
    return data
}

export const fetchRevs = async () => {
    const {data} = await $host.get('reviews')
    return data
}


/*
export const fetchDevices = async (typeId, brandId, page, limit= 5) => {
    const {data} = await $host.get('api/device', {params: {
            typeId, brandId, page, limit
        }})
    return data
}
*/

export const fetchOneReview = async (id : number) => {
    const {data} = await $host.get('reviews/' + id)
    return data
}

export const fetchOneBook = async (id : number)  => {
    const {data} = await $host.get('books/' + id)
    return data
}