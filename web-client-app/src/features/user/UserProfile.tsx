import { observer } from "mobx-react-lite";
import { Card, Container, Header, Icon, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import ChangePasswordModal from "./ChangePasswordModal";

export default observer(function UserProfile() {
    const { userStore, accountStore } = useStore();
    const { userInfo } = userStore;
    const { user } = accountStore;
    const [changePasswordModalOpen, setChangePasswordModalOpen] =
        useState(false);

    useEffect(() => {
        userStore.getUserInfo();
    }, [userStore]);

    return (
        <Container textAlign="center">
            <ChangePasswordModal
                isOpen={changePasswordModalOpen}
                onClose={() => setChangePasswordModalOpen(false)}
            />
            <Segment>
                <Header as="h2" icon textAlign="center">
                    <Icon name="user" circular />
                    <Header.Content>{userInfo?.userName}</Header.Content>
                </Header>

                <Card fluid>
                    <Card.Content header={userInfo?.nickName}></Card.Content>
                    <Card.Meta>
                        {userInfo?.bloodGroupName}
                        <Icon
                            name="setting"
                            circular
                            onClick={() => setChangePasswordModalOpen(true)}
                            style={{
                                cursor: "pointer",
                                margin: "0 0 5px 10px",
                            }}
                        />
                    </Card.Meta>
                    <Card.Content description={userInfo?.fullName} />
                    <Card.Content description={userInfo?.email} />
                    <Card.Content description={userInfo?.brigadeShortName} />
                    <Card.Content extra>
                        <Icon name="user" />
                        {user?.role}
                    </Card.Content>
                </Card>
            </Segment>
        </Container>
    );
});
