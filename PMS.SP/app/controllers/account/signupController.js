(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("signupController", signupCtrl);

    //injections
    signupCtrl.$inject = ["$rootScope", "$scope", "accountService", "utilityService", "noCAPTCHA"];

    function signupCtrl($rootScope, $scope, accountService, utilityService, noCAPTCHA) {

        $scope.gRecaptchaResponse = "";

        $scope.registrationData = {
            email: "",
            password: "",
            confirmpassword: "",
            callbackUrl: utilityService.getUrl("confirmemail")
        };

        $scope.$watch('gRecaptchaResponse', function () {
            $scope.expired = false;
        });

        $scope.expiredCallback = function expiredCallback() {
            $scope.expired = true;
        };

        $scope.signup = signup;

        // initialize your users data
        (function () {

            $rootScope.title = "Sign up";

        })();

        function signup() {

            if ($.trim($scope.gRecaptchaResponse).length === 0) {

                $rootScope.error = "The captcha is required and can't be empty!";

                return;
            }

            if ($scope.expired == true) {

                $rootScope.error = "The captcha is not valid";

                return;
            }

            accountService.signup($scope.registrationData).then(function (response) {

                $rootScope.message = "An email has been sent to your account.Please view the email and confirm your account to complete the registration process.";

                $scope.registrationData = null;
                $scope.gRecaptchaResponse = "";

                utilityService.redirectTo("login");
            }, function (response) {
                $rootScope.error = utilityService.throwErrors(response);
            });
        }

    }

})();
