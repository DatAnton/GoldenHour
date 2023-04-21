import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button, Container, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function HomePage() {
    const { accountStore } = useStore();
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as="h1" inverted>
                    Golden Hour
                </Header>
                {accountStore.isLoggedIn ? (
                    <>
                        <Header
                            as="h2"
                            inverted
                            content="This is system for military medicine."
                        />
                        <Button as={Link} to="/users" size="huge" inverted>
                            Go to Users!
                        </Button>
                    </>
                ) : (
                    <>
                        <Button size="huge" as={Link} to="/login" inverted>
                            Login!
                        </Button>
                    </>
                )}
            </Container>
        </Segment>
    );
});
