import { observer } from "mobx-react-lite";
import { Button, Modal } from "semantic-ui-react";
import { GoogleMap, Marker, useLoadScript } from "@react-google-maps/api";
import { useEffect, useState } from "react";
import { useStore } from "../../app/stores/store";

export interface IncidentMapProps {
    isOpen: boolean;
    onClose: () => void;
    incidentId: string | undefined;
}

export default observer(function IncidentMap(props: IncidentMapProps) {
    const { isLoaded } = useLoadScript({
        googleMapsApiKey: process.env.REACT_APP_GOOGLE_API_KEY!,
    });
    const { incidentStore } = useStore();
    const [marker, setMarker] = useState<{ lat: number; lng: number }>();

    useEffect(() => {
        if (props.isOpen && props.incidentId) {
            var incident = incidentStore.findIncident(props.incidentId);
            if (incident) {
                setMarker({
                    lat: parseFloat(incident.latitude),
                    lng: parseFloat(incident.longitude),
                });
            }
        }
    }, [incidentStore, props.incidentId, props.isOpen]);

    return (
        <Modal open={props.isOpen}>
            <Modal.Header>Map</Modal.Header>
            <Modal.Content>
                <div className="AppMap">
                    {!isLoaded ? (
                        <h1>Loading...</h1>
                    ) : (
                        <GoogleMap
                            mapContainerClassName="map-container"
                            center={marker}
                            zoom={13}
                        >
                            <Marker position={marker!} />
                        </GoogleMap>
                    )}
                </div>
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => props.onClose()}>Close</Button>
            </Modal.Actions>
        </Modal>
    );
});
