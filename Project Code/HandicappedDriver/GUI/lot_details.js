// https://www.encodedna.com/javascript/populate-select-dropdown-list-with-json-data-using-javascript.htm

$(document).ready(function () {
    var arr = [{
        "LotName": "Math & Computer Science Building",
        "lot_ID": 1
    },
    {
        "LotName": "Nigh University Center",
        "lot_ID": 2
    },
    {
        "LotName": "Chamber's library",
        "lot_ID": 3
    }];

    var dropdownList = document.getElementById('myLotDropdown');
    for (var i = 0; i < arr.length; i++) {

        dropdownList.innerHTML = dropdownList.innerHTML +
            '<option value="' + arr[i]['lot_ID'] + '">' + arr[i]['LotName'] + '</option>';
    }
});

//function populateSelect() {
//    var clickCtr = 0;
//    var arr = [{
//            "LotName": "Math & Computer Science Building",
//            "lot_ID": 1
//        },
//        {
//            "LotName": "Nigh University Center",
//            "lot_ID": 2
//        },
//        {
//            "LotName": "Chamber's library",
//            "lot_ID": 3
//        }
//    ];

//    var dropdownList = document.getElementById('myLotDropdown');
//    for (var i = 0; i < arr.length; i++) {
//        if (clickCtr === 1) {
//            break;
//        }
//        dropdownList.innerHTML = dropdownList.innerHTML +
//            '<option value="' + arr[i]['lot_ID'] + '">' + arr[i]['LotName'] + '</option>';
//        clickCtr++;
//    }
//}








// function that gets user's selections
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