// https://www.encodedna.com/javascript/populate-select-dropdown-list-with-json-data-using-javascript.htm

var lotObj = [
    {
        "lotName": "math & computer science building",
        "lot_ID": 1,
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

var spotObj = [{
    "lot_ID": 1,
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
},
    {
        "lot_ID": 2,
        "Spot": [{
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
    },
    
    ];


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

    

    $(lotDropdown).change(function () {
        var selectedLot = $(lotDropdown).val();
        selectedLot = parseInt(selectedLot);
        spotDropdown.clear();


        for (var j = 0; j < spotObj[selectedLot].Spot.length; j++) {
            //                 '<option value="' + spotObj[selectedLot].Spot.spotID + '">' + spotObj[selectedLot]['Spot']['spotName'] + '</option>';

            spotDropdown.innerHTML = spotDropdown.innerHTML +
                '<option value="' + spotObj[selectedLot].Spot.spotID + '">' + spotObj[selectedLot]['Spot']['spotName'] + '</option>';
        

        }



    });


});

