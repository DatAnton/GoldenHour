import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { BaseEntity } from "../models/baseEntity";

export default class RoleStore {
    roles: BaseEntity[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    getRoles = async () => {
        try {
            const response = await agent.Roles.getRoles();
            runInAction(() => {
                this.roles = response;
            });
        } catch (error) {
            throw error;
        }
    };
}
