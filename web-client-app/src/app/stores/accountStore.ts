import { makeAutoObservable, reaction, runInAction } from "mobx";
import { RefreshModel, User, UserFormValues } from "../models/user";
import agent from "../api/agent";
import { router } from "../router/Routes";

export default class AccountStore {
    user: User | undefined = undefined;
    token: string | null = localStorage.getItem("jwt");
    refreshToken: string | null = localStorage.getItem("refresh");
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

        reaction(
            () => this.refreshToken,
            (refreshToken) => {
                if (refreshToken) localStorage.setItem("refresh", refreshToken);
                else localStorage.removeItem("refresh");
            }
        );
    }

    get isLoggedIn() {
        return !!this.user;
    }

    get isAdmin() {
        return this.user && this.user.role === "Admin";
    }

    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            runInAction(() => {
                this.user = user;
                this.token = user.token;
                this.refreshToken = user.refreshToken;
            });
            router.navigate("/users");
        } catch (error) {
            throw error;
        }
    };

    refresh = async (creds: RefreshModel) => {
        try {
            const user = await agent.Account.refresh(creds);
            runInAction(() => {
                this.user = user;
                this.token = user.token;
                this.refreshToken = user.refreshToken;
            });
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
        this.refreshToken = null;
        router.navigate("/");
    };

    setAppLoaded = () => {
        this.appLoaded = true;
    };

    clearTokens = () => {
        this.token = null;
        this.refreshToken = null;
    }
}
