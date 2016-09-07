angular
    .module('dictionary')
    .factory('Metro', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/metroes/:id', { id: '@id' }, {
            query: {method: 'get', isArray: true, cancellable: true}
        })
    })
    .factory('Education', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/education/:id', { id: '@id' }, {
            query: {method: 'get', isArray: true, cancellable: true}
        })
    })
    .factory('Country', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/country/:id', { id: '@id' }, {
            query: {method: 'get', isArray: true, cancellable: true}
        })
    });