var siamCoreApp = angular.module('siamCore', []);

siamCoreApp.controller('appController', function AppController($scope) {
    $scope.phones = [
      {
          name: 'Nexus S',
          snippet: 'Fast just got faster with Nexus S.'
      }, {
          name: 'Motorola XOOM™ with Wi-Fi',
          snippet: 'The Next, Next Generation tablet.'
      }, {
          name: 'MOTOROLA XOOM™',
          snippet: 'The Next, Next Generation tablet.'
      }
    ];
});