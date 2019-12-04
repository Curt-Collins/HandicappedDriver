var button_counter = 1;
var lotContainer = document.getElementById('spot-info');
function generate_lot_details() {
    var request = new XMLHttpRequest();
    request.open('GET', 'https://learnwebcode.github.io/json-example/animals-1.json');
    request.onload = function () {
        if (request.status >= 200 && request.status < 400) {
            var data = JSON.parse(request.responseText);
            renderHTML(data);
        } else {
            alert("Connected to the server, but it returned an error");
        }
    };

    request.onerror = function () {
        alert("Connection error");
    };

    request.send();
    if (button_counter >= 2) {
        disableBtn();
    }
    button_counter++;

}

function disableBtn() {
    document.getElementById('generateSpotBtn').disabled = true;
}

function renderHTML(data) {
    var htmlString = "";

    for (i = 0; i < data.length; i++) {
        htmlString += "<p>" + data[i].name/*space_ID*/ + " is unavailable from " + data[i].species/*FromTime*/ + " to " + data[i].species/*UntilTime*/;
        
        htmlString += ".</p>";
    }

    lotContainer.insertAdjacentHTML('beforeend', htmlString);
}