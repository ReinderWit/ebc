var mymap = L.map('map').setView([52.093421, 5.118278], 15);

L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoicmVpbmRlcndpdCIsImEiOiJja3B0aHNzZWEwc2NoMm5tbnBqNDczMmM1In0.msrou7NTfQRrFjoaypnFSw', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: 'pk.eyJ1IjoicmVpbmRlcndpdCIsImEiOiJja3B0aHNzZWEwc2NoMm5tbnBqNDczMmM1In0.msrou7NTfQRrFjoaypnFSw'
}).addTo(mymap);

for (var i = 0; i < cameras.length; i++) {
    var obj = cameras[i];
    console.log(obj['Latitude']);
    var marker = L.marker([obj['Latitude'], obj['Longitude']]).addTo(mymap);
    marker.bindPopup(`<b>${obj['Name']}</b><br>${obj['Number']}`);
}