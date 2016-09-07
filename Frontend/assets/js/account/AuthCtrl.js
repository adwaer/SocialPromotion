angular
    .module('account')
    .controller('AuthCtrl', function ($scope, authenticationService, userService, dialogService) {
        $scope.isLoading = false;

        $scope.restorePassword = function () {
            if (!$scope.model || !$scope.model.email || $scope.model.email.$invalid) {
                $scope.Error = 'Укажите валидный email';
                return;
            }

            $scope.isLoading = true;
            userService.beginRestore($scope.model.email)
                .then(function () {
                    dialogService.openDialog('dialogs/alert.html', 'AlertCtrl', {
                        html: function () {
                            return 'Для завершения восстановления пароля Вам необходимо подтвердить email. На Вашу почту отправлена ссылка подтверждения.'
                        }
                    });
                })
                .finally(function () {
                    $scope.isLoading = false;
                });
        };

        $scope.submit = function () {
            if ($scope.loginForm.$invalid) {
                return;
            }

            $scope.Error = 0;
            $scope.isLoading = true;

            authenticationService.loginAsync($scope.model.email, $scope.model.password)
                .then(function (response) {
                    authenticationService.setCredentials($scope.model.email, $scope.model.password);
                    $scope.$close();
                })
                .catch(function (response) {
                    $scope.Error = 'Невозможно найти пользователя с такими данными';
                })
                .finally(function () {
                    $scope.isLoading = false;
                });
        };

        function ctor() {
            authenticationService.clearCredentials();
        }

        ctor();
    })
;