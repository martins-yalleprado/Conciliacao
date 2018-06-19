angular.module('MartinsApp').controller('TiposMovimentacoes',


  function ($scope, $http, AppConstants) {
    var contabil = [];
    var conciliacoes = [];
    var conciliacao = {};
    $scope.atualizar = false;
    $scope.buttonText = "Salvar";
    $scope.active = false;
      


    $scope.searchContabil = {};
    $scope.filterContabil = {};

    $scope.searchConciliacao = {};
    $scope.filterConciliacao = {};

    $scope.getMovimentoContabil = function () {
      $http.get(AppConstants.API_ROOT + '/api/MovimentoContabil')
        .then(function (ResData) {
          $scope.contabil = ResData.data.Data;
        })
        .catch(function (ResData) {
          if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.getMovimentoConciliacao = function (codIdentidadeContabil) {
      $http.get(AppConstants.API_ROOT + '/api/MovimentoConciliacao/' + codIdentidadeContabil)
        .then(function (ResData) {
          $scope.conciliacoes = ResData.data.Data;
        })
        .catch(function (ResData) {
          if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
      }

      $scope.salvaAtualizaConciliacao = function () {
          if ($scope.atualizar) {
            $http.put(AppConstants.API_ROOT + '/api/MovimentoConciliacao', $scope.conciliacao)
              .then(function (ResData) {
                  swal('Feito!', 'Conciliacao foi atualizada com sucesso.', 'success');
                  $scope.getMovimentoConciliacao($scope.conciliacao.CodIdentidadeContabil);
              })
              .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                  } else {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                  }
              });
          } else {
              $scope.conciliacao.MarcacaoRegistroMovimentoConciliacao = 1;
              $http.post(AppConstants.API_ROOT + '/api/MovimentoConciliacao', $scope.conciliacao)      
              .then(function (ResData) {
                  swal('Feito!', 'Conciliacao foi criada com sucesso.', 'success');
                  $scope.getMovimentoConciliacao($scope.conciliacao.CodIdentidadeContabil);
              })
              .catch(function (ResData) {
                  if (ResData.data.Message !== undefined) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                  } else {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                  }
              });
          }

          
          
          
      }

      $scope.limparNovo = function () {
          $scope.conciliacao = {};
          $scope.atualizar = false;
          $scope.buttonText = "Salvar";
      }

    $scope.preencherConciliacao = function (ResData) {
        $scope.conciliacao = ResData;
        $scope.atualizar = true;
        $scope.buttonText = "Atualizar";
        $scope.mostra = 'block';
        $scope.active = true;
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
