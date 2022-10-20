export interface ILoginResponse {
    userId:string,
    userName:string,
    role:string,
    accessToken:string
}

export interface IUser extends ILoginResponse {
    isAuthenticated:boolean
}