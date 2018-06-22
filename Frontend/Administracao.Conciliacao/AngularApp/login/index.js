angular.module("MartinsApp").controller('Login',

  function ($scope, $http, $location, $window) {
      var user = [];
      var userString = "";
    var resultok = false;

    $scope.login = function (user) {
      if (user === undefined || !user.username || !user.password) {
        swal({ title: 'Atenção!', text: 'Login ou senha inválidos', type: 'error', confirmButtonText: 'Ok' });
      } else {
          userString = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';
          $http.post('http://localhost:1741/oauth2/token', userString)
          .then(function (data) {
            $scope.setToken(data['data']['access_token']);
           
              $http.get($location.$$absUrl + '?user=' + user.username)
                .then(function (data) {
                    var baseUrl = new $window.URL($location.absUrl()).origin;
                    $http.get(baseUrl + '/Home/UrlBack')
                        .success(function (data) {
                            var teste = data;

                            window.localStorage.setItem('URL_BACK', data);
                        });

                    $http.get(baseUrl + '/Home/UrlFront')
                        .success(function (data) {
                            var teste = data;

                            window.localStorage.setItem('URL_FRONT', data);
                        });

                    $window.location.assign("/SelecionaUnidade");
                });

          })
              .catch(function (data) {
                  if (data.Error !== undefined) {
                      swal({ title: 'Erro', text: 'Erro ao tentar autenticar:' + data.Error, type: 'error', confirmButtonText: 'Ok' });
                  }
                  else if (data.Message !== undefined) {
                      swal({ title: 'Atenção!', text: 'Erro ao tentar autenticar:' + data.Message, type: 'error', confirmButtonText: 'Ok' });
                  } 
                  else {
                      swal({ title: 'Erro', text: 'Erro no servidor de autenticação. Tente novamente', type: 'error', confirmButtonText: 'Ok' });
                  }
          });

      }
    }

    $scope.setToken = function (token) {

      const usuarioObj = {
        firstName: 'PKYR0004',
        menu: '',
        quantidade_avisos: '4'
      };
      window.localStorage.removeItem('MENU');
      window.localStorage.setItem('jwt_token', token);
      window.localStorage.setItem('user', JSON.stringify(usuarioObj));
    };
  }
);
