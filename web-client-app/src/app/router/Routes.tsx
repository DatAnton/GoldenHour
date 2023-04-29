import { RouteObject } from "react-router";
import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import LoginForm from "../../features/account/LoginForm";
import UsersManagement from "../../features/user/UsersManagement";

export const routes: RouteObject[] = [
    {
        path: "/",
        element: <App />,
        children: [
            { path: "/login", element: <LoginForm /> },
            { path: "/users", element: <UsersManagement /> },
        ],
    },
];

export const router = createBrowserRouter(routes);
