var siamCoreApp = angular.module('siamCore');

siamCoreApp.controller('appController', function AppController($scope, $rootScope, $http, localStorageService) {
    $rootScope.currentToken = localStorageService.get('lastToken');

    $http({ url: '/api/users/checkToken/' + $rootScope.currentToken, method: 'GET', data: '' }).then(function successCallback(response) {
        $rootScope.userInfo = response.data.data;
        $rootScope.currentToken = response.data.data.currentToken;
    }, function errorCallback(response) {
        alert('Błąd');
    });
});