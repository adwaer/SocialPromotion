angular
    .module('languages')
        .controller('LangCtrl', function ($scope, Culture, languageService) {

        $scope.$watch('selectedLang', function (val) {
            if (!val) {
                return;
            }

            if (defaultLang == $scope.selectedLang) {
                return;
            }

            languageService.change(val);
        });

        $scope.getLangByValue = function (lang) {
            lang = lang.toUpperCase();
            for (var i = 0; i < $scope.langs.length; i++) {
                if (lang == $scope.langs[i].key.toUpperCase()) {
                    return $scope.langs[i].key;
                }
            }

            return undefined;
        }

        var defaultLang = undefined;

        function ctor() {
            $scope.langs = Culture.query();

            $scope.langs.$promise.then(function () {
                Culture.get({id: 1}, function (response) {
                    var lang = '';
                    for (var i in response) {
                        if (typeof(response[i]) === 'string') {
                            lang += response[i];
                        }
                    }

                    $scope.selectedLang = defaultLang = $scope.getLangByValue(lang);
                });
            });
        };
        ctor();
    });
