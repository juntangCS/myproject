angular.module('myApp')
    .directive('arErrorClass', errorClass);

function errorClass() {
    return {
        restrict: 'A',
        controller: ['$scope', '$element', '$attrs', function (scope, elm, attrs) {
            var addError = function () {
                elm.addClass('has-error');
            };
            var removeError = function () {
                elm.removeClass('has-error');
            };

            scope.$watch(attrs.arErrorClass + '.$invalid && ' + attrs.arErrorClass + '.$dirty', function (val) {
                if (val) {
                    addError();
                } else {
                    removeError();
                }
            });
        }]
    }
}