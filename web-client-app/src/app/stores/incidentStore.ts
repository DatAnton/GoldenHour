import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import Incident from "../models/incident";

export default class IncidentStore {
    incidents: Incident[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    getIncidents = async () => {
        try {
            const response = await agent.Incidents.getIncidents();
            runInAction(() => {
                this.incidents = response;
            });
        } catch (error) {
            throw error;
        }
    };
}
