import "@goongmaps/goong-js/dist/goong-js.css";
import "@goongmaps/goong-geocoder/dist/goong-geocoder.css";
import React, { useRef, useState,useCallback  } from "react";
import MapGL, {
  NavigationControl,
  FullscreenControl,
  ScaleControl,
  GeolocateControl
} from "@goongmaps/goong-map-react";
import Geocoder from '@goongmaps/goong-geocoder-react';
import CITIES from "../data/cities.json";
import Pins from "./Pins";
const geolocateStyle = {
  top: 0,
  left: 0,
  padding: "10px"
};

const fullscreenControlStyle = {
  top: 36,
  left: 0,
  padding: "10px"
};

const navStyle = {
  top: 72,
  left: 0,
  padding: "10px"
};


const Mapbox=()=> {
  const [viewport, setViewport] = useState({
    latitude: 21.013470323298243,
    longitude: 105.52708575547926,
    zoom: 12
  });
  const [showPopup, togglePopup] = React.useState(false);
  const mapRef = useRef(null);
  const handleViewportChange = useCallback(
    (newViewport) => setViewport(newViewport),
    []
  );
  const [popupInfo, setPopupInfo] = useState(null);
  // const handleViewportChange = (newViewport) => {
  //   setViewport({ ...viewport, ...newViewport });
  // };

  // if you are happy with Geocoder default settings, you can just use handleViewportChange directly
  const handleGeocoderViewportChange = (viewport) => {
    const geocoderDefaultOverrides = { transitionDuration: 1000 };

    return handleViewportChange({
      ...viewport,
      ...geocoderDefaultOverrides
    });
  };

  return (


   <>
   <MapGL
      ref={mapRef}
      {...viewport}
      width="100%"
      height="100%"
      onViewportChange={handleViewportChange}
      goongApiAccessToken="4dAgWahZ3jW5LsZCiYikMTvVUOYpd2jcmxz3kyLA"
      style={{
        position:'absolute'
      }}
    >
      <Geocoder
        className="mapboxgl-ctrl-top-right"
        
        mapRef={mapRef}
        onViewportChange={handleGeocoderViewportChange}
        goongApiAccessToken="oC8CNdh20xrH8Dpm0SIkZYQqBijW847QWVmBE0DB"
        style={{
          position:'relative'
        }}
      />
      </div>
     
      <Pins data={CITIES} onClick={setPopupInfo} />
      <Marker
      
      longitude={viewport.longitude}
      latitude={viewport.latitude}
    >
      <svg
        height={SIZE}
        viewBox="0 0 24 24"
        style={{
          cursor: "pointer",
          fill: "#d00",
          stroke: "none",
          transform: `translate(${-SIZE / 2}px,${-SIZE}px)`
        }}
        
      >
        <path d={ICON} />
      </svg>
    </Marker>
      {showPopup && <Popup
          latitude={21.013470323298243}
          longitude={105.52708575547926}
          closeButton={true}
          closeOnClick={false}
          onClose={() => togglePopup(false)}
          anchor="top" >
          <div>You are here</div>
        </Popup>}
      
       <GeolocateControl style={geolocateStyle} />
        <FullscreenControl style={fullscreenControlStyle} />
        <NavigationControl style={navStyle} /> 
     
      
    </MapGL>
   </>

    
  );
}

export default Mapbox;