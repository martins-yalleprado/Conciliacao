angular.module('MartinsApp').factory('sessionInjector', function (AppConstants, LocalStorageService) {
    var sessionInjector = {
        request: function (config) {
            //if (!AppConstants.TOKEN != undefined) {
                config.headers['Access-Control-Allow-Origin'] = '*';
                config.headers['x-session-token'] = LocalStorageService.getToken();
                config.headers['x-codigo-conta'] = LocalStorageService.getCodConta();
                config.headers['x-codigo-unidade'] = LocalStorageService.getCodUnidade();
                config.headers['x-descricao-conta'] = LocalStorageService.getDescricaoConta();
                config.headers['x-descricao-unidade'] = LocalStorageService.getDescricaoUnidade();
            //}
            return config;
        }
    };
    return sessionInjector;
});
//angular.module("MartinsApp").factory("loadingInterceptor", function ($q, $rootScope, $timeout) {
//    return {
//        request: function (config) {
//            $rootScope.loading = true;
//            return config;
//        },
//        requestError: function (rejection) {
//            $rootScope.loading = false;
//            return $q.reject(rejection);
//        },
//        response: function (response) {
//            $timeout(function () {
//                $rootScope.loading = false;
//            }, 500);
//            return response;
//        },
//        responseError: function (rejection) {
//            $rootScope.loading = false;
//            return $q.reject(rejection);
//        }
//    };
//});