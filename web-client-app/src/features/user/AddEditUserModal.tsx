import { observer } from "mobx-react-lite";
import { Button, DropdownProps, Form, Message, Modal } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { ServiceMan } from "../../app/models/serviceMan";

export interface AddUserModalProps {
    isOpen: boolean;
    onClose: () => void;
    userId: string | undefined;
}

export default observer(function AddEditUserModal(props: AddUserModalProps) {
    const getUserTemplate = (): ServiceMan => {
        return {
            id: "",
            fullName: "",
            bloodGroupId: "",
            bloodGroupName: "",
            brigadeId: "",
            brigadeShortName: "",
            email: "",
            nickName: "",
            userName: "",
            role: "",
            roleId: "",
        };
    };

    const { roleStore, bloodGroupStore, brigadeStore, userStore } = useStore();
    const { users, loading, importUsersResult } = userStore;
    const { roles } = roleStore;
    const { bloodGroups } = bloodGroupStore;
    const { brigades } = brigadeStore;

    const [user, setUser] = useState<ServiceMan>(getUserTemplate());
    const [selectedFile, setSelectedFile] = useState<File | null>(null);

    useEffect(() => {
        userStore.resetImportUsersResult();
        roleStore.getRoles();
        bloodGroupStore.getBloodGroups();
        brigadeStore.getBrigades();
    }, [userStore, roleStore, bloodGroupStore, brigadeStore]);

    useEffect(() => {
        if (props.isOpen) {
            if (props.userId) {
                var existedUser = users.find((u) => u.id === props.userId);
                setUser(existedUser!);
            } else {
                setUser(getUserTemplate());
            }
        }
    }, [users, props.userId, props.isOpen]);

    const rolesOptions = roles.map((r) => ({
        key: r.id,
        text: r.name,
        value: r.id,
    }));
    const bloodGroupsOptions = bloodGroups.map((r) => ({
        key: r.id,
        text: r.name,
        value: r.id,
    }));
    const brigadesOptions = brigades.map((r) => ({
        key: r.id,
        text: r.name,
        value: r.id,
    }));

    function handleInputChange(
        event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
    ) {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    }

    function handleSelectChange(
        event: SyntheticEvent<HTMLElement | Event>,
        data: DropdownProps
    ) {
        const { name, value } = data;
        setUser({
            ...user,
            [name]: value,
            brigadeShortName: "",
            bloodGroupName: "",
            role: "",
        });
    }

    const saveOk = () => {
        return (
            (user.userName !== "" &&
                user.nickName !== "" &&
                user.email !== "" &&
                user.bloodGroupId !== "" &&
                user.brigadeId !== "" &&
                user.roleId !== "") ||
            selectedFile !== null
        );
    };

    const onClose = () => {
        setSelectedFile(null);
        userStore.resetImportUsersResult();
        props.onClose();
    };

    const onSave = () => {
        if (selectedFile !== null) {
            const data = new FormData();
            data.append("file", selectedFile);
            userStore.importUsers(data).then(() => userStore.getUsers());
            setSelectedFile(null);
        } else if (user.id !== "") {
            userStore.updateUser(user).then(() => userStore.getUsers());
            onClose();
        } else {
            userStore.createUser(user).then(() => userStore.getUsers());
            onClose();
        }
    };

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>
                {props.userId ? "Edit" : "Add new"} user
            </Modal.Header>
            <Modal.Content>
                <Form>
                    <Form.Group>
                        <Form.Input
                            width={5}
                            label="UserName"
                            name="userName"
                            value={user.userName}
                            required
                            onChange={handleInputChange}
                        />
                        <Form.Input
                            width={5}
                            label="Nick Name"
                            name="nickName"
                            value={user.nickName}
                            required
                            onChange={handleInputChange}
                        />
                        <Form.Input
                            width={6}
                            label="Email"
                            type="email"
                            name="email"
                            value={user.email}
                            required
                            onChange={handleInputChange}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Input
                            width={12}
                            label="Full Name"
                            name="fullName"
                            value={user.fullName}
                            onChange={handleInputChange}
                        />
                        <Form.Select
                            required
                            width={4}
                            label="Blood group"
                            name="bloodGroupId"
                            value={user.bloodGroupId}
                            options={bloodGroupsOptions}
                            onChange={handleSelectChange}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Select
                            required
                            width={12}
                            label="Brigade"
                            name="brigadeId"
                            value={user.brigadeId}
                            options={brigadesOptions}
                            onChange={handleSelectChange}
                        />
                        <Form.Select
                            required
                            width={4}
                            label="Role"
                            name="roleId"
                            value={user.roleId}
                            options={rolesOptions}
                            onChange={handleSelectChange}
                        />
                    </Form.Group>
                </Form>
                {!props.userId ? (
                    <>
                        <hr />
                        <Form loading={loading}>
                            {importUsersResult ? (
                                <Message>
                                    <Message.Header>
                                        Import result
                                    </Message.Header>
                                    <p>
                                        {importUsersResult} users was imported
                                    </p>
                                </Message>
                            ) : null}
                            <Form.Input
                                type="file"
                                onChange={(e) =>
                                    setSelectedFile(
                                        e.target?.files
                                            ? e.target.files[0]
                                            : null
                                    )
                                }
                                label="Import users"
                            />
                        </Form>
                    </>
                ) : null}
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => onClose()}>Cancel</Button>
                <Button
                    positive
                    onClick={() => onSave()}
                    disabled={!saveOk()}
                    loading={loading}
                >
                    {props.userId ? "Edit" : "Create"}
                </Button>
            </Modal.Actions>
        </Modal>
    );
});
