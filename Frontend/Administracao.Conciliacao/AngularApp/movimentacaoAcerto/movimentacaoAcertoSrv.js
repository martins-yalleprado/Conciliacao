
angular.module("MartinsApp").service("MovimentacaoAcertoService", function ($http, LocalStorageService) {
    this.getMovimentacaoAcertoPorData = function (data) {
        return $http.get(`${LocalStorageService.getUrlBack()}/api/MovimentoAcerto/${data}`);
    };

    this.putMovimentacaoAcerto = function (numSeq, mov) {
        return $http.put(`${LocalStorageService.getUrlBack()}/api/MovimentoAcerto`, mov);
    };

    this.postMovimentacaoAcerto = function (mov) {
        return $http.post(`${LocalStorageService.getUrlBack()}/api/MovimentoAcerto`, mov);
    };

    this.deleteMovimentoAcerto = function (numSeq, data, codIdt) {
        return $http.delete(`${LocalStorageService.getUrlBack()}/api/MovimentoAcerto/${numSeq}/${data}/${codIdt}`);
    }

});
