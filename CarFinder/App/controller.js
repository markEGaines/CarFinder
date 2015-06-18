(function () {
    console.log("controller.js");
    var app = angular.module('app');

    app.controller('ctrl', ['svc', '$modal', function (svc, $modal) {
        var scope = this;
        scope.selected = {
            year: '',
            make: '',
            model: '',
            trim: '',
            filter: '',
            paging: true,
            page: 1,
            perPage: 10
        };

        scope.options = {
            years: [],
            makes: [],
            models: [],
            trims: []
        }

        scope.getYears = function () {
            console.log("controller.js getYears");
            svc.getYears().then(function (result) {
                scope.options.years = result;
            })
        }

        scope.getMakes = function () {
            scope.selected.make = '';
            scope.options.makes = [];
            scope.selected.model = '';
            scope.options.models = [];
            scope.selected.trim = '';
            scope.options.trims = [];
            svc.getMakes(scope.selected).then(function (result) {
                scope.options.makes = result;
                scope.getCars();
            })
            
        }

        scope.getModels = function () {
            scope.selected.model = '';
            scope.options.models = [];
            scope.selected.trim = '';
            scope.options.trims = [];
            svc.getModels(scope.selected).then(function (result) {
                scope.options.models = result;
                scope.getCars();
            })
        }

        scope.getTrims = function () {
            scope.selected.trim = '';
            scope.options.trims = [];
            svc.getTrims(scope.selected).then(function (result) {
                scope.options.trims = result;
                scope.getCars();
            })
        }

        scope.getCars = function () {

            var pg = angular.copy(scope.selected);
            pg.page++;

            svc.getCars(pg).then(function (result) {
                scope.cars = result.cars;
                scope.carsCount = result.carsCount;
            })
        }
        scope.cars = [];

        scope.getYears();

        scope.open = function (id) {
            console.log(id)
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'carModal.html',
                controller: 'carModalCtrl as cm',
                size: 'lg',
                resolve: {
                    carInfo: function () {
                        return svc.getCar(id);
                    }
                }
            });

            modalInstance.result.then(function () {

            }, function () {

            });
        };


    }]);

    angular.module('app').controller('carModalCtrl', function ($modalInstance, carInfo) {

        var scope = this;
        console.log(carInfo)
        scope.carInfo = carInfo;

        scope.ok = function () {
            $modalInstance.close();
        };

        scope.cancel = function () {
            $modalInstance.dismiss();
        };
    });
})();