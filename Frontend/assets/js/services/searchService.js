angular
    .module('search')
    .service('searchService', function ($http, resourceFactory) {

        var service = {
            searchAsync: function (criteria) {
                return $http.get(resourceFactory.serviceHost() + 'api/workers', {
                    params: criteria
                });
            }
        };

        return service;
    });