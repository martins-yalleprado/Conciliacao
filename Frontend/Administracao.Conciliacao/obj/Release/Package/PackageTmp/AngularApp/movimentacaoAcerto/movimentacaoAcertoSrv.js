
angular.module("MartinsApp").service("MovimentacaoAcertoService", function ($http, AppConstants) {
    this.getMovimentacaoAcertoPorData = function (data) {
        //console.log(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${data}`);

        return $http.get(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${data}`);
    };

    this.putMovimentacaoAcerto = function (numSeq, mov) {
        //console.log(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov);

        return $http.put(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov);
    };

    this.postMovimentacaoAcerto = function (mov) {
        //console.log(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov);

        return $http.post(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov);
    };

    this.deleteMovimentoAcerto = function (numSeq, data, codIdt) {
        return $http.delete(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${numSeq}/${data}/${codIdt}`);
    }

});
