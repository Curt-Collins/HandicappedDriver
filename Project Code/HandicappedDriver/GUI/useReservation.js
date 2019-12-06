// resource(s) for map direction
// https://jsfiddle.net/vgrem/51nkmncd/

var resv_ID;

$(document).ready(function () {
    var x = document.cookie;
    //alert(x);
    var arr = x.split("=");
    
    //for (var i = 0; i < arr.length; i++) {
    //    console.log(arr[i]);
    //}
    var userName = arr[1];
    //alert(userName);

    PageMethods.ShowExistingReservation(username, onSucess, onError);
    function onSucess(result) {

        // check "resvID" variable name
        var resvObj = JSON.parse(result)

        resv_ID = resvObj.resvID;
        resv_ID += "";

    }

    function onError(result) {
        alert("Error: loading reservation data");
    }
    

});

function fncn_occupy() {
    PageMethods.OccupySpace(resv_ID, onSucess, onError);
    function onSucess(result) {
        alert("Status has been changed to occupied");
    }
    function onError(result) {
        alert("Occupy: Error while changing parking status");
    }
}

function fncn_leave() {
    PageMethods.LeaveSpace(resv_ID, onSucess, onError);
    function onSucess(result) {
        alert("Status has been changed to available");
    }
    function onError(result) {
        alert("Leave: Error while changing parking status");
    }
}

function fncn_CancelReservation() {
    PageMethods.CancelReservation(resv_ID, onSucess, onError);
    function onSucess(result) {
        alert("Cancellation has been sucessfull");
    }
    function onError(result) {
        alert("Cancel: Error while changing parking status");
    }
}