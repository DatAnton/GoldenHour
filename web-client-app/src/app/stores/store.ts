import { createContext, useContext } from "react";
import AccountStore from "./accountStore";

interface Store {
    accountStore: AccountStore;
}

export const store: Store = {
    accountStore: new AccountStore()
};

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}
