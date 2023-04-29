import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { BaseEntity } from "../models/baseEntity";

export default class BrigadeStore {
    brigades: BaseEntity[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    getBrigades = async () => {
        try {
            const response = await agent.Brigades.getBrigades();
            runInAction(() => {
                this.brigades = response;
            });
        } catch (error) {
            throw error;
        }
    };
}
