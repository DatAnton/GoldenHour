import axios, { AxiosResponse } from "axios";
import { User, UserFormValues } from "../models/user";
import { store } from "../stores/store";
import { ServiceMan } from "../models/serviceMan";
import { BaseEntity } from "../models/baseEntity";
import { ChangePasswordData } from "../models/changePasswordData";
import Incident from "../models/incident";

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
    deleteUser: (id: string) => requests.del(`/users/${id}`),
    getUserInfo: () => requests.get<ServiceMan>("/users/getInfo"),
    changePassword: (data: ChangePasswordData) =>
        requests.put("/users/changePassword", data),
    importUsersFile: (data: FormData) =>
        requests.post<number>("/users/import", data),
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

const Incidents = {
    getIncidents: () => requests.get<Incident[]>("/incidents"),
};

const agent = {
    Account,
    Users,
    Roles,
    BloodGroups,
    Brigades,
    Incidents,
};

export default agent;
