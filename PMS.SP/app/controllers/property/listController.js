(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("propertylistController", propertylistCtrl);

    //injections
    propertylistCtrl.$inject = ["$rootScope", "$scope", "$stateParams", "propertyService", "utilityService", "bootstrap3ElementModifier"];

    function propertylistCtrl($rootScope, $scope, $stateParams, propertyService, utilityService, bootstrap3ElementModifier) {

        bootstrap3ElementModifier.enableValidationStateIcons(false);

        //$scope.page = $stateParams.page;
        //$scope.search = $stateParams.search;

        // initialize your users data
        (function () {

            $rootScope.title = "Properties";

            propertyService.list().then(function (response) {

                $scope.propertyData = response.data;
                //$scope.pager = response.data.pager;
            })
        .catch(function (response) {
            $rootScope.error = utilityService.throwErrors(response);
        });

        })();

        $scope.range = function (min, max, step) {
            step = step || 1;

            var input = [];
            for (var i = min; i <= max; i += step) {
                input.push(i);
            }

            return input;
        };


    }

})();
