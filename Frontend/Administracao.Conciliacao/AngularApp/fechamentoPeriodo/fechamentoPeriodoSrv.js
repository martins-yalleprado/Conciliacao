angular.module("MartinsApp").service("FechamentoPeriodoService", function ($http, LocalStorageService) {
    this.getFechamentoPeriodo = function (tipo, codFechamento) {
        //return $http.get(`${LocalStorageService.getUrlBack()}/api/Fechamento?tipo=${tipo}&codFechamento=${codFechamento}&codUnidade=${codUnidade}&codConta=${codConta}`);

        console.log(`${LocalStorageService.getUrlBack()}/api/Fechamento/${tipo}/${codFechamento}`);
        return $http.get(`${LocalStorageService.getUrlBack()}/api/Fechamento/${tipo}/${codFechamento}`);
    };

    this.postFechamentoPeriodo = function (obj) {
        return $http.post(`${LocalStorageService.getUrlBack()}/api/Fechamento`, obj);
    };

    this.deleteFechamentoPeriodo = function (id) {
        return $http.delete(`${LocalStorageService.getUrlBack()}/api/Fechamento/?id=${id}`);
    }
});