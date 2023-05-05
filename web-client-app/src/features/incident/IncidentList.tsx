import { observer } from "mobx-react-lite";
import { Button, Card, Container, Icon } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import IncidentPhotosModal from "./IncidentPhotosModal";

export default observer(function IncidentList() {
    const { incidentStore } = useStore();
    const { incidents } = incidentStore;
    const [incidentPhotosModalOpen, setIncidentPhotosModalOpen] =
        useState(false);

    useEffect(() => {
        incidentStore.getIncidents();
    }, [incidentStore]);

    return (
        <Container>
            <IncidentPhotosModal
                isOpen={incidentPhotosModalOpen}
                onClose={() => setIncidentPhotosModalOpen(false)}
            />
            <Card.Group itemsPerRow={3}>
                {incidents.map((incident) => (
                    <Card>
                        <Card.Content header={incident.serviceMan.fullName} />
                        <Card.Content meta={incident.serviceMan.nickName} />
                        <Card.Content description={incident.dateTime} />
                        <Card.Content
                            description={`${incident.latitude} ${incident.longitude}`}
                        />
                        <Card.Content description={incident.comment} />
                        <Card.Content extra>
                            <Icon name="doctor" />
                            {incident.medicFullName}
                        </Card.Content>
                        <Card.Content textAlign="right" extra>
                            <Button
                                primary
                                onClick={() => setIncidentPhotosModalOpen(true)}
                            >
                                Photos
                            </Button>
                        </Card.Content>
                    </Card>
                ))}
            </Card.Group>
        </Container>
    );
});
