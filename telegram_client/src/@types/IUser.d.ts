export interface ILoginResponse {
    userName:string,
    role:string,
    accessToken:string,
    refreshToken:string
}

export interface IUser extends ILoginResponse {
    isAuthenticated:boolean
}