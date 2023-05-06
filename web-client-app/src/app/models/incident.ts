import { ServiceMan } from "./serviceMan";

export default interface Incident {
    id: string;
    serviceManId: string;
    serviceMan: ServiceMan;
    dateTime: string;
    latitude: string;
    longitude: string;
    comment: string;
    medicId: string;
    medicFullName: string;
    images: string[];
}
