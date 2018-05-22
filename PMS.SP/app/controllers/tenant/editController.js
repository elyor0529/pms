(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("tenanteditController", tenanteditCtrl);

    //injections
    tenanteditCtrl.$inject = ["$rootScope", "$scope", "$stateParams", "tenantService", "propertyService", "paymentFrequencyService", "paymentTypeService", "leaseTypeService", "utilityService", "fileService", "bootstrap3ElementModifier"];

    function tenanteditCtrl($rootScope, $scope, $stateParams, tenantService, propertyService, paymentFrequencyService, paymentTypeService, leaseTypeService, utilityService, fileService, bootstrap3ElementModifier) {

        bootstrap3ElementModifier.enableValidationStateIcons(false);

        $scope.files = [];

        $scope.downloadUrl = utilityService.getInstance().baseAddress + "/api/file/download";

        $scope.selectFile = function (file) {

            if (file) {

                if (_.find($scope.files, function (f) { return f.name === file.name; })) {
                    $window.alert("This file already exists!");

                    return;
                }

                $scope.files.push(file);
            }
        };

        $scope.removeFile = function (index) {

            $scope.files.splice(index, 1);
        };

        $scope.deleteFile = function (index, id) {

            tenantService.removeFile(id).then(function (response) {

                $scope.tenantData.files.splice(index, 1);

            })
             .catch(function (response) {
                 $rootScope.error = utilityService.throwErrors(response);
             });

        };

        $scope.addTenant = function () {
            var tenant = {
                id: 0,
                company: "",
                firstName: "",
                lastName: "",
                dOB: "",
                cellPhone: "",
                homePhone: "",
                email: ""
            };

            $scope.tenantData.tenants.push(tenant);
        };

        $scope.removeTenant = function (index) {

            $scope.tenantData.tenants.splice(index, 1);
        };

        $scope.deleteTenant = function (index, id) {

            tenantService.removeTenant(id).then(function (response) {

                $scope.removeTenant(index);

            })
             .catch(function (response) {
                 $rootScope.error = utilityService.throwErrors(response);
             });

        };

        $scope.delinquents = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        $scope.edit = edit;

        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
            input.trigger('fileselect', [numFiles, label]);
        });
         
        // initialize your users data
        (function () {

            $rootScope.title = "Edit tenants";

            tenantService.details($stateParams.id).then(function (response) {

                $scope.tenantData = response.data;
            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            propertyService.list().then(function (response) {

                $scope.properties = response.data;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            paymentFrequencyService.list().then(function (response) {

                $scope.paymentFrequencies = response.data;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            paymentTypeService.list().then(function (response) {

                $scope.paymentTypes = response.data;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            leaseTypeService.list().then(function (response) {

                $scope.leaseTypes = response.data;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

        })();

        function edit() {

            if ($scope.files.length > 0) {

                fileService.upload($scope.files)
                    .then(function (files) {

                        angular.forEach(files, function (file) {
                            $scope.tenantData.files.push({
                                path: file
                            });
                        });

                        doPut();

                    }, function (reason) {

                        // Error callback where reason is the value of the first rejected promise
                        console.error(reason);
                    });
            } else {
                doPut();
            }

            function doPut() {

                tenantService.edit($scope.tenantData).then(function (response) {
                    $rootScope.message = "Tenants successfully saved.";

                    utilityService.redirectTo("tenant/list");
                })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });
            }

        }

    }

})();
