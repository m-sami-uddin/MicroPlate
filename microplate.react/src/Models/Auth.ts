export interface User {
    userName: string;
    accessToken: string;
}
export interface LoginRequestDto {
    userName?: string;
    password?: string;
}
export interface Register {
    userName: string;
    password: string;
    userRole: UserRole;
}
export enum UserRole {
    User = 1,
    Admin = 2
}