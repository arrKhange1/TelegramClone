export interface ILoginResponse {
    userName:string,
    role:string,
    token:string
}

export interface IUser extends ILoginResponse {
    isAuthenticated:boolean
}