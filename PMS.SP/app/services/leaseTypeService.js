(function () {

    "use strict";

    var app = angular.module("app");

    //factories
    app.factory("leaseTypeService", leaseTypeSrvc);

    //injections
    leaseTypeSrvc.$inject = ["$q", "$http", "localStorageService", "utility"];

    function leaseTypeSrvc($q, $http, localStorageService, utility) {

        var serviceFactory = {};

        serviceFactory.list = list;

        return serviceFactory;

        function list() {

            return $http.get(utility.baseAddress + "/api/leaseType/list").then(function (response) {
                return response;
            });
        }

    }

})();

