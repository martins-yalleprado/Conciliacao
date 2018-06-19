angular.module("MartinsApp").service("authService", function ($http, AppConstants) {

    var TOKEN_NAME = 'jwt_token';

    this.login = function (user) {
        return $http.post(AppConstants.API_ROOT + '/oauth2/token', user);
    };

    this.setToken = function (token) {

        const usuarioObj = {
            firstName: 'Usuario teste',
            menu: '',
            quantidade_avisos: '4'
        };

        window.localStorage.setItem('jwt_token', token);
        window.localStorage.setItem('user', JSON.stringify(usuarioObj));
    };
});