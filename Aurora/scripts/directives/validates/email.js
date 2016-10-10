angular.module('myApp')
    .directive('email', email);

function email() {
    return {
        restrict: 'A',
        require:'ngModel',
        link: function (scope, elm, attrs, ngModel) {
            ngModel.$validators.email = function (modelValue) {
                if (!ngModel.$isEmpty(modelValue)) {
                    var str = /^(\w|_|-)+(\.\w+)*@(\w|_|-)+((\.[a-zA-Z]{2,3}){1,3})$/;
                    return str.test(modelValue);
                } else {
                    return true;
                }
           }
        }
    };
}