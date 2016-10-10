angular.module('myApp')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/main', { templateUrl: '../views/main.html', controller: 'mainController' })
        .when('/register', { templateUrl: '../views/user/register-page.html', controller: 'registerController' });
        }
    ]);
    