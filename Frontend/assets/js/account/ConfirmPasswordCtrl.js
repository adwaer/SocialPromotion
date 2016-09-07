angular
    .module('account')
    .controller('ConfirmPasswordCtrl', function ($scope, $routeParams, dialogService, userService) {
        $scope.isLoading = false;
        $scope.message = '';
        $scope.Error = '';

        $scope.submit = function () {
            if ($scope.form.$invalid) {
                return;
            }

            $scope.isLoading = true;
            userService.restore($routeParams.userId, $routeParams.token, $scope.pwd)
                .then(function () {
                    $scope.$close();
                    dialogService.openDialog('dialogs/alert.html', 'AlertCtrl', {
                        html: function () {
                            return 'Пароль успешно изменен';
                        }
                    })
                }, function (result) {
                    if (result.data && result.data.Message) {
                        var msg = result.data.Message;
                        if (msg === 'user_not_found') {
                            $scope.Error = 'Пользователь не найден';
                        }
                        else if (msg === 'cannot_restore') {
                            $scope.Error = 'Невозможно восстановить, ссылка устарела';
                        }
                    }

                    if (!$scope.Error) {
                        $scope.Error = 'Ссылка устарела, попробуйте восстановить аккаунт';
                    }
                })
                .finally(function () {
                    $scope.isLoading = false;
                });
        };

        function ctor() {

        }

        ctor();
    });