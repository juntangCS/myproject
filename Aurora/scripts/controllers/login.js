angular.module('myApp')
    .controller('loginController', loginController);

function loginController(registerService) {
    var vm = this;
    vm.data = {};
    var id = getUrlParameter('id');
    if (id != undefined) {
        registerService.get({ id: id }, function (data) {
            vm.data = data;
        });
    }

    vm.resigterFun = resigter;

    function resigter(registerForm) {
        if (formValidation(registerForm)) {
            showOverlay();
            registerService.save(vm.data).$promise.then(
                function (data) {
                    window.location.href = "../../main.html?id=" + data.id + "";
                    hideOverlay();
                },
                function (error) { });
        }
    }
}