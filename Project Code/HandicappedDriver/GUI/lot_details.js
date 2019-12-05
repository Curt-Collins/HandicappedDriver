function generate_lot_details() {
    //alert("function called");
    var lotContainer = document.getElementById("spot-info");
    var htmlString = "<p>";
    //var result = "revbjh"

    // get the spot info from c# method
    PageMethod.ViewAvailableSpaces(lot_id, onSucess, onError);


    function onSucess(result) {
        htmlString += result;
        htmlString += "</p>";

    }
    function onError(result) {
        alert("Something went wrong. Please try again");
    }
    lotContainer.insertAdjacentHTML('beforeend', htmlString);

}

function create_lot_data() {
    var space_ID = document.getElementById('myLotDropdown').value;
    var start_time = document.getElementById('startTime').value;
    var end_time = document.getElementById('endTime').value;

    var lot_data_object = "{" + "\"space_ID\"" + space_ID + "," + "\"FromTime\"" + start_time + "," + "\"UntilTime\"" + end_time + "}";
    return lot_data_object;
}