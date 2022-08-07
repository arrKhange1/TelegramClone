export interface ILoginResponse {
    userName:string,
    role:string,
}

export interface IUser extends ILoginResponse {
    isAuthenticated:boolean
}