// function initMap() {
//   const center = { lat: 40.4093, lng: 49.8671 }; // Баку
//   new google.maps.Map(document.getElementById("map"), {
//     zoom: 12,
//     center: center,
//   });
// }

let selectedLocation = null;

function initMap() {
  const center = { lat: 40.4093, lng: 49.8671 }; // Баку
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 12,
    center: center,
  });

  let marker = null;

  map.addListener("click", (e) => {
    selectedLocation = {
      lat: e.latLng.lat(),
      lng: e.latLng.lng(),
    };

    if (marker) {
      marker.setMap(null);
    }

    marker = new google.maps.Marker({
      position: selectedLocation,
      map: map,
    });
  });

  document.getElementById("select-location").addEventListener("click", () => {
    if (selectedLocation) {
      alert(`Selected location:\nLatitude: ${selectedLocation.lat}\nLongitude: ${selectedLocation.lng}`);
    } else {
      alert("Please click on the map to select a location.");
    }
  });
}

document.getElementById("select-location").addEventListener("click", () => {
  if (selectedLocation) {
    const { lat, lng } = selectedLocation;
    window.location.href = `/weather/weatindex.html?lat=${lat}&lng=${lng}`;
  } else {
    alert("Сначала выбери точку на карте.");
  }
});


