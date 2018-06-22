angular.module('MartinsApp').controller('SelecionaUnidade',


    function ($scope, $http, LocalStorageService) {

        

        var vm = this;
        var unidadeSelecionada = null;

        var EMPRESA_KEY = 'EMPRESA_KEY';
        var CONTA_KEY = 'CONTA_KEY';
        var DESC_UNIDADE = 'DESC_UNIDADE';
        var DESC_CONTA = 'DESC_CONTA';
        var selectedUnidade = null;
        var selectedConta = undefined;


        this.$onInit = function () {
            vm.getUnidade();
        }

        vm.getUnidade = function () {
            $http.get(LocalStorageService.getUrlBack() + '/api/Unidade')
                .success(function (ResData) {
                    $scope.selectedUnidade = ResData.Data;
                    $scope.unidades = ResData.Data;
                })
                .catch(function (ResData) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });
        }

        $scope.setaCodigoUnidade = function (unidade) {
            LocalStorageService.COD_UNIDADE = unidade;

            vm.buscaContasUnidade(unidade);
        }


        vm.buscaContasUnidade = function (id) {
            $scope.contas = null;
            debugger;
            $http.get(LocalStorageService.getUrlBack() + '/api/UnidadeConta/' + id + '/0')
                .success(function (ResData) {
                    $scope.contas = ResData.Data;
                    $scope.selectedConta = ResData.Data;
                })
                .catch(function (ResData) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButtonText: 'Ok' });
                });
        }

        $scope.saveOnTheLocalStorage = function (unidade, conta) {

            debugger;
            var auxUnidade = document.getElementById("unidadeSelecionada");
            unidade = unidade[auxUnidade.selectedIndex];

            var auxConta = document.getElementById("contaSelecionada");
            conta = conta[auxConta.selectedIndex];

            window.localStorage.setItem(EMPRESA_KEY, unidade.CodUnidade);
            window.localStorage.setItem(DESC_UNIDADE, unidade.DesUnidade);
            window.localStorage.setItem(CONTA_KEY, conta.ContaModel.CodContaContabil);
            window.localStorage.setItem(DESC_CONTA, conta.ContaModel.DescricaoDaContaContabil);
            window.localStorage.setItem('MENU', 'Inicio');
            $(window.document.location).attr('href', '/home');
        }

        $scope.cancelar = function () {
            var unidade = window.localStorage.getItem('EMPRESA_KEY');
            var conta = window.localStorage.getItem('CONTA_KEY');

            if (unidade == undefined || conta == undefined)
            {
                $(window.document.location).attr('href', '/login/loggout');
            }

            window.localStorage.setItem('MENU', 'Inicio');
            $(window.document.location).attr('href', '/home');
        }

    }
);
