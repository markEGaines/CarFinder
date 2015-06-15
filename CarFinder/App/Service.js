(function () {
    console.log("service.js");
    angular.module('app').factory('svc', ['$http', '$q', function ($http, $q) {

        var service = {};

        var dataExtractor = function (response) {
            return response.data
        };

        service.getYears = function () {
            console.log("Service.js getYears");
            return $http.post('/api/Cars/GetYears').then(dataExtractor);
        }

        service.getMakes = function (selected) {
            return $http.post('/api/Cars/GetMakes', selected).then(dataExtractor);
        }

        service.getModels = function (selected) {
            return $http.post('/api/Cars/GetModels', selected).then(dataExtractor);
        }


        service.getTrims = function (selected) {
            return $http.post('/api/Cars/GetTrims', selected).then(dataExtractor);
        }         

        return service;

    }])
})();