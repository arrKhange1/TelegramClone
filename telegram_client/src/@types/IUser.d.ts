export interface ILoginResponse {
    userId:string,
    userName:string,
    role:string,
}

export interface IUser extends ILoginResponse {
    isAuthenticated:boolean
}