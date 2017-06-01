var siamCoreApp = angular.module('siamCore');

siamCoreApp.component('siamcoreHeader', {
    templateUrl: '/commons/components/siamcore-header/siamCoreHeader.html',
    controller: ['$timeout', '$http', function ($timeout, $http) {
        var ctrl = this;
        //ctrl.backInfo = {};
        $http({ url: '/api/info/version/aaa', method: 'GET' }).then(function successCallback(response) {
            ctrl.backInfo = response.data;
        }, function errorCallback(response) {
            alert('Błąd');
        });
    }]
});