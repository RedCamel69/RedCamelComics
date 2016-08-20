(
function (app) {
    var ListController = function ($scope, $http) {
        $http.get("/api/api_Product")
            .success(function (data) {
                $scope.comics = data;
            });

    };

    ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);


}
(angular.module("redCamelComics")));