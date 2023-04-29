import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { ServiceMan } from "../models/serviceMan";

export default class UserStore {
    users: ServiceMan[] = [];

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
    }
}
