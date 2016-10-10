angular.module('myApp')
    .controller('mainController', mainController);

function mainController(registerService) {
    var vm = this;
    vm.data = {};
    var id = getUrlParameter('id');
    if (id != undefined) {
        registerService.get({ id: id }, function (data) {
            vm.data = data;
        });
    }
}