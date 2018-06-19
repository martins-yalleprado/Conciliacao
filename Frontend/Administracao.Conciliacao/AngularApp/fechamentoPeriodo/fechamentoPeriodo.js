angular.module('MartinsApp').controller('FechamentoPeriodoController', function ($scope, $http, AppConstants, FechamentoPeriodoService, DataService) {

    class FechamentoModel {
        get CodFechamento() { return this._codFechamento; }
        set CodFechamento(value) { this._codFechamento = value; }

        get DataInicioPeriodo() { return this._dataInicioPeriodo; }
        set DataInicioPeriodo(value) { this._dataInicioPeriodo = value; }

        get DataFimPeriodo() { return this._dataFimPeriodo; }
        set DataFimPeriodo(value) { this._dataFimPeriodo = value; }

        get DataInclusao() { return this._dataInclusao; }
        set DataInclusao(value) { this._dataInclusao = value; }

        get TipoFechamento() { return this._tipoFechamento; }
        set TipoFechamento(value) { this._tipoFechamento = value; }

        get Usuario() { return this._usuario; }
        set Usuario(value) { this._usuario = value; }

        get SaldoFechamento() { return this._saldoFechamento; }
        set SaldoFechamento(value) { this._saldoFechamento = value; }

        get StatusFechamento() { return this._statusFechamento; }
        set StatusFechamento(value) { this._statusFechamento = value; }
    };

    $(document).ready(function () {
        $scope._gridSize = 0;
        $scope._dataGrid = [];
        $scope.fechamentoModel = new FechamentoModel();

        $scope.fechamentoModel.CodConta = AppConstants.COD_CONTA === undefined ? 0 : parseInt(AppConstants.COD_CONTA);
        $scope.fechamentoModel.CodUnidade = AppConstants.COD_UNIDADE === undefined ? 0 : parseInt(AppConstants.COD_UNIDADE);
        $scope.fechamentoModel.DescConta = AppConstants.DESC_CONTA;
        $scope.fechamentoModel.DescUnidade = AppConstants.DESC_UNIDADE;

        $scope.getFechamentoPeriodo();
    });

    $scope.getFechamentoPeriodo = function () {

    };

});