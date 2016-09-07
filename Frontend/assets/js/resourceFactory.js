angular
    .module('requests')
    .factory('resourceFactory', function ($resource) {
        config = undefined;
        return {
            serviceHost: function () {
                if (config) {
                    return config.host;
                }

                var data = $.ajax({
                    type: "GET",
                    url: 'settings.json',
                    async: false
                }).responseText;

                config = JSON.parse(data);
                return config.host;
            },
            getFor: function (uri) {
                return $resource(this.serviceHost() + uri + ':id');
            }
        };
    });