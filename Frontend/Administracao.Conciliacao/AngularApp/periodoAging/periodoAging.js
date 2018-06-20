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
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });
        }

        $scope.getBuscaPeriodos = function () {
            let periodo = $scope.datepicker + "";
            if ((periodo !== undefined) && (periodo !== "")) {
                $http.get(AppConstants.API_ROOT + '/api/Periodo/' + periodo)
                    .then(function (ResData) {
                        $scope.data = ResData.data.Data;
                    })
                    .catch(function (ResData) {
                        if (ResData.data.Message !== undefined) {
                            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                        } else {
                            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                        }
                    });
            } else {
                $scope.buscaTodosPeriodos();
            }

        }

        $scope.buscaIntervalos = function (idPeriodo) {
            $http.get(AppConstants.API_ROOT + '/api/Intervalo/' + idPeriodo)
                .then(function (ResData) {
                    $scope.dataIntervalo = ResData.data.Data;
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
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
                    swal('Feito!', 'O período foi ativado/desativado com sucesso.', 'success');
                    $scope.onInit();
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });
            $scope.limpaPeriodo();

        }

        $scope.atualizaPeriodo = function () {
            var obj = {
                "codPeriodo": $scope.agingPeriod.codPeriodo,
                "nome": $scope.editNameAging
            };
            $http.put(AppConstants.API_ROOT + '/api/Periodo?acao=' + 'alterar', obj)
                .then(function (ResData) {
                    swal('Feito!', 'O período foi atualizado com sucesso.', 'success');
                    $scope.buscaTodosPeriodos();
                    $scope.agingPeriod.nome = $scope.editNameAging;
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });
            $scope.limpaPeriodo();
        }

        $scope.salvarNovoPeriodo = function () {
            $http.post(AppConstants.API_ROOT + '/api/Periodo', this.agingPeriod)
                .then(function (ResData) {
                    if (ResData.data.ErroModel.Sucesso === true) {
                        swal('Feito!','Período criado com sucesso.','success');
                        $scope.buscaTodosPeriodos();
                    } else if (ResData.Message === "Nome do Período já existente") {
                        swal('Erro!','Período já existente!','error');
                    } else {
                        swal('Erro!', 'Ocorreu um problema ao inserir, verifique o campo "Descrição do Período"', 'error');
                    }
                })
                .catch(function (ResData) {
                    if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });

            $scope.limpaPeriodo();
        }

        $scope.salvarNovoIntervalo = function () {
            
            if ($scope.agingPeriodInterval !== undefined && (!isNaN($scope.agingPeriodInterval.inicio) && !isNaN($scope.agingPeriodInterval.fim))) {
                $scope.agingPeriodInterval.codPeriodo = $scope.agingPeriod.codPeriodo;

                $http.post(AppConstants.API_ROOT + '/api/Intervalo', $scope.agingPeriodInterval)
                    .then(function (ResData) {
                        swal('Feito!', 'Intervalo criado com sucesso.', 'success');
                        $scope.buscaIntervalos($scope.agingPeriod.codPeriodo);
                       
                    })
                    .catch(function (ResData) {
                        if (ResData.data.Message !== undefined) {
                            swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                        } else {
                            swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                        }
                    });

            } else {
                swal('Erro!', 'Os campos "De" e "Ate" são obrigatórios e devem ser números.', 'error');
            }

            $scope.limpaIntervalo();
        }

        $scope.atualizaIntervalo = function (acao) {

            var obj = {
                "codIntervalo": $scope.agingPeriodInterval.codIntervalo,
                "inicio": $scope.agingPeriodIntervalIni,
                "fim": $scope.agingPeriodIntervalFim,
                "codPeriodo": $scope.agingPeriod.codPeriodo,
                "situacao": $scope.agingPeriodInterval.situacao
            };

            $http.put(AppConstants.API_ROOT + '/api/Intervalo?acao=' + acao, obj)
                .then(function (ResData) {
                    swal('Feito!', 'O intervalo foi atualizado com sucesso.', 'success');
                    $scope.buscaIntervalos($scope.agingPeriod.codPeriodo);
                })
                .catch(function (ResData) {
                     if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });

            $scope.limpaIntervalo();
        }

        $scope.setClickedRow = function (index) {
            $scope.agingPeriod = index;
            $scope.buscaIntervalos(index.codPeriodo)
            $scope.show_element = true;
        }

        $scope.setClickedInterval = function (index) {
            $scope.agingPeriodInterval = index;
            $scope.agingPeriodIntervalIni = $scope.agingPeriodInterval.inicio;
            $scope.agingPeriodIntervalFim = $scope.agingPeriodInterval.fim;
        }

        $scope.setAtivoPeriodo = function (periodo) {
            if ($scope.ativo) {
                if (periodo.situacaoLabel === "Inativo") {
                    return; //==>
                }
            }

            return periodo;
        }

        $scope.setAtivoIntervalo = function (intervalo) {
            if ($scope.ativoIntervalo) {
                if (intervalo.situacao === 0) {
                    return; //==>
                }
            }

            return intervalo;
        }

        $scope.limpaPeriodo = function () {
            $scope.agingPeriod = undefined;
        }
        $scope.limpaIntervalo = function () {
            $scope.agingPeriodInterval = undefined;
        }

        $scope.onInit();
    }
);
