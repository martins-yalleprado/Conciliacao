var app = angular.module('MartinsApp', ['ui.materialize']).constant('config', {
  menu:"nenhum"
}).run(function ($rootScope) {
  $rootScope.mySetting = 42;
});


