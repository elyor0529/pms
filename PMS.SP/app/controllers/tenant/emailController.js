(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("tenantemailController", tenantemailCtrl);

    //injections
    tenantemailCtrl.$inject = ["$rootScope", "$scope", "$stateParams", "tenantService", "accountService", "utilityService"];

    function tenantemailCtrl($rootScope, $scope, $stateParams, tenantService, accountService, utilityService) {

        var authData = accountService.fillAuthData();

        $scope.emailData = {
            id: $stateParams.id,
            from: authData.email,
            to: "",
            subject: "",
            body: ""
        };

        $scope.send = send;

        // initialize your users data
        (function () {

            $rootScope.title = "Send email";

            tenantService.details($stateParams.id).then(function (response) {
                var emails = [];

                angular.forEach(response.data.tenants, function (tenant) {
                    emails.push(tenant.email);
                });

                $scope.emailData.to = emails.join(";");
            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });


        })();

        function send() {
            tenantService.email($scope.emailData).then(function (response) {

                $rootScope.message = "Email sent successfully.";

                utilityService.redirectTo("tenant/list");
            })
        .catch(function (response) {
            $rootScope.error = utilityService.throwErrors(response);
        });
        }

    }

})();
