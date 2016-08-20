(function ()
{
    angular.module("RedCamelComicsApp")
    .service('ArtistManager', ['$http', function ($http) {


        var apiUrl = "/api/Creator";

        this.getArtists = function () {
            return $http.get(apiUrl);
        };

    }])

    .service('ShopServiceManager', ['$http', function ($http) {


        var apiUrl = "/api/ShopSearch";

        this.getShops = function (location) {
            return $http.get(apiUrl + "?location=" + location);
        };

    }])

    .service('LatestNewsManager', ['$http', function ($http) {


        var apiUrl = "/api/News";

        this.getNews = function (location) {
            return $http.get(apiUrl);
        };

    }])
    .service('ConventionManager', ['$http', function ($http) {


        var apiUrl = "/api/Convention?country=";

        this.getConventions = function (location) {
            return $http.get(apiUrl + location);
        };

    }]);
})();