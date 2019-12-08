

function store_username_on_localStorage() {

    var username = $('#inputUsername').val();
    var password = $('#inputPassword').val();
    alert(password);
    writeCookie("userName", username);
    createJSON_Obj(username, password);
    
    //window.localStorage.setItem("user_name01", username);
}

function writeCookie(cookie_name, username) {
    
    document.cookie = cookie_name + "=" + username + ";";

}


function createJSON_Obj(user, pass) {
    var obj = [{
        "UserName": user,
        "Password": pass
    }]

    return obj;
}