// https://www.encodedna.com/javascript/populate-select-dropdown-list-with-json-data-using-javascript.htm



$(document).ready(function () {
    var lotDropdown = document.getElementById('myLotDropdown');
    var spotDropdown = document.getElementById('mySpotDropdown');
    var lotContainer = document.getElementById("spot-info");
    var htmlString;

    var spaceObj;
    var lotObj;

    //var lotObj = [{
    //        "LotName": "Math & Computer Science Building",
    //        "lot_ID": 1            
    //    },

    //    {
    //        "LotName": "Nigh University Center",
    //        "lot_ID": 2

    //    },
    //    {
    //        "LotName": "Chamber's library",
    //        "lot_ID": 3
    //    }];

    // USE JSON.parse() TO CONVERT JSON string to JSON OBJECT




    // FOR 'LOT'

    //PageMethods.GetParkingLots(onSucess, onError);
    //function onSucess(result) {
    //    alert("function called");
    //    lotObj = JSON.parse(result);        

    //    for (var i = 0; i < lotObj.length; i++) {
    //        // check on the variable ( ParkingLot_ID, LotName ) name with Leif
    //        lotDropdown.innerHTML = lotDropdown.innerHTML +
    //            '<option value="' + lotObj[i]['ParkingLot_ID'] + '">' + lotObj[i]['LotName'] + '</option>';

    //    }

    //    //var lotLength = lotDropdown.length;


    //    // listens to check if the lot dropdown's value has been changed.
    //    $(lotdropdown).change(function () {
    //        var value = $(lotdropdown).val(); // get the value of currently selected option
    //        $(spotdropdown).empty();    // empty the spot dropdown.
    //        var lotid = parseint(value);

    //        update_spot(lotid);  // call the c# method to get the spot with the given lot id.
    //        reset_soptinfo_htmlstring();

    //    });

    //}

    



    $.ajax({
        type: "POST",
        URL: 'Facade.cs/GetParkingLots',
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        sucess: alert("sucess"),
        
        error: alert("failed"),
        
    });


    

    //function onError(result) {
    //    alert("Error: dropdown cannot be populated");
    //}


});

function update_spot(lotID) {

    // FOR 'SPOT'

    PageMethods.ViewAvailableSpaces(lotID, onSucess, onError);
    function onSucess(result) {
        spaceObj = JSON.parse(result);
        for (var i = 0; i < spaceObj.length; i++) {
            // check on the variable ( ParkingLot_ID, LotName ) name with Leif
            spotDropdown.innerHTML = spotDropdown.innerHTML +
                '<option value="' + spaceObj[i]['ParkingSpace_ID'] + '">' + "Space " +
                spaceObj[i]['ParkingSpace_ID'] + '</option>';

        }
        generate_lot_details(spaceObj);
    }

    function onError(result) {
        alert("Error: Couldn't fetch spot informations")
    }


}





// function that gets user's selections
function generate_lot_details(spaceObj) {
    htmlString = "<p>";
    
    for (var i = 0; i < spaceObj.length; i++) {
        htmlString += spaceObj[i]['ParkingLot_ID'] + " is unavailable from " + spaceObj[i]['FromTime'] + " to " + spaceObj[i]['UntilTime'] + "</p>"
    }
    lotContainer.insertAdjacentHTML('beforeend', htmlString);
}

function reset_soptInfo_htmlString() {
    htmlString = "<p></p>"
    lotContainer.insertAdjacentHTML('beforeend', htmlString);

}