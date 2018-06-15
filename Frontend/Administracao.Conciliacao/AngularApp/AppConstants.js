angular.module("MartinsApp").value("AppConstants", {
    //API_ROOT: "http://192.168.0.240:1741",
    API_ROOT: "http://localhost:56834",
    TOKEN:  window.localStorage.getItem('jwt_token')
});


