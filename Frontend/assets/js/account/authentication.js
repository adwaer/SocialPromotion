angular
    .module('authentication')
    .factory('authenticationService',
        function (Base64, $http, $cookieStore, resourceFactory) {

            var observerCallbacks = [];

            //call this when you know 'foo' has been changed
            var notifyObservers = function (state) {
                angular.forEach(observerCallbacks, function (callback) {
                    callback(state);
                });
            };

            var service = {
                registerObserverCallback: function (callback) {
                    observerCallbacks.push(callback);
                },
                loginAsync: function (username, password) {

                    var loginApi = resourceFactory
                        .getFor('api/user?:login&:password', {login: '@login', password: '@password'})
                    //$http.get(resourceFactory.serviceHost() + 'api/user?:login&:password', { login: username, password: password})

                    return loginApi.get({login: 'login=' + username, password: 'password=' + password})
                        .$promise;
                },
                getCredentials: function () {
                    return service.globals.currentUser;
                },
                setCredentials: function (username, password) {
                    var authdata = Base64.encode(username + ':' + password);

                    service.globals = {
                        currentUser: {
                            username: username,
                            authdata: authdata
                        }
                    };

                    $http.defaults.headers.common['Authorization'] = 'Basic ' + authdata; // jshint ignore:line
                    $cookieStore.put('globals', service.globals);
                    notifyObservers(true);
                },
                clearCredentials: function () {
                    service.globals = {};
                    $cookieStore.remove('globals');
                    $http.defaults.headers.common.Authorization = 'Basic ';
                    notifyObservers(false);
                },
                isAuthentificated: function () {
                    if (service.globals && service.globals.currentUser) {
                        return true;
                    }
                    service.globals = $cookieStore.get('globals')
                    if (service.globals && service.globals.currentUser) {
                        $http.defaults.headers.common['Authorization'] = 'Basic ' + service.getCredentials().authdata;
                        notifyObservers(true);
                        return true;
                    }
                }
            };

            return service;
        })
    .factory('Base64', function () {
        /* jshint ignore:start */

        var keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';

        return {
            encode: function (input) {
                var output = "";
                var chr1, chr2, chr3 = "";
                var enc1, enc2, enc3, enc4 = "";
                var i = 0;

                do {
                    chr1 = input.charCodeAt(i++);
                    chr2 = input.charCodeAt(i++);
                    chr3 = input.charCodeAt(i++);

                    enc1 = chr1 >> 2;
                    enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                    enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                    enc4 = chr3 & 63;

                    if (isNaN(chr2)) {
                        enc3 = enc4 = 64;
                    } else if (isNaN(chr3)) {
                        enc4 = 64;
                    }

                    output = output +
                        keyStr.charAt(enc1) +
                        keyStr.charAt(enc2) +
                        keyStr.charAt(enc3) +
                        keyStr.charAt(enc4);
                    chr1 = chr2 = chr3 = "";
                    enc1 = enc2 = enc3 = enc4 = "";
                } while (i < input.length);

                return output;
            },

            decode: function (input) {
                var output = "";
                var chr1, chr2, chr3 = "";
                var enc1, enc2, enc3, enc4 = "";
                var i = 0;

                // remove all characters that are not A-Z, a-z, 0-9, +, /, or =
                var base64test = /[^A-Za-z0-9\+\/\=]/g;
                if (base64test.exec(input)) {
                    window.alert("There were invalid base64 characters in the input text.\n" +
                        "Valid base64 characters are A-Z, a-z, 0-9, '+', '/',and '='\n" +
                        "Expect errors in decoding.");
                }
                input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

                do {
                    enc1 = keyStr.indexOf(input.charAt(i++));
                    enc2 = keyStr.indexOf(input.charAt(i++));
                    enc3 = keyStr.indexOf(input.charAt(i++));
                    enc4 = keyStr.indexOf(input.charAt(i++));

                    chr1 = (enc1 << 2) | (enc2 >> 4);
                    chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                    chr3 = ((enc3 & 3) << 6) | enc4;

                    output = output + String.fromCharCode(chr1);

                    if (enc3 != 64) {
                        output = output + String.fromCharCode(chr2);
                    }
                    if (enc4 != 64) {
                        output = output + String.fromCharCode(chr3);
                    }

                    chr1 = chr2 = chr3 = "";
                    enc1 = enc2 = enc3 = enc4 = "";

                } while (i < input.length);

                return output;
            }
        };
    })
    .service('userService', function ($http, resourceFactory) {
        return {
            beginRestore: function (email) {
                return $http.post(resourceFactory.serviceHost() + 'api/user/' + email + '/beginrestore');
            },
            confirm: function (userId, token) {
                return $http.post(resourceFactory.serviceHost() + 'api/user/' + userId + '/confirm',
                    {
                        token: token
                    });
            },
            restore: function (userId, token, pwd) {
                return $http.post(resourceFactory.serviceHost() + 'api/user/' + userId + '/restore', {
                    token: token,
                    pwd: pwd
                });
            },
            isEmailBusy: function (email) {
                return $http.get(resourceFactory.serviceHost() + 'api/user/' + email + '/isemailbusy');
            },
            isAddressValid: function (details) {
                return $http.get(resourceFactory.serviceHost() + 'api/user/' + details + '/isaddressvalid');
            }
        };
    });