angular.module('MartinsApp').controller('PeriodoAging',

  function ($scope, $http, AppConstants) {

    var data = [];
    var dataIntervalo;
    var agingPeriod = [];
    var agingPeriodInterval = [];
    var show_element = false;
    var term;

    $scope.onInit = function () {
      $scope.buscaTodosPeriodos();
    }

    $scope.buscaTodosPeriodos = function () {
      $http.get(AppConstants.API_ROOT + '/api/Periodo')
        .then(function (ResData) {
          $scope.data = ResData.data.Data;
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.getBuscaPeriodos = function () {
      let periodo = $scope.datepicker;
      $http.get(AppConstants.API_ROOT + '/api/Periodo/' + periodo)
        .then(function (ResData) {
          $scope.data = ResData.data.Data;
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.buscaIntervalos = function (idPeriodo) {
      $http.get(AppConstants.API_ROOT + '/api/Intervalo/' + idPeriodo)
        .then(function (ResData) {
          $scope.dataIntervalo = ResData.data.Data;
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.removerPeriodo = function () {
      var obj = {
        "codPeriodo": $scope.agingPeriod.codPeriodo,
        "nome": $scope.agingPeriod.nome,
        "situacao": $scope.agingPeriod.situacao
      };
      $http.put(AppConstants.API_ROOT + '/api/Periodo?acao=' + 'inativar', obj)
        .then(function (ResData) {
          swal(
            'Feito!',
            'O período foi ativado/desativado com sucesso.',
            'success'
          );
          $scope.onInit();
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });


    }

    $scope.atualizaPeriodo = function () {
      var obj = {
        "codPeriodo": $scope.agingPeriod.codPeriodo,
        "nome": $scope.editNameAging
      };
      $http.put(AppConstants.API_ROOT + '/api/Periodo?acao=' + 'alterar', obj)
        .then(function (ResData) {
          swal(
            'Feito!',
            'O período foi atualizado com sucesso.',
            'success'
          );
          $scope.buscaTodosPeriodos();
          $scope.agingPeriod.nome = $scope.editNameAging;
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.salvarNovoPeriodo = function () {
      $http.post(AppConstants.API_ROOT + '/api/Periodo', this.agingPeriod)
        .then(function (ResData) {
          swal(
            'Feito!',
            'Período criado com sucesso.',
            'success'
          );
          $scope.buscaTodosPeriodos();
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.salvarNovoIntervalo = function () {
      $scope.agingPeriodInterval.codPeriodo = $scope.agingPeriod.codPeriodo;
      $http.post(AppConstants.API_ROOT + '/api/Intervalo', $scope.agingPeriodInterval)
        .then(function (ResData) {
          swal(
            'Feito!',
            'Intervalo criado com sucesso.',
            'success'
          );
          $scope.buscaIntervalos($scope.agingPeriod.codPeriodo);
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.atualizaIntervalo = function () {
      var obj = {
        "codIntervalo": $scope.agingPeriodInterval.codIntervalo,
        "inicio": $scope.agingPeriodIntervalIni,
        "fim": $scope.agingPeriodIntervalFim,
        "codPeriodo": $scope.agingPeriod.codPeriodo
      };
      $http.put(AppConstants.API_ROOT + '/api/Intervalo?acao=' + 'alterar', obj)
        .then(function (ResData) {
          swal(
            'Feito!',
            'O intervalo foi atualizado com sucesso.',
            'success'
          );
          $scope.buscaIntervalos($scope.agingPeriod.codPeriodo);
        })
        .catch(function (ResData) {
          if (ResData.data.ErroModel.ErroMensagem !== undefined) {
            swal({ title: 'Erro', text: ResData.data.ErroModel.ErroMensagem, type: 'error', confirmButton: 'Ok' });
          }
          else if (ResData.data.Message !== undefined) {
            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
          } else {
            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
          }
        });
    }

    $scope.setClickedRow = function (index) {
      $scope.agingPeriod = index;
      $scope.buscaIntervalos(index.codPeriodo)
      $scope.show_element = true;
    }

    $scope.setClickedInterval = function (index) {
      $scope.agingPeriodInterval = index;
    }

    $scope.setAtivoPeriodo = function (periodo) {
      if ($scope.ativo) {
        if (periodo.situacaoLabel === "Inativo") {
          return;
        }
      }
      return periodo;
    }

    $scope.setAtivoIntervalo = function (intervalo) {
      if ($scope.ativoIntervalo) {
        if (intervalo.situacao === 0) {
          return;
        }
      }
      return intervalo;
    }


    $scope.onInit();


  }
);
