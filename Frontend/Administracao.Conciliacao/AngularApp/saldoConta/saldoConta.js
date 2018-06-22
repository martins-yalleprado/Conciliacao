﻿angular.module('MartinsApp').controller('SaldoController', function ($scope, $http, LocalStorageService, SaldoService, DataService) {

    class SaldoModel {
        get CodConta() { return this._codConta; }
        set CodConta(value) { this._codConta = value; }

        get CodUnidade() { return this._codUnidade; }
        set CodUnidade(value) { this._codUnidade = value; }

        get DescConta() { return this._descConta; }
        set DescConta(value) { this._descConta = value; }

        get DescUnidade() { return this._descUnidade; }
        set DescUnidade(value) { this._descUnidade = value; }

        get DataMovimentacao() { return this._dataMovimentacao; }
        set DataMovimentacao(value) { this._dataMovimentacao = value; }

        get VlrSaldoContabil() { return this._vlrSaldoContabil; }
        set VlrSaldoContabil(value) { this._vlrSaldoContabil = value; }

        get VlrSaldoCobranca() { return this._vlrSaldoCobranca; }
        set VlrSaldoCobranca(value) { this._vlrSaldoCobranca = value; }

        get VlrSaldoContabilInf() { return this._vlrSaldoContabilInf; }
        set VlrSaldoContabilInf(value) { this._vlrSaldoContabilInf = value; }

        get VlrSaldoCobrancaInf() { return this._vlrSaldoCobrancaInf; }
        set VlrSaldoCobrancaInf(value) { this._vlrSaldoCobrancaInf = value; }
    }

    var ModoOperacao = {
        "novo": 1,
        "edicao": 2
    };

    var btnSalvar;
    var btnExcluir;

    var saldoInsert;

    $scope.reset = function () {
        $scope.saldoModel.DataMovimentacao = undefined;
        $scope.saldoModel.VlrSaldoCobranca = undefined;
        $scope.saldoModel.VlrSaldoContabil = undefined;

        controledisponibilidade(ModoOperacao.novo);
    };

    $(document).ready(function () {
        $scope._gridSize = 0;
        $scope._dataGrid = [];
        $scope.saldoModel = new SaldoModel();

        btnSalvar = document.getElementById('btnSalvar');
        btnExcluir = document.getElementById('btnExcluir');

        controledisponibilidade(ModoOperacao.novo);

        $scope.saldoModel.DataMovimentacao = new Date();
        $scope.saldoModel.CodConta = LocalStorageService.COD_CONTA === undefined ? 0 : parseInt(LocalStorageService.COD_CONTA);
        $scope.saldoModel.CodUnidade = LocalStorageService.COD_UNIDADE === undefined ? 0 : parseInt(LocalStorageService.COD_UNIDADE);
        $scope.DescConta = LocalStorageService.DESC_CONTA;
        $scope.DescUnidade = LocalStorageService.DESC_UNIDADE;

        $scope.getSaldo();
    });

    $scope.getSaldo = function () {
        var dataPsq = formataData($scope.saldoModel.DataMovimentacao);

        if (dataPsq === null)
            return

        SaldoService.getSaldo(dataPsq)
            .then(function (ResData) {

                $scope._dataGrid = [];

                if (ResData.data === null) {
                    swal(
                        'Alerta!',
                        'Sem resposta. Tente novamente!',
                        'warning'
                    );
                } else if (!ResData.data.ErroModel.Sucesso) {
                    swal(
                        'Alerta!',
                        'Não foi possível buscar a informação neste momento, tente novamente',
                        'warning'
                    );
                } else {
                    $scope._dataGrid = ResData.data.Data;
                }

                $scope._gridSize = $scope._dataGrid == null ? 0 : $scope._dataGrid.length;

                if ($scope._gridSize == 0)
                    swal(
                        'Alerta!',
                        'Não foi encontrado saldo na data informada',
                        'warning'
                    );

            }).catch(function (data) {
                if (ResData.data === null || ResData.data === undefined) {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                } else if (ResData.data.Message !== undefined) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                } else {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                }
            });
    }

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

            } else {
                data = new Date(dataref); //data = new Date("2018-06-05T03:00:00.000Z");
            }
        }

        return data.format("yyyy-mm-dd");
    };

    $scope.salvar = function (form) {
        var contabil = form.VlrSaldoContabil.$viewValue === undefined || form.VlrSaldoContabil.$viewValue === "";
        var cobranca = form.VlrSaldoCobranca.$viewValue === undefined || form.VlrSaldoCobranca.$viewValue === "";

        if (contabil && cobranca) {
            swal(
                'Alerta!',
                'Deve preencher o campo Saldo Contábil ou Saldo Cobrança para continuar!',
                'warning'
            );

            return;
        }

        if (btnSalvar.value == "Inserir") {

            var saldo = angular.copy($scope.saldoModel);
            saldo.CodConta = 0;
            saldo.CodUnidade = 0;
            saldo.VlrSaldoCobrancaInf = 0;
            saldo.VlrSaldoContabilInf = 0;

            SaldoService.postSaldo(saldo)
                .then(function (ResData) {

                    if (ResData.data === null) {
                        swal(
                            'Alerta!',
                            'Sem resposta. Tente novamente!',
                            'warning'
                        );
                    }
                    else if (!ResData.data.ErroModel.Sucesso) {
                        swal(
                            'Alerta!',
                            'Já existe lançamento para a data informada. Exclua o registro anterior e tente novamente!',
                            'warning'
                        );
                    }
                    else {
                        // bind grid
                        $scope.getSaldo();

                        swal(
                            'Feito!',
                            'Registro incluído com sucesso.',
                            'success'
                        );
                    }

                }).catch(function (ResData) {
                    if (ResData.data === null || ResData.data === undefined) {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    } else if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });

        } else if (btnSalvar.value == "Alterar") {

            SaldoService.putSaldo($scope.saldoModel)
                .then(function (ResData) {
                    if (ResData.Message === null) {
                        swal(
                            'Alerta!',
                            'Sem resposta. Tente novamente!',
                            'warning'
                        );
                    } else {
                        // bind grid
                        $scope.getSaldo();

                        swal(
                            'Feito!',
                            'Registro alterado com sucesso.',
                            'success'
                        );
                    }

                }).catch(function (ResData) {
                    if (ResData.data === null || ResData.data === undefined) {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    } else if (ResData.data.Message !== undefined) {
                        swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                    } else {
                        swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                    }
                });

        } else {
            swal({ title: 'Erro', text: 'Operação não permitida', type: 'error', confirmButton: 'Ok' });
        }
    }

    $scope.excluir = function (form) {

        var data = $scope.saldoModel.DataMovimentacao.replace(/\:/g, ";");

        SaldoService.deleteSaldo(data)
            .then(function (ResData) {
                if (ResData.Message === null) {
                    swal(
                        'Alerta!',
                        'Sem resposta. Tente novamente!',
                        'warning'
                    );
                } else {
                    // bind grid
                    $scope.getSaldo();

                    swal(
                        'Feito!',
                        'Registro removido com sucesso.',
                        'success'
                    );
                }

            }).catch(function (ResData) {
                if (ResData.data === null || ResData.data === undefined) {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                } else if (ResData.data.Message !== undefined) {
                    swal({ title: 'Erro', text: ResData.data.Message, type: 'error', confirmButton: 'Ok' });
                } else {
                    swal({ title: 'Erro', text: 'Server Error', type: 'error', confirmButton: 'Ok' });
                }
            });
    }

    $scope.editForm = function (row) {
        $scope.saldoModel = angular.copy(row); // JSON.parse(JSON.stringify(mov)); // copy object

        controledisponibilidade(ModoOperacao.edicao);
    }

    var controledisponibilidade = function (modo) {
        switch (modo) {
            case 1: {
                btnSalvar.value = "Inserir";
                btnExcluir.disabled = true;
                break;
            }
            case 2: {
                btnSalvar.value = "Alterar";
                btnExcluir.disabled = false;
                break;
            }
            default: {
                btnSalvar.disabled = true;
                btnExcluir.disabled = true;
                break;
            }
        }
    }

});