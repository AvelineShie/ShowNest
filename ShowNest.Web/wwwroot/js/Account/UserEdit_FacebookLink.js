﻿


window.fbAsyncInit = function () {
    FB.init({
        appId: '2116807325357122',
        xfbml: true,
        version: 'v19.0'
    });
    FB.AppEvents.logPageView();
};
function checkLoginState() {
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            Location.UserEdit;

        } else {
            FB.login();
        }
    });
}

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) {
        return;
    }
    js = d.createElement(s);
    js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

 
function login() {
    FB.login(function (response) {
        if (response.status === "connected") {
            FB.api('/me', {
                'fields': 'id,name,email,picture'
            }, function (response) {
                //console.log(response);
            });
        }
    });
}