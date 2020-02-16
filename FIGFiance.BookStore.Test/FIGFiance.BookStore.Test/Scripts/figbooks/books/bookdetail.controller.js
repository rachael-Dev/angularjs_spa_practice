
(function (app) {
    'use strict';

    app.controller('detailModalController', detailModalController); 

    detailModalController.$inject = ['$scope', '$modalInstance', '$timeout', 'apiService', 'notificationService'];

    function detailModalController($scope, $modalInstance, $timeout, apiService, notificationService, detailId) {
        console.log('itemDetails', $scope.itemDetails, detailId);

        $scope.loadBookItem = loadBookItem;
        $scope.ShipBooks = ShipBooks;
        $scope.bookItem = {};
        $scope.shipMethods = [];
        $scope.ship = {selectedOption: ''};

        function ShipBooks() {
            //console.log($scope.ship.selectedOption);
            if (!$scope.ship || !$scope.ship.selectedOption) {
                notificationService.displayError('Please choose one ship option');
                return false;
            } else {
                var model = {
                    DeliveryService: $scope.ship.selectedOption.DeliveryService,
                    DeliveryCost: $scope.ship.selectedOption.DeliveryCost,
                };
                apiService.post('/api/Buy/delivery', model,
                bookingLoadCompleted,
                bookingLoadFailed);
                $scope.closeModal();
            }
        }

        function bookingLoadCompleted(response) {
            notificationService.displayInfo(response.data);
            console.log(response);
        }

        function bookingLoadFailed(response) {
            console.log(response);
            notificationService.displayError(response.data);
        }


        function loadBookItem() {
            if ($scope.itemDetails != null) {
                notificationService.displayInfo('Loading the selected book for ' + $scope.itemDetails.VolumeInfor.Title);
               
                //GetShipMethods();

                apiService.get('/api/ShipCosts/all', null,
                shipcostsLoadCompleted,
                shipcostsLoadFailed);

                apiService.get('/api/BookStore/details/' + $scope.itemDetails.ID, null,
                bookItemLoadCompleted,
                bookItemLoadFailed);
            }else
                notificationService.displayError('Can not loading the selected book ');
        };

        //function GetShipMethods() {
        //    $scope.shipMethods = [];
        //    var shipmd = {

        //    };
        //    $scope.shipMethods.push();
        //}

        function shipcostsLoadCompleted(response) {
            $scope.shipMethods = response.data;
            console.log(response);
        }

        function shipcostsLoadFailed(response) {
            console.log(response);
            notificationService.displayError(response.data);
        }

        function bookItemLoadCompleted(response) {
            $scope.bookItem = response.data;            
            console.log(response);
        }

        function bookItemLoadFailed(response) {
            console.log(response);
            notificationService.displayError(response.data);
        }

        $scope.closeModal = function () {
            $scope.itemDetails = {};
            $modalInstance.dismiss();
        };


        loadBookItem();
    }

})(angular.module('figBooksApp'));