var getCurrentLocation = function(){
	if (!navigator.geolocation)
		return initMap(0, 0);

	navigator.geolocation.getCurrentPosition(getUserPosition);
}

var getUserPosition = function(currentPosition){
	let currentLatitude = currentPosition.coords.latitude;
	let currentLongitude = currentPosition.coords.longitude;

	initMap(currentLatitude, currentLongitude);
}

var initMap = function(currentLatitude, currentLongitude){

	let mapDiv = document.getElementById("mapDiv");
	let map = new google.maps.Map(mapDiv, {
		center: {
			lat: currentLatitude,
			lng: currentLongitude
		},
		zoom: 13
	});

	let addressInput = document.getElementById("placeName"); 

	let autocomplete = new google.maps.places.Autocomplete(addressInput);
	autocomplete.bindTo("bounds", map);

	let myLatLng = { lat: currentLatitude, lng: currentLongitude };

	var marker = new google.maps.Marker({
		position: myLatLng,
		map: map
	});

	autocomplete.addListener("place_changed", function(){
		marker.setVisible(false);
		var place = autocomplete.getPlace();

		if(!place.geometry){
			window.alert("No details available for input: " + place.name);
			return;
		}	

		// If the place has a geometry, then present it on a map.
	  	if (place.geometry.viewport) {
	    	map.fitBounds(place.geometry.viewport);
	  	} else {
	        map.setCenter(place.geometry.location);
	        map.setZoom(17);  // Why 17? Because it looks good.
	  	}
	    
	  	marker.setIcon(/** @type {google.maps.Icon} */({
	    	url: place.icon,
	    	size: new google.maps.Size(71, 71),
	    	origin: new google.maps.Point(0, 0),
	    	anchor: new google.maps.Point(17, 34),
	    	scaledSize: new google.maps.Size(35, 35)
	  	}));
	  	marker.setPosition(place.geometry.location);
	  	marker.setVisible(true);
	});

}