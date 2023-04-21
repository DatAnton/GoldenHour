import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Outlet, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import { useStore } from "../stores/store";
import { useEffect } from "react";
import LoadingComponent from "./LoadingComponent";

function App() {
    const location = useLocation();
    const { accountStore } = useStore();

    useEffect(() => {
        if (accountStore.token) {
            accountStore.getUser().finally(() => accountStore.setAppLoaded());
        } else {
            accountStore.setAppLoaded();
        }
    }, [accountStore]);

    if(!accountStore.appLoaded) return <LoadingComponent content="Loading app..." />

    return (
        <>
            {location.pathname === "/" ? (
                <HomePage />
            ) : (
                <>
                    <NavBar />
                    <Container style={{ marginTop: "10em" }}>
                        <Outlet />
                    </Container>
                </>
            )}
        </>
    );
}

export default observer(App);
