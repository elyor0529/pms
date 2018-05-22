(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("tenantremoveController", tenantremoveCtrl);

    //injections
    tenantremoveCtrl.$inject = ["$rootScope", "$scope", "$stateParams", "tenantService", "utilityService"];

    function tenantremoveCtrl($rootScope, $scope, $stateParams, tenantService, utilityService) {

        // initialize your users data
        (function () {

            $rootScope.title = "Deleting confirmation  tenant...";

            tenantService.remove($stateParams.id).then(function (response) {

                $rootScope.message = "Tenant deleted successfully.";

                utilityService.redirectTo("tenant/list");

            })
        .catch(function (response) {
            $rootScope.error = utilityService.throwErrors(response);
        });

        })();

    }

})();
