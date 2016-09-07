angular
    .module('account')
    .controller('ConfirmEmailCtrl', function ($scope, $routeParams, userService) {
        $scope.isLoading = true;
        $scope.message = '';
        $scope.Error = '';

        function ctor() {
            userService.confirm($routeParams.userId, $routeParams.token)
                .then(function () {
                    $scope.message = 'Аккаунт успешно подтвержден, можете зайти своей учетноый записью';
                }, function (result) {
                    if (result.data && result.data.Message) {
                        var msg = result.data.Message;
                        if (msg === 'user_not_found') {
                            $scope.Error = 'Пользователь не найден';
                        }
                        else if (msg === 'user_check_error') {
                            $scope.Error = 'Невозможно проверить пользователя';
                        }
                        else if (msg === 'already_confirmed') {
                            $scope.Error = 'Уже подтверждено';
                        }
                        else if (msg === 'cannot_confirm') {
                            $scope.Error = 'Ссылка устарела, попробуйте еще раз';
                        }
                    }

                    if (!$scope.Error) {
                        $scope.Error = 'Ссылка устарела, попробуйте еще раз';
                    }
                })
                .finally(function () {
                    $scope.isLoading = false;
                });
        }

        ctor();
    });