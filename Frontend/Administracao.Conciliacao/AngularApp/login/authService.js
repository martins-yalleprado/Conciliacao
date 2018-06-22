angular.module("MartinsApp").service("authService", function ($http, $location) {

    var TOKEN_NAME = 'jwt_token';

    this.login = function (user) {
        return $http.post(LocalStorageService.getUrlBack() + '/oauth2/token', user);
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