"use strict";

(function () {
    angular.module('crowdSource', ['ngRoute', 'ngResource', 'ngAnimate'])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $routeProvider.otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);

        }]);
})();