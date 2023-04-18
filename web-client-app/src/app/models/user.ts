export interface User {
    userName: string;
    token: string;
    userId: string;
    roles: string;
}

export interface UserFormValues {
    userName: string;
    password: string;
}