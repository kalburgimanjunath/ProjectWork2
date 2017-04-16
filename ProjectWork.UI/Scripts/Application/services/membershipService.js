(function (app) {
    'use strict';

    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService', '$cookieStore', '$http', '$base64', '$rootScope'];

    function membershipService(apiService, notificationService,$cookieStore, $http, $base64,  $rootScope) {

        var service = {
            login: login,
            register: register,
            saveCredentials: saveCredentials,
            removeCredentials: removeCredentials,
            isUserLoggedIn: isUserLoggedIn
        }

        function login(user, completed) {
            apiService.post('/ProjectWork/api/account/authenticate', user,
            completed,
            loginFailed);
        }

        function register(user, completed) {
            apiService.post('/ProjectWork/api/account/register', user,
            completed,
            registrationFailed);
        }

        function saveCredentials(user) {
            var membershipData = $base64.encode(user.username + ':' + user.password);

            $rootScope.repository = {
                loggedUser: {
                    username: user.username,
                    authdata: membershipData
                }
            };

            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);//bug3
        }

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');//bug2
            $http.defaults.headers.common.Authorization = '';
        };

        function loginFailed(response) {
            notificationService.displayError(response.data);
        }

        function registrationFailed(response) {

            notificationService.displayError('Registration failed. Try again.');
        }

        function isUserLoggedIn() {
            debugger;
            if ($rootScope.repository === undefined)
            {
                return false;
            }
            else
            return $rootScope.repository.loggedUser != null;//bug1
            
        }

        return service;
    }



})(angular.module('common.core'));