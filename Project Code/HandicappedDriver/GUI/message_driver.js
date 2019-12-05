// https://codepedia.info/how-to-call-javascript-function-from-code-behind-server-side-asp-net-c/

function showConfirmationMessage() {
    alert("Message has been successfull sent.");
}


function getDriverVehicleData() {
    var regState = document.getElementById('regState').value;
    var regNum = document.getElementById('regID').value;
    var msg = document.getElementById('msg').value;

    var driverDataObject = "{" + regState + "," + regNum + "," + msg + "}";
    return driverDataObject;

}