import { ChangeEvent, useState } from "react";
import { Form, Message } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { UserFormValues } from "../../app/models/user";

export default observer(function LoginForm() {
    const { accountStore } = useStore();
    const [error, setError] = useState<string>("");

    const [userForm, setUserForm] = useState<UserFormValues>({
        userName: "",
        password: "",
    });

    const handleSubmit = () => {
        accountStore
            .login(userForm)
            .catch((error) => setError("Invalid username or password"));
    };

    function handleInputChange(
        event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
    ) {
        const { name, value } = event.target;
        setUserForm({ ...userForm, [name]: value });
    }

    return (
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
    );
});
