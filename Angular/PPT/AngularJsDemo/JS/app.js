// 入口
var animateApp = angular.module('animateApp', ['ngRoute', 'ngAnimate']);

// 路由配置
animateApp.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'page-home.html',
            controller: 'mainController',
        })
        .when('/about', {
            templateUrl: 'page-about.html',
            controller: 'aboutController'
        })
        .when('/contact', {
            templateUrl: 'page-contact.html',
            controller: 'contactController'
        })
        .otherwise({
            template: '404,您访问的页面不存在!'
        });
});

animateApp.controller('mainController', function($scope) {
    $scope.pageClass = 'page-home';
});

animateApp.controller('aboutController', function($scope) {
    $scope.pageClass = 'page-about';
});

animateApp.controller('contactController', function($scope) {
    $scope.pageClass = 'page-contact';
});