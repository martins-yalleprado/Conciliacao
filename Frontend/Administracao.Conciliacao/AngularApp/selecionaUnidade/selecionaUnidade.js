angular.module('MartinsApp').controller('SelecionaUnidade',


    function ($scope, $http, AppConstants) {


        var vm = this;
        var unidadeSelecionada = null;

        var EMPRESA_KEY = 'empresaKey';
        var CONTA_KEY = 'contaKey';

        var selectedUnidade = null;
        var selectedConta = null;


        this.$onInit = function () {
            vm.getUnidade();
        }

        vm.getUnidade = function () {
            $http.get(AppConstants.API_ROOT + '/api/Unidade')
                .then(function (ResData) {
                    $scope.selectedUnidade = ResData.data.Data;
                    $scope.unidades = ResData.data.Data;
                })
                .catch(function (ResData) {
                    swal({ title: 'Erro', text: ResData.error, type: 'error', confirmButtonText: 'Ok' });
                });
        }

        $scope.setaCodigoUnidade = function (unidade) {
            vm.buscaContasUnidade(unidade);
        }


        vm.buscaContasUnidade = function (id) {
            $scope.contas = null;
            debugger;
            $http.get(AppConstants.API_ROOT + '/api/UnidadeConta/' + id + '/0')
                .then(function (ResData) {
                    $scope.selectedConta = ResData.data.Data;
                    $scope.contas = ResData.data.Data;
                })
                .catch(function (ResData) {
                    swal({ title: 'Erro', text: ResData.error, type: 'error', confirmButtonText: 'Ok' });
                });
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

        $scope.logout = function () {
            window.localStorage.removeItem('jwt_token');
            window.localStorage.removeItem('user');
            $(window.document.location).attr('href', '/login');
        }

    }
);
