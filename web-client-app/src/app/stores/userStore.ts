import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { ServiceMan } from "../models/serviceMan";
import { ChangePasswordData } from "../models/changePasswordData";

export default class UserStore {
    users: ServiceMan[] = [];
    userInfo: ServiceMan | undefined = undefined;
    importUsersResult: number | undefined = undefined;
    loading: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    getUsers = async () => {
        try {
            const response = await agent.Users.getUsers();
            runInAction(() => {
                this.users = response;
            });
        } catch (error) {
            throw error;
        }
    };

    createUser = async (user: ServiceMan) => {
        try {
            await agent.Users.createUser(user);
        } catch (error) {
            throw error;
        }
    };

    importUsers = async (data: FormData) => {
        try {
            this.loading = true;
            var response = await agent.Users.importUsersFile(data);
            runInAction(() => {
                this.importUsersResult = response;
                this.loading = false;
            });
        } catch (error) {
            throw error;
        }
    };

    updateUser = async (user: ServiceMan) => {
        try {
            await agent.Users.updateUser(user);
        } catch (error) {
            throw error;
        }
    };

    deleteUser = async (id: string) => {
        try {
            await agent.Users.deleteUser(id);
        } catch (error) {
            throw error;
        }
    };

    getUserInfo = async () => {
        try {
            var response = await agent.Users.getUserInfo();
            runInAction(() => {
                this.userInfo = response;
            });
        } catch (error) {
            throw error;
        }
    };

    changePassword = async (data: ChangePasswordData) => {
        try {
            await agent.Users.changePassword(data);
        } catch (error) {
            throw error;
        }
    };

    resetImportUsersResult = () => {
        this.importUsersResult = undefined;
    }
}
