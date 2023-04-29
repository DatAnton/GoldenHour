import { observer } from "mobx-react-lite";
import { Button, Form, Modal } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";

export interface AddUserModalProps {
    isOpen: boolean;
    onClose: () => void;
}

export default observer(function AddUserModal(props: AddUserModalProps) {
    const { roleStore, bloodGroupStore, brigadeStore } = useStore();
    const { roles } = roleStore;
    const { bloodGroups } = bloodGroupStore;
    const { brigades } = brigadeStore;

    useEffect(() => {
        roleStore.getRoles();
        bloodGroupStore.getBloodGroups();
        brigadeStore.getBrigades();
    }, [roleStore, bloodGroupStore, brigadeStore]);

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

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>Add new user</Modal.Header>
            <Modal.Content>
                <Form>
                    <Form.Group>
                        <Form.Input width={5} label="UserName" required />
                        <Form.Input width={5} label="Nick Name" required />
                        <Form.Input
                            width={6}
                            label="Email"
                            type="email"
                            required
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Input width={12} label="Full Name" />
                        <Form.Select
                            required
                            width={4}
                            label="Blood group"
                            options={bloodGroupsOptions}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Select
                            required
                            width={12}
                            label="Brigade"
                            options={brigadesOptions}
                        />
                        <Form.Select
                            required
                            width={4}
                            label="Role"
                            options={rolesOptions}
                        />
                    </Form.Group>
                </Form>
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => props.onClose()}>Cancel</Button>
                <Button positive onClick={() => props.onClose()}>
                    Create
                </Button>
            </Modal.Actions>
        </Modal>
    );
});
