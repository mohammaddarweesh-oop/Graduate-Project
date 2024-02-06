var map;
var marker;
var infowindow;
var messagewindow;

function initSetMap(location) {
    var options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 0
    }
    function openMap(crd){
        var california = new google.maps.LatLng(31.995616, 35.848489);
        if(crd != ""){
            california = new google.maps.LatLng(crd.latitude, crd.longitude);    
        }
        
        map = new google.maps.Map(document.getElementById('setLocationMab'), {
            center: california,
            zoom: 18,
            mapTypeId: 'satellite'
        });

        infowindow = new google.maps.InfoWindow({
            content: "<span class='info-details'>انقر  هنا لحفظ الموقع</span>"
        })

        messagewindow = new google.maps.InfoWindow({
            content: document.getElementById('message')
        });


        google.maps.event.addListener(map, 'click', function (event) {
            if (marker) {
                marker.setMap(null);
            }

            marker = new google.maps.Marker({
                position: event.latLng,
                map: map
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
                var laten = marker.getPosition();
                var lat = laten.lat();
                var long = laten.lng();
                jQuery('#location').val(lat + "," + long);
                jQuery(".location-map-box").hide('slow');
                jQuery('.open-map-box').show('slow');
            });
        });
    }
    function success(pos) {
        var crd = pos.coords;
        openMap(crd)
    }
    function setDefault(latitude, longitude) {
        var california = {lat: latitude, lng: longitude};

        map = new google.maps.Map(document.getElementById('setLocationMab'), {
            center: california,
            zoom: 18,
            mapTypeId: 'satellite'
        });
        var marker = new google.maps.Marker({
            position: california,
            map: map,
            title: 'موقع العقار'
        });
        infowindow = new google.maps.InfoWindow({
            content: "<span class='info-details'>انقر  هنا لحفظ الموقع</span>"
        })

        messagewindow = new google.maps.InfoWindow({
            content: document.getElementById('message')
        });

        google.maps.event.addListener(map, 'click', function (event) {
            if (marker) {
                marker.setMap(null);
            }
            marker = new google.maps.Marker({
                position: event.latLng,
                map: map
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
                var laten = marker.getPosition();
                var lat = laten.lat();
                var long = laten.lng();
                jQuery('#location').val(lat + "," + long);
                jQuery(".location-map-box").hide('slow');
                jQuery('.open-map-box').show('slow');
            });
        });

    }
    function error(err) {
        console.log("ERROR("+err.code+"):"+ err.message);
        openMap('');
    }
    if (location.trim() != '') {
        var pos = location.split(',');
        setDefault(parseFloat(pos[0]), parseFloat(pos[1]));
    } else {
        navigator.geolocation.getCurrentPosition(success, error, options);
    }


}
(function () {
    var location = jQuery('#location').val();
    //initSetMap(location);
    initSetMap(location)
    
    jQuery('.do-open-map-box').click(function(){
        jQuery('.location-map-box').show('slow');
        jQuery('.open-map-box').hide('slow');
    })

})()
