export interface IUser{
    userId: number,
    login: string ,
    password: string,
    email: string,
    avatar: string,
    access_role: string
}


export interface AuthModel{
    login: string ,
    password: string,
}

export interface AddModel{
 login: string , email: string,  avatar: string,  type: string, password : string }