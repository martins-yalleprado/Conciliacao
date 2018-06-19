angular.module("MartinsApp").service("SaldoService", function ($http, AppConstants) {
    this.getSaldo = function (codUn, codCnt, data) {
        //console.log(`${AppConstants.API_ROOT}/api/Saldo?codUnidade=${codUn}&codConta=${codCnt}&dataMov=${data}`);

        return $http.get(`${AppConstants.API_ROOT}/api/Saldo?codUnidade=${codUn}&codConta=${codCnt}&dataMov=${data}`);
    };

    this.putSaldo = function (numSeq, mov) {
        //console.log(`${AppConstants.API_ROOT}/api/Saldo`, mov);

        return $http.put(`${AppConstants.API_ROOT}/api/Saldo`, mov);
    };

    this.postSaldo = function (mov) {
        //console.log(`${AppConstants.API_ROOT}/api/Saldo`, mov);

        return $http.post(`${AppConstants.API_ROOT}/api/Saldo`, mov);
    };

    this.deleteSaldo = function (codUn, codCnt, data) {
        return $http.delete(`${AppConstants.API_ROOT}/api/Saldo/?codUnidade=${codUn}&codConta=${codCnt}&dataMov=${data}`);
    }

});