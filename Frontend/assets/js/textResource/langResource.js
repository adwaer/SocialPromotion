angular
    .module('languages')
    .service('langResourceService', function (resourceFactory, $q, LangResource) {
        var resources = {};
        var resourceInRequest = {};
        var service = {
            getSingleResourceAsync: function (key) {
                var res = key.split('|');

                return service
                    .getResourceAsync(res[0])
                    .then(function (data) {
                        return data[res[1]];
                    });
            },

            getResourceAsync: function (key) {
                var deferred = $q.defer();

                if (resources[key]) {
                    deferred.resolve(resources[key]);
                    for (var v in resourceInRequest) {
                        if (v == key) {
                            delete resourceInRequest[key];
                            break;
                        }
                    }
                } else {
                    var requesting = false;
                    var promise = undefined;

                    for (var v in resourceInRequest) {
                        if (v == key) {
                            requesting = true;
                            promise = resourceInRequest[v];
                            break;
                        }
                    }

                    if (requesting) {
                        deferred.promise = promise;
                    }
                    else {
                        LangResource.get({id: key}, function (data) {
                            resources[key] = data;
                            deferred.resolve(data);
                        });

                        resourceInRequest[key] = deferred.promise;
                    }
                }
                return deferred.promise;
            },

            intenalUpdateResourceValue: function (r, value) {
                var res = r.split('|');
                var resGroup = resources[res[0]];
                resGroup[res[1]] = value;
            }
        };

        return service;
    })
    .directive('langResource', function (langResourceService) {
        var marker;
        return {
            link: function (scope, element, attributes) {

                langResourceService
                    .getSingleResourceAsync(attributes.resource)
                    .then(function (data) {
                        if (attributes.tag) {
                            element[0][attributes.tag] = data;
                        } else {
                            element[0].innerText = data;
                        }
                    })
            },
            scope: true,
            restrict: 'AE'
        };
    })
    .factory('LangResource', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/langresource/:id', {id: '@id'})
    })
    .factory('Culture', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/culture/:id', {id: '@id', domain: '@domain'}, {
            fetch: {
                method: 'get', transformResponse: function (data) {
                    return {data: angular.fromJson(data)}
                }
            },
            update: {
                method: 'PUT'
            }
        })
    });