var siamCoreApp = angular.module('siamCore');

siamCoreApp.component('siamcoreHeader', {
    templateUrl: '/commons/components/siamcore-header/siamCoreHeader.html',
    controller: ['$timeout', '$http', '$rootScope', function ($timeout, $http, $rootScope) {
        var ctrl = this;
        //ctrl.backInfo = {};
        $http({ url: '/api/info/version/' + $rootScope.currentToken, method: 'GET' }).then(function successCallback(response) {
            ctrl.backInfo = response.data;
        }, function errorCallback(response) {
            alert('Błąd');
        });
    }]
});