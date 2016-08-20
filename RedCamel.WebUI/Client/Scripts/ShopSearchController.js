(
function () {
   
    angular.module("RedCamelComicsApp").controller('ShopsearchController', ['ShopServiceManager', function (ShopServiceManager) {

        var vm = this;

        //getArtists();


        vm.getShops = function getShops(location) {

            ShopServiceManager.getShops(location).then(function (response) {
                vm.shops = response.data.$values;

                AutoComplete.InitMap(parseFloat(vm.shops[0].Latitude), parseFloat(vm.shops[0].Longitude), vm.shops);
            });
        };

    }]);

}
());