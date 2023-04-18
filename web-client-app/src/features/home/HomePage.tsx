import { Link } from "react-router-dom";
import { Button, Container } from "semantic-ui-react";

export default function HomePage() {
    return (
        <Container style={{ marginTop: "7em" }}>
            <h1>Hello home</h1>

            <Button as={Link} to='/login' size="huge" inverted>
                Login
            </Button>
        </Container>
    );
}
