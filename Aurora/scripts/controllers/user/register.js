angular.module('myApp')
    .controller('registerController', registerController);

function registerController(registerService) {
    var vm = this;
    vm.data = {};
    vm.resigterFun = resigter;

    function resigter(registerForm) {
        if (formValidation(registerForm)) {
            showOverlay();
            registerService.save(vm.data).$promise.then(
                function (data) {
                    window.location.href="../../main.html?id="+data.id+"";
                    hideOverlay();
                },
                function (error) { });
        }
    }
}

