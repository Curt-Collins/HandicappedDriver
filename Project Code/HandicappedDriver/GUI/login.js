

function store_username_on_localStorage() {

    var username = $('#inputUsername').val();
    writeCookie("userName", username);
    
    //window.localStorage.setItem("user_name01", username);
}

function writeCookie(cookie_name, username) {
    
    document.cookie = cookie_name + "=" + username + ";";


}
