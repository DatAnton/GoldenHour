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
}
