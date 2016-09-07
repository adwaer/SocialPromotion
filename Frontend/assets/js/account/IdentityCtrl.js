angular
    .module('account')
    .controller('IdentityCtrl', function ($scope, authenticationService) {

        function setAuths() {
            $scope.IsAuthentificated = authenticationService.isAuthentificated();
            if (authenticationService.isAuthentificated()) {
                $scope.userName = authenticationService.getCredentials().username;
            } else {
                $scope.userName = undefined;
            }
        };

        authenticationService.registerObserverCallback(function () {
            setAuths();
        });

        $scope.logAuth = function () {
            authenticationService.clearCredentials();
        };

        function ctor(){
            setAuths();
        }
        ctor();
    });
