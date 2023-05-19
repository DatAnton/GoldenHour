import axios, { AxiosError, AxiosResponse } from "axios";
import { RefreshModel, User, UserFormValues } from "../models/user";
import { store } from "../stores/store";
import { ServiceMan } from "../models/serviceMan";
import { BaseEntity } from "../models/baseEntity";
import { ChangePasswordData } from "../models/changePasswordData";
import Incident from "../models/incident";

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

axios.interceptors.request.use((config) => {
    const token = store.accountStore.token;
    if (token && config.headers)
        config.headers.Authorization = `Bearer ${token}`;

    return config;
});

axios.interceptors.response.use(
    async (response) => {
        return response;
    },
    (error: AxiosError) => {
        const { data, status, config } = error.response!;
        switch (status) {
            case 401:
                if (store.accountStore.refreshToken) {
                    const token = store.accountStore.token;
                    const refresh = store.accountStore.refreshToken;
                    store.accountStore.clearTokens();
                    store.accountStore.refresh({
                        accessToken: token!,
                        refreshToken: refresh,
                    });
                    return axios.create(config);
                } else {
                    window.alert("Unauthorized");
                }
                break;
            case 403:
                window.alert("Forbidden");
                break;
            case 500:
                window.alert((data as { message: string }).message);
                break;
        }
    }
);

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

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
    refresh: (model: RefreshModel) =>
        requests.post<User>("/accounts/refresh", model),
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
