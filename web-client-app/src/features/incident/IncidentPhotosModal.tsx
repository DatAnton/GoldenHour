import { observer } from "mobx-react-lite";
import { Button, Modal } from "semantic-ui-react";

export interface IncidentPhotosModalProps {
    isOpen: boolean;
    onClose: () => void;
}

export default observer(function IncidentPhotosModal(props: IncidentPhotosModalProps) {
    return (
        <Modal open={props.isOpen}>
            <Modal.Header>
                Incident photos
            </Modal.Header>
            <Modal.Content>
                Photos
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => props.onClose()}>Close</Button>
            </Modal.Actions>
        </Modal>
    )
});