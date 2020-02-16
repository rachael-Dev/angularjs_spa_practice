(function (app) {
    'use strict';

    app.controller('booksCtrl', booksCtrl); 

    //, 'ui.bootstrap', 'ngAnimate'
    booksCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', '$rootScope'
        , '$modal', '$timeout', '$window', '$document'];

    function booksCtrl($scope, $location, $routeParams, apiService, notificationService, $rootScope, $modal, $timeout, $window, $document) {
        $scope.pageClass = 'page-books';
        $scope.loadingbooks = true;
        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.bookData = {            
            Page: 0,
            Count: 0,
            TotalPages: 0,
            TotalCount: 0,
            Items: null
        };
            
        $scope.seachCriteria = {
            filterBooks: ''
        };
        //$scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.search = function (filterBooks, page) {
            var config = {
                params: {
                    page: page,
                    pageSize: 30,
                    filter: filterBooks,
                }
            };
            apiService.get('/api/BookStore/', config,
           booksLoadCompleted,
           booksLoadFailed);
        };

        function search(filterBooks, page) {

            if ($scope.filterbooks == null || $.trim($scope.filterbooks).length == 0)
            {
                notificationService.displayError("Search text is mandatory");
                return false;
            }

            console.log('input filterBooks ', $scope.seachCriteria.filterBooks, filterBooks);
            //page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: filterBooks,
                }
            };

            //$scope.loadingbooks = true;
            apiService.get('/api/BookStore/', config,
            booksLoadCompleted,
            booksLoadFailed);
        }

        function booksLoadCompleted(result) {
           $scope.bookData = result.data;            
            $scope.loadingbooks = false;

            //if ($scope.seachCriteria.filterbooks && $scope.seachCriteria.filterbooks.length) {   }
                notificationService.displayInfo(result.data.Items.length + ' books found');         
                console.log('booksLoadCompleted', result, $scope.bookData);             
        }

        function booksLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.seachCriteria.filterbooks = '';
            //search();
            $scope.bookData = {
                Page: 0,
                Count: 0,
                TotalPages: 0,
                TotalCount: 0,
                Items: null
            };
        }

        //$scope.search();

        function IfEnterKeyWasPressed(event, successCallBack, errorCallBack) {            
            var keyCode = event.which || event.keyCode;
            if (keyCode === 13) {
                //console.log("ready to do this ", successCallBack, errorCallBack);
                if (typeof successCallBack == "function") {
                    successCallBack();
                    return false;
                }
            } else {
                //console.log("you trying to type: ", keyCode);
                if (typeof errorCallBack == "function") {
                    errorCallBack();
                    return false;
                }
            }
        };

        $scope.checkIfEnterKeyWasPressed_Books = function ($event) {
            var SuccessCallBack = function () { $scope.search( $scope.seachCriteria.filterBooks); };
            var FailureCallBack = function () { };
            IfEnterKeyWasPressed($event, SuccessCallBack, FailureCallBack);
        };

        $scope.OpenDetailPopup = function (item) {
            $scope.itemDetails = item;
            console.log("item ", item)
            //$scope.modalInstance_Detail =
                $modal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: '/scripts/figbooks/books/bookdetails.html?rnd=' + $rootScope._JS_VERSIONUMBER,
                controller: 'detailModalController',
                controllerAs: '$scope',                                                
                scope: $scope,
                backdrop: 'static',
                keyboard: false,
                size: '',
                windowClass: 'center-modal detail-popup',
                resolve: {
                    detailId: function () {                        
                        return item;
                        }                    
                    }                
            }).result.then(function ($scope) {
                //clearSearch();
            }, function () {
            });
           
        };

    }

})(angular.module('figBooksApp'));