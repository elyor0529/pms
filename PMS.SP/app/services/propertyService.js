(function () {

    "use strict";

    var app = angular.module("app");

    //factories
    app.factory("propertyService", propertySrvc);

    //injections
    propertySrvc.$inject = ["$q", "$http", "localStorageService", "utility"];

    function propertySrvc($q, $http, localStorageService, utility) {

        var serviceFactory = {};

        serviceFactory.list = list; 

        return serviceFactory;

        function list() {

            return $http.get(utility.baseAddress + "/api/property/list").then(function (response) {
                return response;
            });
        } 

    }

})();

