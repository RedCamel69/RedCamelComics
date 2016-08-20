(
function () {
   
    angular.module("redCamelComics").controller('ArtistController', ['ArtistManager', function (ArtistManager) {

        var vm = this;

        //getArtists();


        vm.getArtists = function getArtists() {

            ArtistManager.getArtists().then(function (response) {
                vm.artists = response.data.$values;
            });
        };

    }]);

}
());