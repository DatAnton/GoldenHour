import { makeAutoObservable, reaction, runInAction } from "mobx";
import { User, UserFormValues } from "../models/user";
import agent from "../api/agent";
import { router } from "../router/Routes";

export default class AccountStore {
    user: User | undefined = undefined;
    token: string | null = localStorage.getItem("jwt");
    appLoaded = false;

    constructor() {
        makeAutoObservable(this);

        reaction(
            () => this.token,
            (token) => {
                if (token) localStorage.setItem("jwt", token);
                else localStorage.removeItem("jwt");
            }
        );
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            runInAction(() => {
                this.user = user;
                this.token = user.token;
            });
            router.navigate("/users");
        } catch (error) {
            throw error;
        }
    };

    getUser = async () => {
        try {
            const user = await agent.Account.current();
            runInAction(() => (this.user = user));
        } catch (error) {
            throw error;
        }
    };

    logout = () => {
        this.user = undefined;
        this.token = null;
        router.navigate("/");
    };

    setAppLoaded = () => {
        this.appLoaded = true;
    };
}
