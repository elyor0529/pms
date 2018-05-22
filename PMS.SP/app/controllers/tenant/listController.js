(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("tenantlistController", tenantlistCtrl);

    //injections
    tenantlistCtrl.$inject = ["$rootScope", "$scope", "$stateParams", "tenantService", "utilityService", "bootstrap3ElementModifier"];

    function tenantlistCtrl($rootScope, $scope, $stateParams, tenantService, utilityService, bootstrap3ElementModifier) {

        bootstrap3ElementModifier.enableValidationStateIcons(false);

        $scope.page = $stateParams.page;
        $scope.search = $stateParams.search;
        $scope.downloadUrl = utilityService.getInstance().baseAddress + "/api/file/download";
        $scope.range = utilityService.getRange;
        $scope.list = list;
        $scope.reset = reset;

        // initialize your users data
        (function () {

            $rootScope.title = "Tenants";

            list();

        })();

        function reset() {
            $scope.search = "";

            list();
        }

        function list() {
            tenantService.list($scope.page, $scope.search).then(function (response) {

                $scope.tenantData = response.data.items;
                $scope.pager = response.data.pager;
            })
            .catch(function (response) {
                $rootScope.error = utilityService.throwErrors(response);
            });
        }
    }

})();
