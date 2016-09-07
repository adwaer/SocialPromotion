angular
    .module('languagesEdit')
    .controller('LangResourceEditCtrl', function ($scope, dialogService) {
        $scope.openEditMode = function () {
            $('[lang-resource]').contextmenu('click', function (e) {
                var el = $(e.target);
                var tag = el.attr('resource');
                var text = el.text();

                dialogService.openDialog('textResource/edit.html', 'LangResourceValueEditCtrl', {
                    tag: function () {
                        return tag;
                    },
                    text: function () {
                        return text;
                    }
                });

                e.preventDefault();
            });
        };
    });