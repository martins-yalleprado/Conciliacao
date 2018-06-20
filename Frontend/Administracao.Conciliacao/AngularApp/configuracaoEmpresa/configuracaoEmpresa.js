angular.module('MartinsApp').controller('ConfiguracaoEmpresa',


    function ($scope, $http, AppConstants, $timeout) {


        var vm = this;
        var unidadeSelecionada = null;

        var EMPRESA_KEY = 'empresaKey';
        var CONTA_KEY = 'contaKey';

        var unidadeContas = null;

        var selectedUnidade = null;
        var selectedConta = null;

        var codConta = 0;
        var codUnidade = 0;

        var retorno = 0;

        this.$onInit = function () {
            debugger;
            vm.getUnidade();
            vm.getContas();
        }

        vm.getContas = function () {
            debugger;
            $http.get(AppConstants.API_ROOT + '/api/Conta')
                .then(function (ResData) {
                    debugger;
                    $scope.selectedConta = ResData.data.Data;
                    $scope.contas = ResData.data.Data;
                })
                .catch(function (ResData) {
                    debugger;
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });
        }

        vm.getUnidade = function () {
            debugger;
            $http.get(AppConstants.API_ROOT + '/api/Unidade')
                .then(function (ResData) {
                    debugger;
                    $scope.selectedUnidade = ResData.data.Data;
                    $scope.unidades = ResData.data.Data;
                })
                .catch(function (ResData) {
                    debugger;
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });
        }

        $scope.pesquisar = function (unidade, conta) {
            debugger;

            var auxUnidade = document.getElementById("unidadeSelecionada");
            if (auxUnidade.selectedIndex !== 0) {
                unidade = unidade[auxUnidade.selectedIndex - 1];
            }
            else {
                unidade = undefined;
            }


            var auxConta = document.getElementById("contaSelecionada");
            if (auxConta.selectedIndex !== 0) {
                conta = conta[auxConta.selectedIndex - 1];
            }
            else {
                conta = undefined;
            }


            if (unidade === undefined && conta === undefined) {
                swal({ title: 'Erro', text: 'Ao menos uma unidade de negócio ou conta deve ser selecionada', type: 'error', confirmButtonText: 'Ok' });
            }
            else {
                debugger;
                vm.buscaContasUnidade(unidade, conta);
            }
        }


        $scope.salvar = function (unidade, conta) {
            debugger;

            var auxUnidade = document.getElementById("unidadeSelecionada");
            unidade = unidade[auxUnidade.selectedIndex - 1];

            var auxConta = document.getElementById("contaSelecionada");
            conta = conta[auxConta.selectedIndex - 1];

            debugger;
            if (unidade === undefined) {
                swal({ title: 'Erro', text: 'Unidade de Negócio deve ser selecionada', type: 'error', confirmButtonText: 'Ok' });
            }
            else if (conta === undefined) {
                swal({ title: 'Erro', text: 'A conta deve ser selecionada', type: 'error', confirmButtonText: 'Ok' });
            }
            else {
                debugger;
                vm.relacionaUnidadeConta(unidade, conta);
            }
        }

        vm.relacionaUnidadeConta = function (unidade, conta) {
            debugger;

            $http.get(AppConstants.API_ROOT + '/api/UnidadeConta/' + unidade.CodUnidade + '/' + conta.CodContaContabil)
                .then(function (ResData) {
                    debugger;
                    retorno = ResData.data.Data.length;
                    if (retorno !== 0) {
                        debugger;
                        swal({ title: 'Atenção', text: 'A Unidade de Negócio já está relacionada a Conta', type: 'warning', confirmButtonText: 'Ok' });
                    }
                    else if (retorno == 0) {
                        debugger;
                        const data = {
                            CodEmpresa: unidade.CodEmpresa,
                            ContaModel: conta,
                            Flag: 1,
                            FlagLabel: "Ativo",
                            UnidadeModel: unidade
                        };


                        $http.post(AppConstants.API_ROOT + '/api/UnidadeConta', data)
                            .then(function (ResData) {
                                debugger;
                                $scope.UnidadesContas = ResData.data.Data;
                                swal(
                                    'Feito!',
                                    'A associação foi realizada com sucesso.',
                                    'success'
                                );
                                vm.buscaContasUnidade(unidade, conta);
                            })
                            .catch(function (ResData) {
                                debugger;
                                swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                            });
                    }

                })
                .catch(function (ResData) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });


        }

        vm.buscaContasUnidade = function (unidade, conta) {
            debugger;

            if (conta === undefined) {
                codConta = 0;
            }
            else {
                codConta = conta.CodContaContabil;
            }
            if (unidade === undefined) {
                codUnidade = 0;
            }
            else {
                codUnidade = unidade.CodUnidade;
            }

            $http.get(AppConstants.API_ROOT + '/api/UnidadeConta/' + codUnidade + '/' + codConta)
                .then(function (ResData) {
                    debugger;
                    $scope.UnidadesContas = ResData.data.Data;
                    if (ResData.data.Data.length == 0) {
                        swal({ title: 'Atenção', text: "Não existe associação entre essa Unidade de Negócio e essa Conta", type: 'warning', confirmButtonText: 'Ok' });
                    }
                    retorno = ResData.data.Data.length;
                })
                .catch(function (ResData) {
                    debugger;
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });
            return retorno;
        }

        $scope.saveOnTheLocalStorage = function (unidade, conta) {

            debugger;
            var auxUnidade = document.getElementById("unidadeSelecionada");
            unidade = unidade[auxUnidade.selectedIndex];

            var auxConta = document.getElementById("contaSelecionada");
            conta = conta[auxConta.selectedIndex];

            window.localStorage.setItem(EMPRESA_KEY, JSON.stringify(unidade));
            window.localStorage.setItem(CONTA_KEY, JSON.stringify(conta));
        }


        $scope.ativarDesativarContaUniadde = function (unidadeConta) {
            debugger;
            swal({
                title: 'Atenção',
                text: 'Deseja desativar a relação Unidade - Conta?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancelar',
                confirmButtonText: 'Sim'
            }).then((result) => {
                if (result.value) {
                    debugger;
                    $http.put(AppConstants.API_ROOT + '/api/UnidadeConta/' + unidadeConta.CodEmpresa + '/' + unidadeConta.ContaModel.CodContaContabil + '/' + unidadeConta.UnidadeModel.CodUnidade)
                        .then(function (resultado) {
                            debugger;
                            this.data = resultado.data.Data;
                            swal(
                                'Feito!',
                                'A relação foi desativada.',
                                'success'
                            );
                            debugger;
                            vm.buscaContasUnidade(unidadeConta.UnidadeModel, unidadeConta.ContaModel);

                        })
                        .catch(function (resultado) {
                            debugger;
                            if (resultado.data.Message !== null) {
                                swal({ title: 'Erro', text: resultado.data.Message, type: 'error', confirmButton: 'Ok' });
                            }
                            else {
                                swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButtonText: 'Ok' });
                            }
                        });
                }
            });
        }
    }
);
