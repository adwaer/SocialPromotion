angular
    .module('account')
    .factory('User', function ($resource, resourceFactory) {
        return $resource(resourceFactory.serviceHost() + 'api/user/:id', {})
    })