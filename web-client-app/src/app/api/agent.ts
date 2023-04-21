import axios, { AxiosResponse } from 'axios';
import { User, UserFormValues } from '../models/user';
import { store } from '../stores/store';

axios.defaults.baseURL = 'http://localhost:8020/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use(config => {
    const token = store.accountStore.token;
    if(token && config.headers) config.headers.Authorization = `Bearer ${token}`;

    return config;
})

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T> (url: string) => axios.delete<T> (url).then(responseBody),
};

const Account = {
    current: () => requests.get<User>('/accounts'),
    login: (user: UserFormValues) => requests.post<User>('/accounts/login', user)
}

const Users = {
    getUsers: () => requests.get<string>('/users'),
}

const agent = {
    Account,
    Users
}

export default agent;