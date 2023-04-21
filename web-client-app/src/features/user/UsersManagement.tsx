import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";

export default observer(function UsersManagement() {
    const { userStore } = useStore();

    useEffect(() => {
        userStore.getUsers();
    }, [userStore]);

    return (
        <>
            <h2>Users Management</h2>
            {userStore.response}
        </>
    );
});
