(function () {
    'use strict';
    angular.module('projectWork', ['common.core', 'common.ui']).config(config);
    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "Scripts/Application/home/index.html",
            controller: "indexCtrl"
        })
        .when("/login", {
            templateUrl: "Scripts/Application/account/login.html",
                controller: "loginCtrl"
            })
        .when("/register", {
            templateUrl: "Scripts/Application/account/register.html",
                controller: "registerCtrl"
        }).otherwise({ redirectTo: "ProjectWork/" });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true,
            rewriteLinks: true
        });
    }


    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
           
            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }
})();