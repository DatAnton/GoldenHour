import { observer } from "mobx-react-lite";
import { Card, Container, Header, Icon, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";

export default observer(function UserProfile() {
    const { userStore, accountStore } = useStore();
    const { userInfo } = userStore;
    const { user } = accountStore;

    useEffect(() => {
        userStore.getUserInfo();
    }, [userStore]);

    return (
        <Container textAlign="center">
            <Segment>
                <Header as="h2" icon textAlign="center">
                    <Icon name="user" circular />
                    <Header.Content>{userInfo?.userName}</Header.Content>
                </Header>

                <Card fluid>
                    <Card.Content
                        header={userInfo?.nickName}
                        meta={userInfo?.bloodGroupName}
                    />
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
