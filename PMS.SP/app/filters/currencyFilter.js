(function () {

    "use strict";

    var app = angular.module("app");

    app.filter('currencyFilter', function () {
        return function (value) {
            return value.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');

        };
    });

})();

