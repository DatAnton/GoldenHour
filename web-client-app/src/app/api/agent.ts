import axios, { AxiosResponse } from "axios";
import { User, UserFormValues } from "../models/user";
import { store } from "../stores/store";
import { ServiceMan } from "../models/serviceMan";
import { BaseEntity } from "../models/baseEntity";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use((config) => {
    const token = store.accountStore.token;
    if (token && config.headers)
        config.headers.Authorization = `Bearer ${token}`;

    return config;
});

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) =>
        axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) =>
        axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Account = {
    current: () => requests.get<User>("/accounts"),
    login: (user: UserFormValues) =>
        requests.post<User>("/accounts/login", user),
};

const Users = {
    getUsers: () => requests.get<ServiceMan[]>("/users"),
    createUser: (user: ServiceMan) => requests.post("/users", user),
    updateUser: (user: ServiceMan) => requests.put("/users", user),
    deleteUser: (id: string) => requests.del(`/users/${id}`)
};

const Roles = {
    getRoles: () => requests.get<BaseEntity[]>("/roles"),
};

const BloodGroups = {
    getBloodGroups: () => requests.get<BaseEntity[]>("/bloodGroups"),
};

const Brigades = {
    getBrigades: () => requests.get<BaseEntity[]>("/brigades"),
};

const agent = {
    Account,
    Users,
    Roles,
    BloodGroups,
    Brigades,
};

export default agent;
