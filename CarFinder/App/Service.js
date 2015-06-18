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

        service.getCar = function (id) {
            return $http.get('/api/Cars/GetCar', { params: { id: id } }).then(dataExtractor).then(function (data) {
                data.recalls = JSON.parse(data.recalls);
                return data;
            });;
        }

        service.getCars = function (selected) {
            var def = $q.defer();

            var carCounts = $http.post('/api/Cars/GetCarsCount', selected).then(dataExtractor);
            var cars = $http.post('/api/Cars/GetCars', selected).then(dataExtractor)

            $q.all([carCounts, cars]).then(function (data) {
                def.resolve({ carsCount: data[0], cars: data[1] });
            });

            return def.promise;
        }


        return service;

    }])
})();