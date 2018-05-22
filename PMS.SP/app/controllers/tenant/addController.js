(function () {

    "use strict";

    var app = angular.module("app");

    //controllers
    app.controller("tenantaddController", tenantaddCtrl);

    //injections
    tenantaddCtrl.$inject = ["$rootScope", "$scope", "$window", "tenantService", "propertyService", "paymentFrequencyService", "paymentTypeService", "leaseTypeService", "fileService", "bootstrap3ElementModifier", "utilityService"];

    function tenantaddCtrl($rootScope, $scope, $window, tenantService, propertyService, paymentFrequencyService, paymentTypeService, leaseTypeService, fileService, bootstrap3ElementModifier, utilityService) {

        bootstrap3ElementModifier.enableValidationStateIcons(false);
        $scope.delinquents = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        //a simple model to bind to and send to the server
        $scope.tenantData = {
            property: {
                id: 0
            },
            tenants: [{
                company: "",
                firstName: "",
                lastName: "",
                dateOfBirh: "",
                cellPhone: "",
                homePhone: "",
                email: ""
            }],
            lease: {
                startDate: "",
                endDate: "",
                leaseTypeId: 0,
                deposit: 0,
                delinquentAfter: 1,
                moveInDate: "",
                moveOutDate: "",
                rent: 0,
                paymentFrequencyId: 0,
                paymentTypeId: 0,
                notes: "",
                petsFlag: false,
                smokingFlag: false
            },
            files: []
        };

        $scope.files = [];

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

        $scope.addTenant = function () {
            var tenant = {
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

        $scope.add = add;

        $(document).on('change', '.btn-file :file', function () {
            var input = $(this),
                numFiles = input.get(0).files ? input.get(0).files.length : 1,
                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');

            input.trigger('fileselect', [numFiles, label]);
        });
          
        // initialize your users data
        (function () {

            $rootScope.title = "Add tenants";

            $scope.tenantData.lease.delinquentAfter = $scope.delinquents[0];

            propertyService.list().then(function (response) {

                $scope.properties = response.data;
                $scope.tenantData.property.id = $scope.properties[0].id;

            })
                           .catch(function (response) {
                               $rootScope.error = utilityService.throwErrors(response);
                           });

            paymentFrequencyService.list().then(function (response) {

                $scope.paymentFrequencies = response.data;
                $scope.tenantData.lease.paymentFrequencyId = $scope.paymentFrequencies[0].id;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            paymentTypeService.list().then(function (response) {

                $scope.paymentTypes = response.data;
                $scope.tenantData.lease.paymentTypeId = $scope.paymentTypes[0].id;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });

            leaseTypeService.list().then(function (response) {

                $scope.leaseTypes = response.data;
                $scope.tenantData.lease.leaseTypeId = $scope.leaseTypes[0].id;

            })
                .catch(function (response) {
                    $rootScope.error = utilityService.throwErrors(response);
                });


        })();

        function add() {

            if ($scope.files.length > 0) {

                fileService.upload($scope.files)
                    .then(function (files) {

                        angular.forEach(files, function (file) {
                            $scope.tenantData.files.push({
                                path: file
                            });
                        });

                        doPost();

                    }, function (reason) {

                        // Error callback where reason is the value of the first rejected promise
                        console.error(reason);
                    });
            } else {
                doPost();
            }

            function doPost() {

                tenantService.add($scope.tenantData).then(function (response) {
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
