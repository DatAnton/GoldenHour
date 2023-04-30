export interface User {
    userName: string;
    token: string;
    userId: string;
    role: string;
}

export interface UserFormValues {
    userName: string;
    password: string;
}