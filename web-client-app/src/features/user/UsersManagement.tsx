import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { Grid, Header, Table } from "semantic-ui-react";

export default observer(function UsersManagement() {
    const { userStore } = useStore();
    const { users } = userStore;

    useEffect(() => {
        userStore.getUsers();
    }, [userStore]);

    return (
        <Grid divided="vertically">
            <Grid.Row>
                <Header as="h3">Users Management</Header>
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
                            <Table.HeaderCell>Roles</Table.HeaderCell>
                        </Table.Row>
                    </Table.Header>

                    <Table.Body>
                        {users.map((user) => (
                            <Table.Row key={user.id}>
                                <Table.Cell>{user.userName}</Table.Cell>
                                <Table.Cell>{user.nickName}</Table.Cell>
                                <Table.Cell>{user.fullName}</Table.Cell>
                                <Table.Cell>{user.email}</Table.Cell>
                                <Table.Cell>{user.bloodGroupName}</Table.Cell>
                                <Table.Cell>{user.brigadeShortName}</Table.Cell>
                                <Table.Cell>{user.roles}</Table.Cell>
                            </Table.Row>
                        ))}
                    </Table.Body>
                </Table>
            </Grid.Row>
        </Grid>
    );
});
