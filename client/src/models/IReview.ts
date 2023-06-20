import { IBook } from "./IBook"
import { ITag } from "./ITag"

export interface IReview{
    reviewId: number,
    userId: number, 
    bookId: number, 
    title: string ,
    raitingBook: number,
    numLikes: number,
    review_data: string, 
    public_date: Date,
    book : IBook,
    user : {userId : string, login : string, avatar : string},
    tags : ITag[],
}

export interface IReviewAdd{
    userId: number, 
    bookName: string, 
    title: string ,
    raitingBook: number,
    review_data: string, 
    tags: string,
}