// https://www.encodedna.com/javascript/populate-select-dropdown-list-with-json-data-using-javascript.htm

var lotObj = [
    {
        "lotName": "math & computer science building",
        "lot_ID": 1,
    },

    {
        "lotName": "nigh university center",
        "lot_ID": 2,
        "Spot": [{
            "spotName": "Spot 1",
            "spotID": 1
        },
        {
            "spotName": "Spot 2",
            "spotID": 2
        },
        {
            "spotName": "Spot 3",
            "spotID": 3
        },
        {
            "spotName": "Spot 4",
            "spotID": 4
        }]

    },
    {
        "lotName": "chamber's library",
        "lot_ID": 3,
        "Spot": [{
            "spotName": "Spot 1",
            "spotID": 1
        },
        {
            "spotName": "Spot 2",
            "spotID": 2
        },
        {
            "spotName": "Spot 3",
            "spotID": 3
        }]
        
    }];

var spotObj = [
    {
        "lot_ID": 1,
        "spot":[{
            "spotName": "Spot 1",
            "spotID": 1
        },
        {
            "spotName": "Spot 2",
            "spotID": 2
        },
        {
            "spotName": "Spot 3",
            "spotID": 3
        }]
    },
    {
        "lot_ID": 2,
        "spot": [{
            "spotName": "Spot 1",
            "spotID": 1
        },
        {
            "spotName": "Spot 2",
            "spotID": 2
        }]
        
    },
    {
        "lot_ID": 3,
        "spot": [{
            "spotName": "Spot 1",
            "spotID": 1
        },
        {
            "spotName": "Spot 2",
            "spotID": 2
        },
        {
            "spotName": "Spot 3",
            "spotID": 3
        }]
    }

]



$(document).ready(function () {
    //alert("jdsvdf");
    var lotDropdown = document.getElementById('myLotDropdown');
    var spotDropdown = document.getElementById('mySpotDropdown');

    

    // use json.parse() to convert json string to json object

    for (var i = 0; i < lotObj.length; i++) {
        // check on the variable ( parkinglot_id, lotname ) name with leif
        lotDropdown.innerHTML = lotDropdown.innerHTML +
            '<option value="' + lotObj[i]['lot_ID'] + '">' + lotObj[i]['lotName'] + '</option>';

    }

    

    $('#myLotDropdown').change(function () {
        var selectedLot = $(lotDropdown).val();
        selectedLot = parseInt(selectedLot);
        spotDropdown.clear();

        if (selectedLot == 1) {
            for (var k = 0; k < spotObj[1].spot.length; k++) {
                spotDropdown.innerHTML += '<option value="' +
                    spotObj[1].spot[k].spotID + '">' + spotObj[1].spot[k].spotName + '</option>';
            }
        }

        
    });






});

