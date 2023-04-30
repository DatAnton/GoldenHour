import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Button, Form, Modal } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export interface ChangePasswordModalProps {
    onClose: () => void;
    isOpen: boolean;
}

export default observer(function ChangePasswordModal(
    props: ChangePasswordModalProps
) {
    const { userStore, accountStore } = useStore();
    const [oldPassword, setOldPassword] = useState("");
    const [newPassword, setNewPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState<string | undefined>(undefined);

    const handleSubmit = () => {
        if (newPassword !== confirmPassword) {
            setError("Confirm password is not correct");
        } else {
            userStore.changePassword({
                newPassword,
                oldPassword,
                confirmPassword,
            }).finally(() => {
                clearForm();
                props.onClose();
                accountStore.logout();
            });
        }
    };

    const clearForm = () => {
        setNewPassword("");
        setOldPassword("");
        setConfirmPassword("");
        setError(undefined);
    };

    const okToSave = () => {
        return (
            oldPassword !== "" && newPassword !== "" && confirmPassword !== ""
        );
    };

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>Change password</Modal.Header>
            <Modal.Content>
                <Form className="ui form" onSubmit={handleSubmit}>
                    <Form.Input
                        type="password"
                        label="Old password"
                        value={oldPassword}
                        onChange={(e) => setOldPassword(e.currentTarget.value)}
                    />
                    <Form.Input
                        type="password"
                        label="New password"
                        value={newPassword}
                        onChange={(e) => setNewPassword(e.currentTarget.value)}
                    />

                    <Form.Input
                        error={error}
                        type="password"
                        label="Confirm password"
                        value={confirmPassword}
                        onChange={(e) =>
                            setConfirmPassword(e.currentTarget.value)
                        }
                    />

                    <Form.Button
                        disabled={!okToSave()}
                        content="Change"
                        type="submit"
                        positive
                        fluid
                    />
                </Form>
            </Modal.Content>
            <Modal.Actions>
                <Button
                    onClick={() => {
                        clearForm();
                        props.onClose();
                    }}
                >
                    Close
                </Button>
            </Modal.Actions>
        </Modal>
    );
});
