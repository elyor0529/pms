(function () {

    "use strict";

    //defining angularjs module
    var app = angular.module("app", ["ui.router", "LocalStorageModule", "ngCookies", "angular-loading-bar", "noCAPTCHA", 'jcs-autoValidate', 'textAngular', 'ngFileUpload']);

    //global service
    app.constant("utility", {
        baseAddress: "http://localhost:19201",
        recaptchaKey: "6LeVCAUTAAAAACfpl7XVHRFa2DxNWUi7wPzxI5Fd"
    });

    //manual bootstrap
    app.init = function () {
        angular.bootstrap(document, ["app"]);
    };

    //config 
    app.config(["$locationProvider", "$httpProvider", "$stateProvider", "$urlRouterProvider", "noCAPTCHAProvider", "utility", function ($locationProvider, $httpProvider, $stateProvider, $urlRouterProvider, noCaptchaProvider, utility) {

        //http provider. 
        $httpProvider.interceptors.push("authInterceptorService");

        //captcha
        noCaptchaProvider.setSiteKey(utility.recaptchaKey);

        //default url
        $urlRouterProvider.otherwise("/home");

        //states
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl: "../app/views/home/index.html",
                controller: "homeController",
                anonymous: true
            })
             .state("cookieuse", {
                 url: "/cookieuse",
                 templateUrl: "../app/views/home/cookieuse.html",
                 controller: "cookieuseController",
                 anonymous: true
             })
             .state("privacypolicy", {
                 url: "/privacypolicy",
                 templateUrl: "../app/views/home/privacypolicy.html",
                 controller: "privacypolicyController",
                 anonymous: true
             })
             .state("termsofservice", {
                 url: "/termsofservice",
                 templateUrl: "../app/views/home/termsofservice.html",
                 controller: "termsofserviceController",
                 anonymous: true
             })
            .state("profile", {
                url: "/profile",
                templateUrl: "../app/views/account/profile.html",
                controller: "profileController",
                authenticated: true
            })
            .state("login", {
                url: "/login",
                templateUrl: "../app/views/account/login.html",
                controller: "loginController",
                anonymous: true
            })
            .state("signup", {
                url: "/signup",
                templateUrl: "../app/views/account/signup.html",
                controller: "signupController",
                anonymous: true
            })
             .state("confirmemail", {
                 url: "/confirmemail?{email}&{token}",
                 templateUrl: "../app/views/account/confirmemail.html",
                 controller: "confirmemailController",
                 anonymous: true
             })
             .state("forgotpassword", {
                 url: "/forgotpassword",
                 templateUrl: "../app/views/account/forgotpassword.html",
                 controller: "forgotpasswordController",
                 anonymous: true
             })
            .state("resetpassword", {
                url: "/resetpassword?{token}",
                templateUrl: "../app/views/account/resetpassword.html",
                controller: "resetpasswordController",
                anonymous: true
            })
            .state("verificationemail", {
                url: "/verificationemail?{email}",
                templateUrl: "../app/views/account/verificationemail.html",
                controller: "verificationemailController",
                anonymous: true
            })
            .state("tenantlist", {
                url: "/tenant/list?{page:int}&{search}",
                templateUrl: "../app/views/tenant/list.html",
                controller: "tenantlistController",
                authenticated: true,
                params: {
                    page: 1,
                    search: ""
                }
            })
            .state("tenantadd", {
                url: "/tenant/add",
                templateUrl: "../app/views/tenant/add.html",
                controller: "tenantaddController",
                authenticated: true
            })
            .state("tenantedit", {
                url: "/tenant/edit?{id:int}",
                templateUrl: "../app/views/tenant/edit.html",
                controller: "tenanteditController",
                authenticated: true
            })
           .state("tenantremove", {
               url: "/tenant/remove?{id:int}",
               templateUrl: "../app/views/tenant/remove.html",
               controller: "tenantremoveController",
               authenticated: true
           })
            .state("tenantemail", {
                url: "/tenant/email?{id:int}",
                templateUrl: "../app/views/tenant/email.html",
                controller: "tenantemailController",
                authenticated: true
            })
            .state("propertylist", {
                url: "/property/list",
                templateUrl: "../app/views/property/list.html",
                controller: "propertylistController",
                authenticated: true
            });

    }]);

    app.run(["$rootScope", "$location", "utility", "accountService", function ($rootScope, $location, utility, accountService) {

        $rootScope.pageLoaging = false;

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {

            $rootScope.pageLoaging = true;
            if (!toState.anonymous) {
                if (toState.authenticated && !accountService.authentication.isAuth)
                    $location.path("/login");
            }

            console.warn('$stateChangeStart to ' + toState.to + '- fired when the transition begins. toState,toParams : \n', toState, toParams);
        });
        $rootScope.$on('$stateChangeError', function (event, toState, toParams, fromState, fromParams) {

            console.error('$stateChangeError - fired when an error occurs during transition.', arguments);
        });
        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {

            $rootScope.pageLoaging = false;

            console.log('$stateChangeSuccess to ' + toState.name + '- fired once the state transition is complete.');
        });
        $rootScope.$on('$viewContentLoading', function (event, viewConfig) {

            console.log('$viewContentLoading - view begins loading - dom not rendered', viewConfig);
        });
        $rootScope.$on('$viewContentLoaded', function (event) {

            $rootScope.projectTitle = utility.projectTitle;
            $rootScope.releaseYear = utility.releaseYear;
            $rootScope.buildVersion = utility.buildVersion;

            $rootScope.error = null;
            $rootScope.message = null;

            console.log('$viewContentLoaded - fired after dom rendered', event);
        });
        $rootScope.$on('$stateNotFound', function (event, unfoundState, fromState, fromParams) {

            console.warn('$stateNotFound ' + unfoundState.to + '  - fired when a state cannot be found by its name.', unfoundState, fromState, fromParams);
        });

        $rootScope.authentication = accountService.fillAuthData();
        $rootScope.logOut = accountService.logOut;

    }]);

})();