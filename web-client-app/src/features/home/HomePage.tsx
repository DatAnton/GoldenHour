import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button, Container, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useState } from "react";
import LoginForm from "../account/LoginForm";

export default observer(function HomePage() {
    const { accountStore } = useStore();
    const [loginFormOpen, setLoginFormOpen] = useState(false);

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
                        <Button as={Link} to="/profile" size="huge" inverted>
                            Go to Profile!
                        </Button>
                    </>
                ) : (
                    <>
                        <LoginForm
                            isOpen={loginFormOpen}
                            onClose={() => setLoginFormOpen(false)}
                        />
                        <Button
                            size="huge"
                            inverted
                            onClick={() => setLoginFormOpen(true)}
                        >
                            Login!
                        </Button>
                    </>
                )}
            </Container>
        </Segment>
    );
});
