// resource(s) for map direction
// https://jsfiddle.net/vgrem/51nkmncd/

function showMap() {
    var lat = "35.654066";
    var lng = "-97.473176";
    //var lat = "" + latitude;
    //var lng = "" + longitude;
    var url = "https://maps.google.com/?q=" + lat + "," + lng;
    //var url = "https://www.google.com/maps/@" + lat + "," + lng;
    window.open(url);
}

            // function openGoogleMaps(){
            //     var cords = "40.4003053,-104.7702377";
            //     var url = "https://www.google.com/maps/search/?api=1&q"+cords;//"https://www.google.com.sa/maps/search/"+ cords +",12.21z?hl=en";
            //     windows.open("https://www.google.com.sa/maps/@35.6237254,-97.5573735,15z");
            //     // window.open("https://www.w3schools.com");
            // }