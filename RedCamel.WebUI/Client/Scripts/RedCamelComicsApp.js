var RedCamelComicsApp = angular.module('RedCamelComicsApp', ['ngRoute']);

var vm = this;

RedCamelComicsApp.controller('LandingPageController', LandingPageController);



var configFunction = function ($routeProvider) {

    $routeProvider.

        when('/routeOne', {

            templateUrl: 'Home/Locator'

        })

        .when('/routeTwo/:count', {

            templateUrl: function (params) { return 'api/locator/greet?count=' + params.count; }

        })

        .when('/routeThree', {

            templateUrl: 'routesDemo/three'

        });

}

configFunction.$inject = ['$routeProvider'];



RedCamelComicsApp.config(configFunction);


//RedCamelComicsApp.controller('ShopsearchController', ShopsearchController);