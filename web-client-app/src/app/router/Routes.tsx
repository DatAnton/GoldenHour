import { RouteObject } from "react-router";
import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import UsersManagement from "../../features/user/UsersManagement";
import UserProfile from "../../features/user/UserProfile";
import IncidentList from "../../features/incident/IncidentList";
import RequireAuth from "./RequireAuth";

export const routes: RouteObject[] = [
    {
        path: "/",
        element: <App />,
        children: [
            {
                element: <RequireAuth />,
                children: [
                    { path: "/users", element: <UsersManagement /> },
                    { path: "/profile", element: <UserProfile /> },
                    { path: "/incidents", element: <IncidentList /> },
                ],
            },
        ],
    },
];

export const router = createBrowserRouter(routes);
