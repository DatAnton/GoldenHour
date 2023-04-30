import { ChangeEvent, useState } from "react";
import { Button, Form, Message, Modal } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { UserFormValues } from "../../app/models/user";

export interface LoginFormProps {
    onClose: () => void;
    isOpen: boolean;
}

export default observer(function LoginForm(props: LoginFormProps) {
    const { accountStore } = useStore();
    const [error, setError] = useState<string>("");

    const [userForm, setUserForm] = useState<UserFormValues>({
        userName: "",
        password: "",
    });

    const handleSubmit = () => {
        accountStore.login(userForm).catch((error) => {
            setError("Invalid username or password");
            setUserForm({ ...userForm, password: "" });
        });
    };

    function handleInputChange(
        event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
    ) {
        const { name, value } = event.target;
        setUserForm({ ...userForm, [name]: value });
    }

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>Login</Modal.Header>
            <Modal.Content>
                <Form className="ui form" onSubmit={handleSubmit}>
                    <Form.Input
                        placeholder="UserName"
                        name="userName"
                        value={userForm.userName}
                        onChange={handleInputChange}
                    />
                    <Form.Input
                        type="password"
                        name="password"
                        placeholder="Password"
                        value={userForm.password}
                        onChange={handleInputChange}
                    />
                    {error !== "" ? (
                        <Message negative>
                            <p>{error}</p>
                        </Message>
                    ) : undefined}
                    <Form.Button content="Login" type="submit" positive fluid />
                </Form>
            </Modal.Content>
            <Modal.Actions>
                <Button
                    onClick={() => {
                        setError("");
                        setUserForm({
                            ...userForm,
                            userName: "",
                            password: "",
                        });
                        props.onClose();
                    }}
                >
                    Close
                </Button>
            </Modal.Actions>
        </Modal>
    );
});
