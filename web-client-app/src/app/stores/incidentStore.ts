import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import Incident from "../models/incident";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { store } from "./store";

export default class IncidentStore {
    incidents: Incident[] = [];
    hubConnection: HubConnection | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    createHubConnection = () => {
        const token = store.accountStore.token!;
        this.hubConnection = new HubConnectionBuilder()
            .withUrl(process.env.REACT_APP_INCIDENTS_URL!, {
                accessTokenFactory: () => token,
            })
            .withAutomaticReconnect()
            .build();

        this.hubConnection
            .start()
            .catch((error) =>
                console.log("Error establishing the connection: ", error)
            );

        this.hubConnection.on("ReceivedIncident", (incident: Incident) => {
            runInAction(() => {
                this.incidents.unshift(incident);
            });
        });
    };

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

    findIncident = (id: string): Incident | undefined => {
        return this.incidents.find((i) => i.id === id);
    };
}
