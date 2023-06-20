import React from 'react'
import {makeAutoObservable} from "mobx";

export default class UserStore {
    private _users: { UserId: number, Login: string , Password : string , Email: string, Avatar: string,  Access_role: string }[] 
    private _user: { }
    private _isAuth: boolean
    constructor() {
    
        this._users = [ 
           
        ]
        this._isAuth = false
        this._user = {}

        makeAutoObservable(this)
    }



    setIsAuth(bool :boolean) {
        this._isAuth = bool
    }
    setUser(user: {}){
        this._user = user
    }

    get isAuth() {
        return this._isAuth
    }
    get user() {
        return this._user
    }


    setUsers(users :{ UserId: number, Login: string , Password : string , Email: string, Avatar: string,  Access_role: string }[] ) {
        this._users= users
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
    get users() {
        return this._users
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
