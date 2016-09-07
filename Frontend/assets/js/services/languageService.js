angular
    .module('languages')
    .service('languageService', function ($http, $q, $cookies, Culture, authenticationService) {

        var service = {
            getFromServerAsync: function () {
                var deferred = $q.defer();

                Culture.get({id: 1}, function (response) {
                    var lang = '';
                    for (var i in response) {
                        if (typeof(response[i]) === 'string') {
                            lang += response[i];
                        }
                    }

                    deferred.resolve(lang);
                });

                return deferred.promise;
            },
            change: function (culture) {
                if(!service.setCookie(culture)) {
                    return;
                }

                if (authenticationService.isAuthentificated()) {
                    Culture.update({id: culture}, function () {
                        window.location.reload();
                    });
                } else {
                    window.location.reload();
                }
            },
            setCookie: function (culture) {
                if($cookies.get('AcceptLanguageCookie') == culture){
                    return false;
                }

                var expireDate = new Date();
                expireDate.setYear(expireDate.getFullYear() + 1);

                $cookies.put('AcceptLanguageCookie', culture, {'expires': expireDate});
                return true;
            }
        };

        function ctor() {
            authenticationService.registerObserverCallback(function (state) {
                if (!state) {
                    return;
                }

                service
                    .getFromServerAsync()
                    .then(function (culture) {
                        if(service.setCookie(culture)) {
                            window.location.reload();
                        }
                    });
            });
        };
        ctor();

        return service;
    });