import { observer } from "mobx-react-lite";
import { Button, Card, Container, Icon } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import IncidentPhotosModal from "./IncidentPhotosModal";
import IncidentMap from "./IncidentMap";

export default observer(function IncidentList() {
    const { incidentStore } = useStore();
    const { incidents } = incidentStore;
    const [incidentPhotosModalOpen, setIncidentPhotosModalOpen] =
        useState(false);
    const [mapModalOpen, setMapModalOpen] = useState(false);
    const [selectedIncident, setSelectedIncident] = useState<
        string | undefined
    >(undefined);

    useEffect(() => {
        incidentStore.getIncidents();
        incidentStore.createHubConnection();
    }, [incidentStore]);

    return (
        <Container>
            <IncidentPhotosModal
                isOpen={incidentPhotosModalOpen}
                onClose={() => setIncidentPhotosModalOpen(false)}
                incidentId={selectedIncident}
            />

            <IncidentMap
                isOpen={mapModalOpen}
                onClose={() => setMapModalOpen(false)}
                incidentId={selectedIncident}
            />
            <Card.Group itemsPerRow={3}>
                {incidents.map((incident) => (
                    <Card key={incident.id}>
                        <Card.Content header={incident.serviceMan.fullName} />
                        <Card.Content meta={incident.serviceMan.nickName} />
                        <Card.Content description={incident.dateTime} />
                        <Card.Content
                            description={`${incident.latitude} ${incident.longitude}`}
                        />
                        {incident.comment && incident.comment !== "" ? (
                            <Card.Content description={incident.comment} />
                        ) : null}
                        <Card.Content extra>
                            <Icon name="doctor" />
                            {incident.medicFullName}
                        </Card.Content>
                        <Card.Content textAlign="right" extra>
                            <Button
                                positive
                                onClick={() => {
                                    setSelectedIncident(incident.id);
                                    setMapModalOpen(true);
                                }}
                                icon="map pin"
                            />
                            <Button
                                icon="picture"
                                primary
                                onClick={() => {
                                    setSelectedIncident(incident.id);
                                    setIncidentPhotosModalOpen(true);
                                }}
                            />
                        </Card.Content>
                    </Card>
                ))}
            </Card.Group>
        </Container>
    );
});
