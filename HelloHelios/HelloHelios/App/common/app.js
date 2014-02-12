"use strict";

(function () {

    angular.module('testApp', ['ngRoute', 'ngResource'])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $routeProvider.otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);

        }]);
})();