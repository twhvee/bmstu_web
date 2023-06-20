import React from 'react'
import {makeAutoObservable} from "mobx";
import { createContext } from "react";
import { observable, action, computed, reaction } from "mobx";

 export class BookStore {
   
    @observable _books: { BookId: number, BookName: string ,Author: string, Path: string }[]  = []
    //constructor() {
        //reaction(() => this._books, _ => console.log(this._books.length))
     //    this._books = []

    //    makeAutoObservable(this)
   // }

    
    /*
    {BookId :1, BookName : "Harry Potter", Author : "Rouling", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 2, BookName : "Harry Potter2", Author : "Rouling2", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"},
            {BookId : 3, BookName : "Harry Potter3", Author : "Rouling3", Path : "https://epublibre.xyz/images/cover/4223.jpg"}
    */
    @action setBook(books :{ BookId: number, BookName: string ,Author: string, Path: string }[] ) {
        this._books= books
    }

    /*
    @action setBookName(bookname :string[]) {
        this._bookName = bookname
    }
    @action setAuthor(author :string[]) {
        this._author = author
    }
    @action setImage(path: string[]) {
        this._image = path
    }
    */

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
    @action get books() {
        return this._books
    }
    /*
    @action get author() {
        return this._author
    }
    @action get bookNames() {
        return this._bookName
    }
    @action get image() {
        return this._image
    }
    
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

//export default createContext(new BookStore())