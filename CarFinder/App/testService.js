(function () {
    angular.module('app').factory('svc', ['$http', '$q', function ($http, $q) {

        var service = {};

        service.getYears = function () {
            var deferred = $q.defer();
            deferred.resolve([1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007,
                              2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015]);
            return deferred.promise;

        }

        service.getMakes = function (year) {
            var deferred = $q.defer();

            switch (year) {
                case 1998:
                case 1999:
                case 2000:
                    deferred.resolve(['Toyota', 'Honda', 'Ford'])
                    break;
                case 2001:
                case 2002:
                case 2003:
                case 2004:
                    deferred.resolve(['Toyota', 'Honda', 'Ford', 'Acura'])
                    break;
                case 2005:
                case 2006:
                case 2007:
                case 2008:
                case 2009:
                case 2010:
                    deferred.resolve(['Toyota', 'Honda', 'Ford', 'Hyundai', 'Dodge'])
                    break;
                case 2011:
                case 2012:
                case 2013:
                case 2014:
                case 2015:
                    deferred.resolve(['Toyota', 'Honda', 'Ford', 'Hyundai', 'Dodge', 'Acura', 'Nissan'])
                    break;
            }

            return deferred.promise;
        }

        service.getModels = function (make) {
            var deferred = $q.defer();

            switch (make) {
                case 'Toyota':
                    deferred.resolve(['Tercel', 'Prius', '4Runner'])
                    break;
                case 'Honda':
                    deferred.resolve(['Accord', 'Odyssey', 'Civic'])
                    break;
                case 'Ford':
                    deferred.resolve(['F150', 'Falcon', 'Galaxy'])
                    break;
                case 'Hyundai':
                    deferred.resolve(['Elantra', 'Santa Fe', 'Veloster'])
                    break;
                case 'Dodge':
                    deferred.resolve(['Viper', 'Dart', 'Caravan'])
                    break;
                case 'Nissan':
                    deferred.resolve(['Fairlady', 'Altima', 'Rogue'])
                    break;
                case 'Acura':
                    deferred.resolve(['MDX', 'RDX', 'TLX'])
                    break;
            }

            return deferred.promise;
        }


        service.getTrims = function (model) {
            var deferred = $q.defer();

            switch (model) {
                case 'Tercel':
                case 'Prius':
                case '4Runner':
                case 'Accord':
                case 'Odyssey':
                case 'Civic':
                case 'F150':
                case 'Falcon':
                case 'Galaxy':
                    deferred.resolve(['Limited', 'Platinum', 'Sport'])
                    break;
                case 'Elantra':
                case 'Santa Fe':
                case 'Veloster':
                case 'Viper':
                case 'Dart':
                case 'Caravan':
                case 'Fairlady':
                case 'Altima':
                case 'Rogue':
                case 'MDX':
                case 'RDX':
                case 'TLX':
                    deferred.resolve(['Luxury', 'Base', 'Basic'])
                    break;
            }

            return deferred.promise;
        }

        return service;

    }])
})();