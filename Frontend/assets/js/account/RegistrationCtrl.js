angular
    .module('account')
    .controller('RegistrationCtrl', function ($scope, User, dialogService, userService, authenticationService, Country) {
        $scope.isLoading = false;

        $scope.submit = function () {
            if ($scope.registerForm.$invalid) {
                return;
            }
            if ($scope.model.confirm !== $scope.model.password) {
                $scope.Error = 'Некорректное подтверждение пароля';
                return;
            }
            if ($scope.IsEmailBusy) {
                $scope.Error = 'E-mail занят, попробуйте войти под существующей учеткой';
                return;
            }

            $scope.Error = '';
            $scope.isLoading = true;
            fillDetails();

            $scope.model.$save(function () {
                    authenticationService.loginAsync($scope.model.email, $scope.model.password)
                        .then(function (response) {
                            authenticationService.setCredentials($scope.model.email, $scope.model.password);
                        })
                        .catch(function (response) {
                            $scope.Error = 'Невозможно найти пользователя с такими данными';
                        })
                        .finally(function () {
                            $scope.isLoading = false;
                        });

                    $scope.$close();

                    $scope.isLoading = false;
                    dialogService.openDialog('dialogs/alert.html', 'AlertCtrl', {
                        html: function () {
                            return 'Для завершения регистрации Вам необходимо подтвердить email. На Вашу почту отправлена ссылка подтверждения.'
                        }
                    })
                },
                function (result) {
                    if (result.data && result.data.Message == 'username_busy') {
                        $scope.Error = 'Пользователь с таким e-mail уже существует. Попробуйте восстановить пароль.';
                    } else if (result.data && result.data.Message == 'address_not_valid') {
                        $scope.Error = 'Адрес не валиден';
                    } else if (result.data && result.data.Message == 'bithtdate_required') {
                        $scope.Error = 'Укажите дату рождения';
                    } else if (result.data && result.data.Message == 'date_out_of_range') {
                        $scope.Error = 'Дата рождения указана в неверном диапазоне';
                    }
                    else if (result.data && result.data.Message) {
                        $scope.Error = result.data.Message
                    }
                    else if (result.data && result.data.ModelState) {
                        for (var v in result.data.ModelState) {
                            $scope.Error += result.data.ModelState[v];
                        }
                    } else {
                        $scope.Error = 'Невозможно зарегистрировать пользователя, возможны вы указали некорректные данные';
                    }
                    $scope.isLoading = false;
                });
        };

        function fillDetails() {
            $scope.model.customer.addressJson = JSON.stringify($scope.details);
            $scope.IsAddressValid = false;
            for (var i = 0; i < $scope.details.address_components.length; i++) {
                var unit = $scope.details.address_components[i];
                for (var j = 0; j < unit.types.length; j++) {
                    if (unit.types[j] === 'route' || unit.types[j] === 'postal_code') {
                        $scope.IsAddressValid = true;
                        return;
                    }
                }
            }
        };
        $scope.paOprions = {  };
        $scope.details = {  };

        $scope.IsEmailBusy = false;

        function ctor() {
            $scope.country = Country
                .get().$promise
                .then(function (country) {
                    $scope.paOprions.country = country.iso.toLocaleLowerCase();
                });

            $scope.model = new User();
            $scope.model.customer = {}
            $scope.$watch('model.email', function (val) {
                if (!$scope.model.email || $scope.model.email.$invalid) {
                    return;
                }

                $scope.isEmailLoading = true;
                userService.isEmailBusy($scope.model.email)
                    .then(function (result) {
                        $scope.IsEmailBusy = result.data;
                    })
                    .finally(function () {
                        $scope.isEmailLoading = false;
                    });
            });
        }

        ctor();
    });