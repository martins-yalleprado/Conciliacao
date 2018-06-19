angular.module('MartinsApp').controller('HeaderController',

    function ($scope, $http, LocalStorageService) {
          $scope.codUnidade = LocalStorageService.getCodUnidade();
          $scope.codConta = LocalStorageService.getCodConta();
          $scope.descUnidade = LocalStorageService.getDescricaoUnidade();
          $scope.descConta = LocalStorageService.getDescricaoConta();
          $scope.menu = LocalStorageService.getMenu();
          $scope.usuario = LocalStorageService.getUsuario(); 

          $scope.logout = function () {

              window.localStorage.removeItem('EMPRESA_KEY');
              window.localStorage.removeItem('DESC_UNIDADE');
              window.localStorage.removeItem('CONTA_KEY');
              window.localStorage.removeItem('DESC_CONTA');
              window.localStorage.removeItem('jwt_token');
              window.localStorage.removeItem('user');

              window.location.assign("/ADMINISTRACAO.CONCILIACAO/Login");
          }


          $scope.trocarUnidade = function () {
              window.location.assign("/ADMINISTRACAO.CONCILIACAO/SelecionaUnidade");
          }

          $scope.atualizaMenu = function (valor) {
              window.localStorage.setItem('MENU', valor);
          }
    }
);