angular.module('MartinsApp').factory('sessionInjector', function (AppConstants) {
    var sessionInjector = {
        request: function(config) {
            if (!AppConstants.TOKEN != undefined) {
                config.headers['x-session-token'] = AppConstants.TOKEN;
            }
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