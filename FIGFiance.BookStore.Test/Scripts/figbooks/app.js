(function () {
    'use strict';

    angular.module('figBooksApp', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/figbooks/books/books.html?rnd=1",
                controller: "booksCtrl"
            })            
            .when("/books", {
                templateUrl: "scripts/figbooks/books/books.html?rnd=1",
                controller: "booksCtrl"
            })            
            .when("/books/:id", {
                templateUrl: "scripts/figbooks/books/bookdetails.html",
                controller: "bookDetailsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .otherwise({ redirectTo: "/" }); 
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
       
        $rootScope._JS_VERSIONUMBER = '20200206.018';

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        //if (!membershipService.isUserLoggedIn()) {
        //    $rootScope.previousState = $location.path();
        //    $location.path('/login');
        //}
    }

})();