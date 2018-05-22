(function () {

    "use strict";

    var app = angular.module("app");

    //factories
    app.factory("tenantService", tenantSrvc);

    //injections
    tenantSrvc.$inject = ["$q", "$http", "localStorageService", "utility"];

    function tenantSrvc($q, $http, localStorageService, utility) {

        var serviceFactory = {};

        serviceFactory.list = list;
        serviceFactory.add = add;
        serviceFactory.edit = edit;
        serviceFactory.details = details;
        serviceFactory.email = email;
        serviceFactory.remove = remove;
        serviceFactory.removeFile = removeFile;
        serviceFactory.removeTenant = removeTenant;

        return serviceFactory;

        function list(page, search) {

            return $http.get(utility.baseAddress + "/api/tenant/list?page=" + page + "&search=" + search).then(function (response) {
                return response;
            });
        }

        function add(tenantData) {

            return $http.post(utility.baseAddress + "/api/tenant/add", tenantData).then(function (response) {
                return response;
            });
        }

        function edit(tenantData) {

            return $http.put(utility.baseAddress + "/api/tenant/edit", tenantData).then(function (response) {
                return response;
            });
        }

        function details(id) {

            return $http.get(utility.baseAddress + "/api/tenant/details/" + id).then(function (response) {
                return response;
            });
        }

        function remove(id) {

            return $http.delete(utility.baseAddress + "/api/tenant/remove/" + id).then(function (response) {
                return response;
            });
        }

        function email(tenantData) {

            return $http.post(utility.baseAddress + "/api/tenant/send-email", tenantData).then(function (response) {
                return response;
            });
        }

        function removeFile(id) {

            return $http.delete(utility.baseAddress + "/api/tenant/remove-file/" + id).then(function (response) {
                return response;
            });
        }

        function removeTenant(id) {

            return $http.delete(utility.baseAddress + "/api/tenant/remove-tenant/" + id).then(function (response) {
                return response;
            });
        }
    }

})();

