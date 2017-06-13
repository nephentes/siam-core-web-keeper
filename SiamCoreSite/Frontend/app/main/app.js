var siamCoreApp = angular.module('siamCore', ['ngRoute', 'LocalStorageModule']);

siamCoreApp.controller('appController', function AppController($scope) {
    $scope.something = 1.1;
});