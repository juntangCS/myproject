angular
    .module('myApp')
    .factory('registerService', registerService);

function registerService($resource) {
    return $resource('http://localhost:1188/api/users/:id');
}