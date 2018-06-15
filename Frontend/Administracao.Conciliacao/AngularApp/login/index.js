

angular.module(app).controller('Login',


  function ($scope, $http, AppConstants, $location, $window) {


    var user = [];
    var resultok = false;
    $scope.login = function (user) {
      if (user == undefined || !user.username || !user.password) {
        swal({ title: 'Atenção!', text: 'Login ou senha inválidos', type: 'error', confirmButtonText: 'Ok' });

      } else {
        user = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';
        $http.post(AppConstants.API_ROOT + '/oauth2/token', user)
          .then(function (data) {
            $scope.setToken(data['data']['access_token']);
            $window.location.assign("/home");
          })
          .catch(function (data) {
            swal({ title: 'Atenção!', text: 'Erro ao tentar autenticar:' + data.error, type: 'error', confirmButtonText: 'Ok' });
          });

      }
    }

    $scope.setToken = function (token) {

      const usuarioObj = {
        firstName: 'Usuario teste',
        menu: '',
        quantidade_avisos: '4'
      };

      window.localStorage.setItem('jwt_token', token);
      window.localStorage.setItem('user', JSON.stringify(usuarioObj));
    };
  }
);
