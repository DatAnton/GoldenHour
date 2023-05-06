import { observer } from "mobx-react-lite";
import { Button, Modal, Image, Card } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";

export interface IncidentPhotosModalProps {
    isOpen: boolean;
    onClose: () => void;
    incidentId: string | undefined
}

export default observer(function IncidentPhotosModal(props: IncidentPhotosModalProps) {
    const { incidentStore} = useStore();
    const [images, setImages] = useState<string[]>();

    useEffect(() => {
        if(props.isOpen && props.incidentId)
        {
            var incident = incidentStore.findIncident(props.incidentId);
            if(incident)
            {
                setImages(incident.images);
            }
        }
    }, [incidentStore, props.incidentId, props.isOpen]);

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>
                Incident photos
            </Modal.Header>
            <Modal.Content>
                <Card.Group itemsPerRow={3}>
                    {images?.map((image, idx) => (
                        <Card key={idx}>
                            <Image rounded src={`data:image/jpeg;base64,${image}`} size="medium" />
                        </Card>
                    ))}
                </Card.Group>
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => props.onClose()}>Close</Button>
            </Modal.Actions>
        </Modal>
    )
});