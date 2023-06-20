import React from 'react'
import {makeAutoObservable} from "mobx";

export default class RevComStore {
    private _reviews: { ReviewId: number,UserId: number, BookId: number, Title: string , NumLikes: number,Review_data: string, Public_date: Date, RaitingBook: number}[]
    private _comments: { CommentId: number, ReviewId: number, UserId: number,  NumLikes: number,Comment_data: string, Public_date: Date }[] 
    constructor() {
        this._comments = [
            { CommentId : 1, UserId : 2, ReviewId : 4, NumLikes : 5, Comment_data : "fvsgsbgg", Public_date : new Date() },
            { CommentId : 2, UserId : 2, ReviewId : 4, NumLikes : 5, Comment_data : "fvsgsbgg", Public_date : new Date() },
            { CommentId : 3, UserId : 2, ReviewId : 4, NumLikes : 5, Comment_data : "fvsgsbgg", Public_date : new Date() },
        ]
        this._reviews = [ 
            {ReviewId :1, UserId : 2, BookId : 2, Title : "Weather is bad", NumLikes : 5, Review_data : "fvsgsbgg", Public_date : new Date(), RaitingBook : 3},
            {ReviewId :2, UserId : 2, BookId : 2, Title : "Weather is bad", NumLikes : 5, Review_data : "fvsgsbgg", Public_date : new Date(), RaitingBook : 3},
            {ReviewId :3, UserId : 2, BookId : 2, Title : "Weather is bad", NumLikes : 5, Review_data : "fvsgsbgg", Public_date : new Date(), RaitingBook : 3},
            {ReviewId :4, UserId : 2, BookId : 2, Title : "Weather is bad", NumLikes : 5, Review_data : "fvsgsbgg", Public_date : new Date(), RaitingBook : 3},
            {ReviewId :5, UserId : 2, BookId : 2, Title : "Weather is bad", NumLikes : 5, Review_data : "fvsgsbgg", Public_date : new Date(), RaitingBook : 3},
            
        ]
        makeAutoObservable(this)
    }

    setReview(reviews :{ ReviewId: number,UserId: number, BookId: number, Title: string , NumLikes: number,Review_data: string, Public_date: Date, RaitingBook: number} [] ) {
        this._reviews= reviews
    }

    setComment(comments : { CommentId: number, ReviewId: number, UserId: number,  NumLikes: number,Comment_data: string, Public_date: Date}[]) {
        this._comments = comments
    }
   

    /*
    setSelectedType(type) {
        this.setPage(1)
        this._selectedType = type
    }
    setSelectedBrand(brand) {
        this.setPage(1)
        this._selectedBrand = brand
    }
    setPage(page) {
        this._page = page
    }
    setTotalCount(count) {
        this._totalCount = count
    }
    */
    get comments() {
        return this._comments
    }
    get reviews() {
        return this._reviews
    }
 
    /*
    get selectedType() {
        return this._selectedType
    }
    get selectedBrand() {
        return this._selectedBrand
    }
    get totalCount() {
        return this._totalCount
    }
    get page() {
        return this._page
    }
    get limit() {
        return this._limit
    }
    */
}