import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { BaseEntity } from "../models/baseEntity";

export default class BloodGroupStore {
    bloodGroups: BaseEntity[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    getBloodGroups = async () => {
        try {
            const response = await agent.BloodGroups.getBloodGroups();
            runInAction(() => {
                this.bloodGroups = response;
            });
        } catch (error) {
            throw error;
        }
    };
}
