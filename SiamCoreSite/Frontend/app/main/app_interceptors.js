var siamCoreApp = angular.module('siamCore');


siamCoreApp.factory('defaultResponseInterceptor', ['$q', '$location', '$window', function ($q, $location, $window) {
    return {
        response: function (response) {
            if (response.data.isOk == true) {
                switch (response.data.resultCode) {
                    case 'RELOGIN':
                        // we should redirect user to login page
                        $window.location.href = '#!/login';
                        break;

                    //case 'DENY':
                    //    // we should redirect user to login page
                    //    $window.location.href = '#!/deny';
                    //    break;

                    default: // nothing to do
                        break;
                }
            } else if (response.data.isOk == false) {
                Alert(response.data.message);
            }
            else {
                // Not recognized format. For example static file.
            }
            return response;
        }
    }
}]);


siamCoreApp.config(['$httpProvider', function ($httpProvider) {

    $httpProvider.interceptors.push('defaultResponseInterceptor');
}]);