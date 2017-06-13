var siamCoreApp = angular.module('siamCore');

siamCoreApp.controller('userLoginController', function AppController($scope, $rootScope, $http, $window, localStorageService) {

    $scope.processing = false;


    $scope.model = {
        userName: '',
        password: '',
        message: ''
    };

    $scope.doLogin = function () {
        $scope.processing = true;
        $scope.model.message = '';
        $http({ url: '/api/users/doLogin/' + $scope.model.userName + '/' + ($scope.model.password == '' ? 'empty' : $scope.model.password), method: 'GET' }).then(function successCallback(response) {
            //sleep(1000);
            if (response.data.resultCode == 'OK')
            {
                $rootScope.userInfo = response.data.data;
                $rootScope.currentToken = response.data.data.currentToken;
                localStorageService.set('lastToken', response.data.data.currentToken);

                $window.location.href = '#!/dashboard';
                $scope.model.message = '';
            } else
            {
                $scope.model.message = 'Wrong username or password.';
            }
            $scope.processing = false;
        }, function errorCallback(response) {
            $scope.model.message = 'Wrong username or password.';
            $scope.processing = false;
        });
    };
});