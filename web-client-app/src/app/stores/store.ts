import { createContext, useContext } from "react";
import AccountStore from "./accountStore";
import UserStore from "./userStore";
import RoleStore from "./roleStore";
import BloodGroupStore from "./bloodGroupStore";
import BrigadeStore from "./brigadeStore";
import IncidentStore from "./incidentStore";

interface Store {
    accountStore: AccountStore;
    userStore: UserStore;
    roleStore: RoleStore;
    bloodGroupStore: BloodGroupStore;
    brigadeStore: BrigadeStore;
    incidentStore: IncidentStore;
}

export const store: Store = {
    accountStore: new AccountStore(),
    userStore: new UserStore(),
    roleStore: new RoleStore(),
    bloodGroupStore: new BloodGroupStore(),
    brigadeStore: new BrigadeStore(),
    incidentStore: new IncidentStore()
};

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}
