angular
    .module('ngDialog', ['ui.bootstrap'])
    .service('dialogService', function ($uibModal) {
        var currentDialog = undefined;
        return {
            openDialog: function (template, ctrl, resolve, params) {
                if (currentDialog) {
                    currentDialog.close();
                }

                currentDialog = $uibModal.open({
                    animation: true,
                    templateUrl: template,
                    controller: ctrl,
                    resolve: resolve || {}
                });

                currentDialog.closed.then(function () {
                    if (params && params.onClosed) {
                        params.onClosed();
                    }
                });
            },
        };
    })
    .directive('ngDialog', function (dialogService) {
        var marker;
        return {
            link: function (scope, element, attributes) {
                element.bind('click', function () {
                    dialogService.openDialog(attributes.template, attributes.ctrl, {
                        dlgScope: function () {
                            return scope;
                        }
                    }, attributes.params);
                });
            },
            scope: true,
            restrict: 'AE',
            require: '?ngModel'
        };

    });