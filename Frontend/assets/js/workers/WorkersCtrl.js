angular
    .module('workers')
    .controller('workersCtrl', function ($scope, authenticationService, Metro, Education, Country, searchService, dialogService) {
        $scope.isLoading = false;
        $scope.Header = 'Поиск сотрудников';
        $scope.workers = [];

        function handleNoGeolocation(errorFlag) {
            //if (errorFlag) {
            //    alert("Сервис геолокации вернул ошибку, мы установили ваше положение в Москву.");
            //} else {
            //    alert("Ваш браузер не поддерживает геолокацию, мы установили ваше положение в Москву.");
            //}
            $scope.model.distanceLat = 55.755826;
            $scope.model.distanceLng = 37.6173;

            search();
        }

        $scope.currentSearch = {};
        function search() {

            if (angular.equals($scope.currentSearch, $scope.model)) {
                $scope.model.page = 0;
            }
            if (!$scope.model.page) {
                $scope.workers.length = 0;
            }

            $scope.isLoading = true;
            searchService
                .searchAsync($scope.model)
                .then(function (response) {
                    $scope.count = response.data.count;

                    var data = response.data.workers;
                    if (!data.length && $scope.model.page > 0) {
                        $scope.model.page--;
                    }

                    for (var i = 0; i < data.length; i++) {
                        $scope.workers.push(data[i]);
                    }
                    angular.copy($scope.model, $scope.currentSearch);
                })
                .catch(function (response) {
                    console.log(response);
                    $scope.Error = 'Произошла ошибка';
                })
                .finally(function () {
                    $scope.isLoading = false;
                });
        }

        $scope.submit = function () {
            $scope.model.workerType = $scope.workerType.id;

            if ($scope.searchForm.$invalid) {
                return;
            }
            if ($scope.model.distanceFrom == 2) {
                if (!$scope.model.metro) {
                    dialogService.openDialog('dialogs/alert.html', 'AlertCtrl', {
                        html: function () {
                            return 'Укажите станцию метро'
                        }
                    });
                    return;
                }

                $scope.model.distanceLat = $scope.model.metro.lat;
                $scope.model.distanceLng = $scope.model.metro.lng;
                search();

            } else if ($scope.model.distanceFrom == 1) {
                fillDetails();
                search();
            } else if (!authenticationService.isAuthentificated()) {
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        $scope.model.distanceLat = position.coords.latitude;
                        $scope.model.distanceLng = position.coords.longitude;
                        search();
                    }, function () {
                        handleNoGeolocation(true);
                    });
                }
                // Browser doesn't support Geolocation
                else {
                    handleNoGeolocation(false);
                }
            } else {
                search();
            }
        };

        function fillDetails() {
            $scope.addressEditing = false;

            $scope.model.distanceLat = $scope.details.geometry.location.lat();
            $scope.model.distanceLng = $scope.details.geometry.location.lng();

            for (var i = 0; i < $scope.details.address_components.length; i++) {
                var unit = $scope.details.address_components[i];
                for (var j = 0; j < unit.types.length; j++) {
                    if (unit.types[j] === 'locality') {
                        $scope.model.addressCity = unit.long_name;
                        return;
                    }
                }
            }
        };
        $scope.paOprions = {  };
        $scope.details = {  };

        $scope.workerTypeEditing = false;
        $scope.addressEditing = false;
        $scope.workerTypes = [
            {name: 'workerType_nannywork', id: 4},
            {name: 'workerType_nursework', id: 5},
            {name: 'workerType_housekeeperwork', id: 6}
        ];
        $scope.workerType = $scope.workerTypes[0];

        function ctor() {
            $scope.model = {
                distanceFrom: 0,
                distanceUntil: 17,
                address: undefined,
                page: 0,
                count: 17
            };

            $scope.metroes = Metro
                .query();

            $scope.educations = Education
                .query();

            $scope.country = Country
                .get().$promise
                .then(function (country) {
                    $scope.paOprions.country = country.iso.toLocaleLowerCase();
                });

            $(window).on('scroll', function () {
                if ($scope.isLoading) {
                    return;
                }

                var $w = $(window);
                if ($w.scrollTop() + $w.height() >= $(document).height() - 100) {
                    $scope.model.page++;
                    $scope.submit();
                }
            });
        }

        ctor();
    });