window.showMap = function (id, latitudine, longitudine, zoom, markers) {
    console.log(markers);

    var map = L.map(id).setView([latitudine, longitudine], zoom);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);

    if (markers)
    {
        for (let i = 0; i < markers.length; i++)
        {
            DotNet.invokeMethodAsync('Blazor.UI.Library', 'GetInfo', markers[i].id)
                .then(desc => {
                    var description = markers[i].id + " " + markers[i].description + " " + desc;
                    var marker = L.marker([markers[i].mapCoordinates.latitude, markers[i].mapCoordinates.longitude]).addTo(map);
                    marker.bindPopup("<b>" + description + "</b>").openPopup();
                    ;
                });

            
        }
    }


    
}