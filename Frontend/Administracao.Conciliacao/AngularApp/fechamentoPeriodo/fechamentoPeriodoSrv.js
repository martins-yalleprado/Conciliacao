angular.module("MartinsApp").service("FechamentoPeriodoService", function ($http, AppConstants) {
    this.getFechamentoPeriodo = function (tipo, codFechamento, codUnidade, codConta) {
        return $http.get(`${AppConstants.API_ROOT}/api/Fechamento?tipo=${tipo}&codFechamento=${codFechamento}&codUnidade=${codUnidade}&codConta=${codConta}`);
    };

    this.postFechamentoPeriodo = function (obj) {
        return $http.post(`${AppConstants.API_ROOT}/api/Fechamento`, obj);
    };

    this.deleteFechamentoPeriodo = function (id) {
        return $http.delete(`${AppConstants.API_ROOT}/api/Fechamento/?id=${id}`);
    }
});