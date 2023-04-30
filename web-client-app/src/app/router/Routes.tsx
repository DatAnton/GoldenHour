import { RouteObject } from "react-router";
import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import UsersManagement from "../../features/user/UsersManagement";
import UserProfile from "../../features/user/UserProfile";

export const routes: RouteObject[] = [
    {
        path: "/",
        element: <App />,
        children: [
            { path: "/users", element: <UsersManagement /> },
            { path: "/profile", element: <UserProfile /> },
        ],
    },
];

export const router = createBrowserRouter(routes);
