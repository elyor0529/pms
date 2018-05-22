(function () {

    "use strict";

    var app = angular.module("app");

    //factories
    app.factory("paymentTypeService", paymentTypeSrvc);

    //injections
    paymentTypeSrvc.$inject = ["$q", "$http", "localStorageService", "utility"];

    function paymentTypeSrvc($q, $http, localStorageService, utility) {

        var serviceFactory = {};

        serviceFactory.list = list; 

        return serviceFactory;

        function list() {

            return $http.get(utility.baseAddress + "/api/paymentType/list").then(function (response) {
                return response;
            });
        } 

    }

})();

