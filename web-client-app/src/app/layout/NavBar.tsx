import { NavLink } from "react-router-dom";
import { Container, Menu } from "semantic-ui-react";

export default function NavBar() {
    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item as={NavLink} to={"/"} header>
                    Golden Hour
                </Menu.Item>
            </Container>
        </Menu>
    );
}
