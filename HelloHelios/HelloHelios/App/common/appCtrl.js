"use strict";

angular.module('testApp').controller('appCtrl', function ($scope, $resource) {
    $scope.results = $resource('/api/hellohelios').query();
});