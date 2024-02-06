
var customLabel = {
    restaurant: {
        label: 'R'
    },
    bar: {
        label: 'B'
    }
};

function initMap() {
    var position = new google.maps.LatLng(31.995616, 35.848489);
    var map = new google.maps.Map(document.getElementById('map'), {
        center: position,
        zoom: 17,
        mapTypeId: 'hybrid'
    });
    var textName = "مؤســــــــــــــــــــسة الهـــــــــــدا العقاريــــــــــــــه";
    var textAdd = "خـــــــــــــــــــــلدا - اشــــــــــارة البنك العربي ";
    textAdd += "مقابل البنك الاسلامي الاردني - عماره 114";


   

    var currentLocation = {
        'id': '1',
        'name': textName,
        'address': textAdd,
        'type': 'estates consultante',
        'lat': '31.995616',
        'lng': '35.848489',
    }
    var infoWindow = new google.maps.InfoWindow;

    // Change this depending on the name of your PHP or XML file
    var image =window.asset_url +"images/makers/marker.png";
    var point = new google.maps.LatLng(parseFloat(currentLocation.lat), parseFloat(currentLocation.lng));
    var infowincontent = document.createElement('div');
    var strong = document.createElement('strong');
    strong.textContent = currentLocation.name
    infowincontent.appendChild(strong);
    infowincontent.appendChild(document.createElement('br'));

    var text = document.createElement('text');
    text.textContent = currentLocation.address
    infowincontent.appendChild(text);
    var icon = customLabel[currentLocation.type] || {};
    var marker = new google.maps.Marker({
        map: map,
        position: point,
        label: icon.label,
        icon: image
    });
    marker.addListener('click', function () {
        infoWindow.setContent(infowincontent);
        infoWindow.open(map, marker);
    });
//    downloadUrl('https://storage.googleapis.com/mapsdevsite/json/mapmarkers2.xml', function (data) {
//        var xml = data.responseXML;
//        var markers = xml.documentElement.getElementsByTagName('marker');
//        Array.prototype.forEach.call(markers, function (markerElem) {
//            var id = markerElem.getAttribute('id');
//            var name = markerElem.getAttribute('name');
//            var address = markerElem.getAttribute('address');
//            var type = markerElem.getAttribute('type');
//            var point = new google.maps.LatLng(
//                    parseFloat(markerElem.getAttribute('lat')),
//                    parseFloat(markerElem.getAttribute('lng')));
//
//            var infowincontent = document.createElement('div');
//            var strong = document.createElement('strong');
//            strong.textContent = name
//            infowincontent.appendChild(strong);
//            infowincontent.appendChild(document.createElement('br'));
//
//            var text = document.createElement('text');
//            text.textContent = address
//            infowincontent.appendChild(text);
//            var icon = customLabel[type] || {};
//            var marker = new google.maps.Marker({
//                map: map,
//                position: point,
//                label: icon.label
//            });
//            marker.addListener('click', function () {
//                infoWindow.setContent(infowincontent);
//                infoWindow.open(map, marker);
//            });
//        });
//    });
}



function downloadUrl(url, callback) {
    var request = window.ActiveXObject ?
            new ActiveXObject('Microsoft.XMLHTTP') :
            new XMLHttpRequest;

    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            request.onreadystatechange = doNothing;
            callback(request, request.status);
        }
    };

    request.open('GET', url, true);
    request.send(null);
}

function doNothing() {
    alert('11')
}



function initMapOnDetailsPage(data) {
    if (data.position == '') {
        jQuery('#map_assetes_details').hide();
        jQuery(".map-error-message").show();
        return;
    }
    var pos = data.position.split(',');

    var map = new google.maps.Map(document.getElementById('map_assetes_details'), {
        center: new google.maps.LatLng(pos[0], pos[1]),
        zoom: 16,
        mapTypeId: 'satellite'

    });

    var currentLocation = {
        'id': data.id,
        'name': data.name,
        'address': 'موقع العقار',
        'type': data.type,
        'lat': pos[0],
        'lng': pos[1],
    }
    var infoWindow = new google.maps.InfoWindow;

// Change this depending on the name of your PHP or XML file

    var point = new google.maps.LatLng(parseFloat(currentLocation.lat), parseFloat(currentLocation.lng));
    var infowincontent = document.createElement('div');
    var strong = document.createElement('strong');
    strong.textContent = currentLocation.name
    infowincontent.appendChild(strong);
    infowincontent.appendChild(document.createElement('br'));

    var text = document.createElement('text');
    text.textContent = currentLocation.address
    infowincontent.appendChild(text);
    var icon = customLabel[currentLocation.type] || {};
    var marker = new google.maps.Marker({
        map: map,
        position: point,
        label: icon.label
    });
    marker.addListener('click', function () {
        infoWindow.setContent(infowincontent);
        infoWindow.open(map, marker);
    });
}


