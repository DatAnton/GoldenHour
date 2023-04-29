import { observer } from "mobx-react-lite";
import { Link, NavLink } from "react-router-dom";
import { Container, Dropdown, Menu, Image } from "semantic-ui-react";
import { useStore } from "../stores/store";

export default observer(function NavBar() {
    const {
        accountStore: { user, logout },
    } = useStore();

    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item as={NavLink} to={"/"} header>
                    Golden Hour
                </Menu.Item>
                <Menu.Item position="right">
                    <Image src="assets/user.png" avatar spaced="right" />
                    <Dropdown pointing="top left" text={user?.userName}>
                        <Dropdown.Menu>
                            <Dropdown.Item
                                as={Link}
                                to={`/profiles/${user?.userName}`}
                                text="My Profile"
                                icon="user"
                            />
                            <Dropdown.Item
                                onClick={logout}
                                text="Logout"
                                icon="power"
                            />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>
    );
});
