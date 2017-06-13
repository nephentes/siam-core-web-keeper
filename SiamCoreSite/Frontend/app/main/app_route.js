var siamCoreApp = angular.module('siamCore');

siamCoreApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
         .when('/', {
             template: '<H1>MAIN</H1>',
         })
        .when('/dashboard', {
            template: '<H1>DASHBOARD</H1>',
        })
        .when('/tests', {
            template: '<H1>TESTS</H1>',
        })
        .when('/systems', {
            template: '<H1>SYSTEMS</H1>',
        })
        .when('/plugins', {
            template: '<H1>PLUGINS</H1>',
        })
        .when('/companies', {
            template: '<H1>COMPANIES</H1>',
        })
        .when('/deny', {
            templateUrl: '/commons/forms/access-denied/accessDenied.html',
        })
         .when('/login', {
             templateUrl: '/commons/forms/user-login/userLogin.html',
             controller: 'userLoginController',
         })
        .otherwise({ redirectTo: '/' });
}]);

