(function () {
    console.log("controller.js");
    var app = angular.module('app');

    app.controller('ctrl', ['svc', function (svc) {
        var scope = this;
        scope.selected = {
            year: '',
            make: '',
            model: ''
        };

        scope.options = {
            years: [],
            makes: [],
            models: []
        }

        scope.getYears = function () {
            console.log("controller.js getYears");
            svc.getYears().then(function (result) {
                scope.options.years = result;
            })
        }

        scope.getMakes = function () {
            svc.getMakes(scope.selected).then(function (result) {
                scope.options.makes = result;
            })
        }

        scope.getModels = function () {
            svc.getModels(scope.selected).then(function (result) {
                scope.options.models = result;
            })
        }

        scope.getTrims = function () {
            svc.getTrims(scope.selected).then(function (result) {
                scope.options.trims = result;
            })
        }

        scope.cars = [];

        scope.getYears();

    }]);

})();