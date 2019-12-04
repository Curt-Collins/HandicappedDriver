new user_acc_json_obj;

function initialise_variables() {
    var name = document.getElementById('name').value;
    var username = document.getElementById('userName').value;
    var phone_number = document.getElementById('phNum').value;
    var registration_state = document.getElementById('regState').value;
    var licNumber = document.getElementById('licNumber').value;
    var password = document.getElementById('pass').value;
    //var confirm_pass = document.getElementById('confirmPass').value;
    //alert(name + username + phone_number + registration_state + licNumber + password);

    user_acc_json_obj = {
        //"name": name,
        "LicensePlateState_ID": licNumber,
        "EMail": username + "@uco.edu",
        "Password": password,
        "MobileNum": phone_number,
        "LicensePlate": registration_state 
    }

    PageMethods.UpdateDriverProfile(user_acc_json_obj, onSucess, onError);
    function onSucess(result) {
        alert(result);
    }
    function onError(result) {
        alert("Something went wrong. Please try again")
    }
}

//function chack_match_password(pass, confirm_pass) {
    //if()
//}