(
function () {
   
    angular.module("RedCamelComicsApp").controller('ConventionsearchController', ['ConventionManager', function (ConventionManager) {

        var vm = this;

        vm.conventionsScotland = false;
        vm.conventionsEngland = false;
        vm.conventionsWales = false;
        vm.conventionsIreland = false;
        vm.conventionsAll = false;

        vm.getConventions = function getConventions(location) {

            setCountryFlag(location);

            ConventionManager.getConventions(location).then(function (response) {
                vm.conventions = response.data.$values;

                //AutoComplete.InitMap(parseFloat(vm.shops[0].Latitude), parseFloat(vm.shops[0].Longitude), vm.shops);
            });
        };

        function setCountryFlag(location) {

            if (location !== undefined)
                location = location.toUpperCase();

            switch (location) {
                case "ENGLAND":
                    vm.conventionsScotland = false;
                    vm.conventionsEngland = true;
                    vm.conventionsWales = false;
                    vm.conventionsIreland = false;
                    vm.conventionsAll = false;
                    break;
                case "WALES":
                    vm.conventionsScotland = false;
                    vm.conventionsEngland = false;
                    vm.conventionsWales = true;
                    vm.conventionsIreland = false;
                    vm.conventionsAll = false;
                    break;

                case "SCOTLAND":
                    vm.conventionsScotland = true;
                    vm.conventionsEngland = false;
                    vm.conventionsWales = false;
                    vm.conventionsIreland = false;
                    vm.conventionsAll = false;
                    break;

                case "IRELAND":
                    vm.conventionsScotland = false;
                    vm.conventionsEngland = false;
                    vm.conventionsWales = false;
                    vm.conventionsIreland = true;
                    vm.conventionsAll = false;
                    break;

                default:
                    vm.conventionsScotland = false;
                    vm.conventionsEngland = false;
                    vm.conventionsWales = false;
                    vm.conventionsIreland = false;
                    vm.conventionsAll = true;
            }
        }

    }]);

}
());