angular
    .module('languagesEdit')
    .controller('LangResourceValueEditCtrl', function ($scope, tag, text, LangResource, langResourceService) {

        $scope.submit = function () {
            if ($scope.resourceEditForm.$invalid) {
                return;
            }
            $scope.Error = '';
            $scope.isLoading = true;
            $scope.model.$save(function () {
                    $scope.$close();
                    $scope.isLoading = false;
                    langResourceService.intenalUpdateResourceValue(tag, $scope.model.value);
                    window.location.reload();
                },
                function (result) {
                    if (result.data && result.data.ModelState) {
                        for (var v in result.data.ModelState) {
                            $scope.Error += result.data.ModelState[v];
                        }
                    }
                    else if (result.data && result.data.Message) {
                        if (result.data.Message == 'username_busy') {
                            $scope.Error = 'Пользователь с таким e-mail уже существует. Попробуйте восстановить пароль.';
                        } else if (result.data.Message == 'address_not_valid') {
                            $scope.Error = 'Адрес не валиден';
                        } else {
                            $scope.Error = result.data.Message;
                        }
                    } else {
                        $scope.Error = 'Невозможно зарегистрировать пользователя, возможны вы указали некорректные данные';
                    }
                    $scope.isLoading = false;
                });
        };

        function ctor() {
            $scope.model = new LangResource({id: tag.replace('.', '|'), value: text});
        };
        ctor();
    })
;