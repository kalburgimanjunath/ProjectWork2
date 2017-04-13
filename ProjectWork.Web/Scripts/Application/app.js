(function () {
    'use strict';
    angular.module('projectWork', ['common.core', 'common.ui']).config(config);
    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "scripts/Application/home/index.html",
            controller: "indexCtrl"
        }).otherwise({ redirectTo: "/" });
    }
})();