angular.module('MartinsApp').controller('TiposMovimentacoes',


  function ($scope, $http, AppConstants) {
    var contabil = [];
    var conciliacoes = [];
    var conciliacao = {};

    $scope.searchContabil = {};
    $scope.filterContabil = {};

    $scope.searchConciliacao = {};
    $scope.filterConciliacao = {};

    $scope.getMovimentoContabil = function () {
      $http.get(AppConstants.API_ROOT + '/api/MovimentoContabil')
        .then(function (ResData) {
          $scope.contabil = ResData.data.Data;
        }).catch(function (data) {
          swal({ title: 'Erro', text: data.error, type: 'error', confirmButtonText: 'Ok' });
        });
    }

    $scope.getMovimentoConciliacao = function (codIdentidadeContabil) {
      $http.get(AppConstants.API_ROOT + '/api/MovimentoConciliacao/' + codIdentidadeContabil)
        .then(function (ResData) {
          $scope.conciliacoes = ResData.data.Data;
        }).catch(function (data) {
          this.conciliacoes = null;
          swal({ title: 'Erro', text: objeto.error, type: 'error', confirmButtonText: 'Ok' });
        });
    }

    $scope.preencherConciliacao = function (ResData) {
      $scope.conciliacao = ResData;
    }

    $scope.aplicaFiltroContabil = function () {
      for (prop in $scope.searchContabil) {
        $scope.filterContabil[prop] = $scope.searchContabil[prop];
      }
    };

    $scope.aplicaFiltroConciliacao = function () {
      for (prop in $scope.searchConciliacao) {
        $scope.filterConciliacao[prop] = $scope.searchConciliacao[prop];
      }
    };

    var tm = this;

    

    $scope.getMovimentoContabil();
   
    

  }
);
