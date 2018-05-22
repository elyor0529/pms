(function () {

    "use strict";

    var app = angular.module("app");

    //factories
    app.factory("paymentFrequencyService", paymentFrequencySrvc);

    //injections
    paymentFrequencySrvc.$inject = ["$q", "$http", "localStorageService", "utility"];

    function paymentFrequencySrvc($q, $http, localStorageService, utility) {

        var serviceFactory = {};

        serviceFactory.list = list; 

        return serviceFactory;

        function list() {

            return $http.get(utility.baseAddress + "/api/paymentFrequency/list").then(function (response) {
                return response;
            });
        } 

    }

})();

