import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Outlet, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import { useStore } from "../stores/store";
import { useEffect } from "react";
import LoadingComponent from "./LoadingComponent";
import { router } from "../router/Routes";

function App() {
    const location = useLocation();
    const { accountStore } = useStore();
    const { isAdmin } = accountStore;

    useEffect(() => {
        if (accountStore.token) {
            accountStore
                .getUser()
                .finally(() => accountStore.setAppLoaded())
                .finally(() => {
                    if (!isAdmin && location.pathname !== "/profile")
                        router.navigate("/profile");
                });
        } else {
            accountStore.setAppLoaded();
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [accountStore, location]);

    if (!accountStore.appLoaded)
        return <LoadingComponent content="Loading app..." />;

    return (
        <>
            {location.pathname === "/" || !accountStore.isLoggedIn ? (
                <HomePage />
            ) : (
                <>
                    <NavBar />
                    <Container style={{ marginTop: "7em" }}>
                        <Outlet />
                    </Container>
                </>
            )}
        </>
    );
}

export default observer(App);
