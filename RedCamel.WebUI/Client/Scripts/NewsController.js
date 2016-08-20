(
function () {
   
    angular.module("RedCamelComicsApp").controller('NewsController', ['LatestNewsManager', function (LatestNewsManager) {

        var vm = this;

        //getArtists();


        vm.getNews = function getNews() {

            LatestNewsManager.getNews().then(function (response) {
                vm.news = response.data.$values[0].Posts.$values;
            });
        };

    }]);
    
}
());