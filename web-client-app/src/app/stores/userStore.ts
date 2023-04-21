import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";

export default class UserStore {
    response: string | undefined = undefined;

    constructor() {
        makeAutoObservable(this);
    }

    getUsers = async () => {
        try {
            const response = await agent.Users.getUsers();
            runInAction(() => {
                this.response = response;
            });
        } catch (error) {
            throw error;
        }
    };
}
