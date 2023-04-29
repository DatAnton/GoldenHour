import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import {
    Button,
    Grid,
    GridColumn,
    Header,
    Icon,
    Table,
} from "semantic-ui-react";
import AddEditUserModal from "./AddEditUserModal";

export default observer(function UsersManagement() {
    const { userStore } = useStore();
    const { users } = userStore;
    const [addUserModalOpen, setAddUserModalOpen] = useState(false);
    const [selectedUserId, setSelectedUserId] = useState<string | undefined>(
        undefined
    );

    useEffect(() => {
        userStore.getUsers();
    }, [userStore]);

    return (
        <>
            <AddEditUserModal
                userId={selectedUserId}
                isOpen={addUserModalOpen}
                onClose={() => {
                    setAddUserModalOpen(false);
                    setSelectedUserId(undefined);
                }}
            />
            <Grid divided="vertically">
                <Grid.Row>
                    <GridColumn floated="left" width={5}>
                        <Header as="h2">Users Management</Header>
                    </GridColumn>
                    <GridColumn floated="right" width={3}>
                        <Button
                            positive
                            icon="add"
                            fluid
                            content="New user"
                            onClick={() => {
                                setSelectedUserId(undefined);
                                setAddUserModalOpen(true);
                            }}
                        />
                    </GridColumn>
                </Grid.Row>
                <Grid.Row>
                    <Table celled>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>UserName</Table.HeaderCell>
                                <Table.HeaderCell>NickName</Table.HeaderCell>
                                <Table.HeaderCell>FullName</Table.HeaderCell>
                                <Table.HeaderCell>Email</Table.HeaderCell>
                                <Table.HeaderCell>Blood Group</Table.HeaderCell>
                                <Table.HeaderCell>Brigade</Table.HeaderCell>
                                <Table.HeaderCell>Role</Table.HeaderCell>
                                <Table.HeaderCell>Action</Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>

                        <Table.Body>
                            {users.map((user) => (
                                <Table.Row key={user.id}>
                                    <Table.Cell>{user.userName}</Table.Cell>
                                    <Table.Cell>{user.nickName}</Table.Cell>
                                    <Table.Cell>{user.fullName}</Table.Cell>
                                    <Table.Cell>{user.email}</Table.Cell>
                                    <Table.Cell>
                                        {user.bloodGroupName}
                                    </Table.Cell>
                                    <Table.Cell>
                                        {user.brigadeShortName}
                                    </Table.Cell>
                                    <Table.Cell>{user.role}</Table.Cell>
                                    <Table.Cell>
                                        <Icon
                                            name="edit"
                                            style={{ cursor: "pointer" }}
                                            onClick={() => {
                                                setSelectedUserId(user.id);
                                                setAddUserModalOpen(true);
                                            }}
                                        />
                                        <Icon
                                            name="trash"
                                            style={{ cursor: "pointer" }}
                                            onClick={() => {
                                                const confirmed =
                                                    window.confirm(
                                                        `Are you sure you want to delete ${user.userName}?`
                                                    );
                                                if (confirmed) {
                                                    userStore
                                                        .deleteUser(user.id)
                                                        .then(() =>
                                                            userStore.getUsers()
                                                        );
                                                }
                                            }}
                                        />
                                    </Table.Cell>
                                </Table.Row>
                            ))}
                        </Table.Body>
                    </Table>
                </Grid.Row>
            </Grid>
        </>
    );
});
