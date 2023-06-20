import {$authHost, $host, $hostlog} from "./index";

import jwt_decode from "jwt-decode";
import { AuthModel } from "../models/IUser";
import { IToken } from "../models/IToken";

export const registration = async (user: { login: string , email: string,  avatar: string,  type: string, password : string }) => {
    const {data} = await $host.post('users/register', user)
    //localStorage.setItem('token', data.token)
    return data //jwt_decode(data.token)
}


/*
export const loginfunc = async (user : AuthModel) => {
    console.log("ujdyj")
    const {data} = await $host.post('users/auth', user)
    console.log("jjjjj")
    console.log(data)
    localStorage.setItem("aaa", data)
    localStorage.setItem('token', data.access_token)
    localStorage.setItem('user', data.username)
    return jwt_decode(data.access_token)
}
*/

export const loginfunc =  (user : AuthModel) => {
    return  $host.post('users/auth', user).then((response) => {
      if (response.data.access_token) {
        localStorage.setItem('token', response.data.access_token)
        localStorage.setItem('user', response.data.username)
        window.location.assign('http://localhost:3000/home/');
      }
      
    })
   
}