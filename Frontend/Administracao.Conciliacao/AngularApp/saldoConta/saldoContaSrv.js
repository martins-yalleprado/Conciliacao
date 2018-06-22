angular.module("MartinsApp").service("SaldoService", function ($http, LocalStorageService) {
    this.getSaldo = function (data) {
        return $http.get(`${LocalStorageService.getUrlBack()}/api/Saldo/${data}`);
    };

    this.putSaldo = function (mov) {
        return $http.put(`${LocalStorageService.getUrlBack()}/api/Saldo`, mov);
    };

    this.postSaldo = function (mov) {
        return $http.post(`${LocalStorageService.getUrlBack()}/api/Saldo`, mov);
    };

    this.deleteSaldo = function (data) {
        return $http.delete(`${LocalStorageService.getUrlBack()}/api/Saldo/${data}`);
    }

});