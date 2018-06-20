angular.module("MartinsApp").controller('Login',

  function ($scope, $http, AppConstants, $location, $window) {
      var user = [];
      var userString = "";
    var resultok = false;

    $scope.login = function (user) {
      if (user === undefined || !user.username || !user.password) {
        swal({ title: 'Atenção!', text: 'Login ou senha inválidos', type: 'error', confirmButtonText: 'Ok' });
      } else {
          userString = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';
          $http.post(AppConstants.API_ROOT + '/oauth2/token', userString)
          .then(function (data) {
            $scope.setToken(data['data']['access_token']);
           
            $http.get(AppConstants.API_FRONT + '/Login?user=' + user.username)
                .then(function (data) {
                    $window.location.assign("/ADMINISTRACAO.CONCILIACAO/SelecionaUnidade");
                });

          })
          .catch(function (data) {
            swal({ title: 'Atenção!', text: 'Erro ao tentar autenticar:' + data.Message, type: 'error', confirmButtonText: 'Ok' });
          });

      }
    }

    $scope.setToken = function (token) {

      const usuarioObj = {
        firstName: 'Usuario teste',
        menu: '',
        quantidade_avisos: '4'
      };
      window.localStorage.removeItem('MENU');
      window.localStorage.setItem('jwt_token', token);
      window.localStorage.setItem('user', JSON.stringify(usuarioObj));
    };
  }
);
