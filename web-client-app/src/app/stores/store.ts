import { createContext, useContext } from "react";
import AccountStore from "./accountStore";
import UserStore from "./userStore";

interface Store {
    accountStore: AccountStore;
    userStore: UserStore;
}

export const store: Store = {
    accountStore: new AccountStore(),
    userStore: new UserStore()
};

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}
