export interface User {
    userName: string;
    token: string;
    refreshToken: string;
    userId: string;
    role: string;
}

export interface UserFormValues {
    userName: string;
    password: string;
}

export interface RefreshModel {
    accessToken: string;
    refreshToken: string;
}