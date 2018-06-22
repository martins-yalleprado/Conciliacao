angular.module('MartinsApp').controller('FechamentoPeriodoController', function ($scope, $http, LocalStorageService, FechamentoPeriodoService, DataService) {

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

        $scope.fechamentoModel.CodConta = LocalStorageService.COD_CONTA === undefined ? 0 : parseInt(LocalStorageService.COD_CONTA);
        $scope.fechamentoModel.CodUnidade = LocalStorageService.COD_UNIDADE === undefined ? 0 : parseInt(LocalStorageService.COD_UNIDADE);
        $scope.fechamentoModel.DescConta = LocalStorageService.DESC_CONTA;
        $scope.fechamentoModel.DescUnidade = LocalStorageService.DESC_UNIDADE;
        $scope.fechamentoModel.TipoFechamento = 'M'
        $scope.FechamentoPadrao = 1;


        //$scope.getFechamentoPeriodo();
    });

    $scope.calcularData = function () {
        var dataInicioAtual = formataData($scope.fechamentoModel.DataInicioPeriodo);

        if (dataInicioAtual === null)
            return;

        var dataFimAtual = new Date(dataInicioAtual.getFullYear(), dataInicioAtual.getMonth() + 1, 0);

        // define data final vigente
        if ($scope.fechamentoModel.DataFimPeriodo === undefined || $scope.fechamentoModel.DataFimPeriodo === "")
            $scope.fechamentoModel.DataFimPeriodo = dataFimAtual;
        else {
            console.log("campo");
            console.log($scope.fechamentoModel.DataFimPeriodo);

            var dataFimPsq = formataData($scope.fechamentoModel.DataFimPeriodo);

            console.log(dataFimPsq);

            var dataFimAtualTmp = null;

            if (dataFimPsq !== null)
                dataFimAtualTmp = dataFimPsq; // new Date(dataFimPsq);

            // validando período
            if (dataFimPsq !== null && dataFimAtualTmp !== null && dataInicioAtual < dataFimAtualTmp)
                dataFimAtual = dataFimAtualTmp;
            else {
                $scope.fechamentoModel.DataFimPeriodo = dataFimAtual;
                return;
            }
        }

        //
        var custom = $scope.FechamentoPadrao;
        var tipo = $scope.fechamentoModel.TipoFechamento === undefined ? 'M' : $scope.fechamentoModel.TipoFechamento;

        if (tipo === 'M') {
            var dataInicioPrev = new Date(dataFimAtual.getFullYear(), dataFimAtual.getMonth() + 1);

            // validação dia do mês seguinte
            var diaCalculado = new Date(dataFimAtual.getFullYear(), dataFimAtual.getMonth() + 2, 0).getDate();
            var diaSelecionado = custom; // dataInicioAtual.getDate() + 1;

            var dia = diaSelecionado > diaCalculado ? diaCalculado : diaSelecionado;

            // define a data de previsão
            dataInicioPrev.setDate(dia);

            //
            $scope.DataInicioPeriodoPrev = dataInicioPrev.toLocaleDateString();
            $scope.DataFimPeriodoPrev = (new Date(dataInicioPrev.getFullYear(), dataInicioPrev.getMonth() + 1, 0)).toLocaleDateString();

        } else {
            var dataInicioPrev = new Date(dataFimAtual.getFullYear() + 1, dataFimAtual.getMonth(), custom);

            $scope.DataInicioPeriodoPrev = (dataInicioPrev).toLocaleDateString();
            $scope.DataFimPeriodoPrev = (new Date(dataInicioPrev.getFullYear() + 1, dataInicioPrev.getMonth() + 1, 0)).toLocaleDateString();
        }

        return true;
    };

    var formataData = function (dataref) {
        var data = dataref;

        if (data === undefined || data === "")
            return null

        if (typeof dataref === 'string') {
            if (dataref.search("-") == -1) {
                var parts = dataref.split("/");
                var day = parts[0];
                var month = parts[1];
                var year = parts[2];

                data = new Date(year, month - 1, day);

            }
        }
        else {
            data = new Date(dataref.getFullYear(), dataref.getMonth() - 1, dataref.getDate()); //data = new Date("2018-06-05T03:00:00.000Z");
        }

        return data; //.format("yyyy-mm-dd");
    };

    //var formataData = function (dataref) {        
    //    var data = null; // = dataref;

    //    if (dataref === undefined || dataref === "")
    //        return null

    //    if (typeof dataref === 'string') {
    //        var parts;

    //        console.log("é string");

    //        if (dataref.search("-") == -1)
    //            parts = dataref.split("/");
    //        else {
    //            console.log("to iso string");
    //            console.log(dataref.toISOString());
    //            parts = dataref.split("-");
    //        }

    //        var day = parts[0];
    //        var month = parts[1];
    //        var year = parts[2];

    //        data = new Date(year, month - 1, day);
    //    }        

    //    return data;
    //};

    $scope.getFechamentoPeriodo = function () {
        var tipo = $scope.fechamentoModel.TipoFechamento;

        FechamentoPeriodoService.getFechamentoPeriodo(tipo, 0)
            .then(function (ResData) {

                $scope._dataGrid = ResData.data.Data;
                $scope._gridSize = $scope._dataGrid == null ? 0 : $scope._dataGrid.length;

                if ($scope._gridSize == 0)
                    swal(
                        'Alerta!',
                        'Não foi encontrado fechamento na data informada',
                        'warning'
                    );

            }).catch(function (data) {
                if (ResData.data.Message !== undefined) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                } else {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                }
            });
    }

});