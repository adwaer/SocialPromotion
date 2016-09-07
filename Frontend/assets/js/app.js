angular
    .module('dialogs', []);
angular
    .module('requests', []);
angular
    .module('authentication', ['requests']);
angular
    .module('account', ['requests', 'authentication'])
    .config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
                .when('/confirm_email', {
                    templateUrl: 'workers/workers.html',
                    controller: function (dialogService, $location) {
                        dialogService.openDialog('account/confirm_email.html', 'ConfirmEmailCtrl', undefined,
                            {
                                onClosed: function () {
                                    $location.path('/');
                                }
                            })
                    }
                })
                .when('/restore_pwd', {
                    templateUrl: 'workers/workers.html',
                    controller: function (dialogService, $location) {
                        dialogService.openDialog('account/confirm_pwd.html', 'ConfirmPasswordCtrl', undefined,
                            {
                                onClosed: function () {
                                    $location.path('/');
                                }
                            })
                    }
                })
        }]);

angular
    .module('workers', ['authentication', 'dictionary', 'search'])
    .config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'workers/workers.html',
                    controller: 'workersCtrl'
                });
        }]);

angular
    .module('dictionary', ['requests', 'languages'])
angular
    .module('search', ['requests'])
angular
    .module('address', ['requests'])
angular
    .module('languages', ['requests', 'ngCookies']);
angular
    .module('languagesEdit', ['requests', 'dialogs']);

var app = angular.module('app',
    ['ngResource',
        'ngRoute',
        'ui.bootstrap',
        'requests',
        'ngDialog',
        'account',
        'authentication',
        'ngCookies',
        'dialogs',
        'ngAutocomplete',
        'workers',
        'infinite-scroll',
        'languages',
        'languagesEdit'
    ])
    .config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $routeProvider
                .otherwise({
                    controller: function () {
                        window.location.replace('/');
                    },
                    template: "<div>404</div>"
                });
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        }])
    .config(["$httpProvider", function ($httpProvider) {
        $httpProvider.defaults.transformResponse.push(function (responseData) {
            // string date to date
            helpers.convertDateStringsToDates(responseData);
            return responseData;
        });
    }])
    .run(['$rootScope', '$location', '$cookies', '$http', 'authenticationService',
        function ($rootScope, $location, $cookies, $http, authenticationService) {
            // keep user logged in after page refresh
            authenticationService.isAuthentificated();

            // set Accept-Language header on all requests to
            // value of AcceptLanguageCookie cookie
            var culture = $cookies.get("AcceptLanguageCookie");
            if(culture) {
                $http.defaults.headers.common["Accept-Language"] = culture;
            }
            //$httpProvider.defaults.headers.common["Accept-Language"] = $cookieStore.get("AcceptLanguageCookie");
        }]);
//.config([
//    '$httpProvider', function ($httpProvider) {
//         $httpProvider.defaults.useXDomain = true;
//           delete $httpProvider.defaults.headers.common['X-Requested-With'];
//      }
//]);


angular.element(document).ready(function () {
    angular.bootstrap(document, ['app']);
});