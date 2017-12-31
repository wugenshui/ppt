// js入口,定义模块
var app = angular.module('demoApp', ['ngAnimate', 'ui.router', 'ui.bootstrap']);
// 路由配置
app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/Index');
    $stateProvider
        .state('Index', {
            url: '/Index',
            templateUrl: 'tpls/UserList.html',
            controller: 'userListController'
        })
        .state('NgOptions', {
            url: '/NgOptions',
            templateUrl: 'tpls/NgOptions.html',
            controller: 'optionController'
        })
        .state('Directive', {
            url: '/Directive',
            templateUrl: 'tpls/Directive.html',
            controller: 'directiveController'
        })
        .state('服务', {
            url: '/服务',
            templateUrl: 'tpls/服务.html',
            controller: 'serviceController'
        })
        .state('UserDetail', {
            url: '/UserDetail/:userId',
            templateUrl: 'tpls/UserDetail.html',
            controller: 'userDetailController'
        })
});
// 禁用缓存：模板页在刷新页面后仍会缓存
app.config(['$httpProvider', function ($httpProvider) {
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    //disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    // extra
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
}]);
// 配置post请求
app.config(function ($httpProvider) {
    $httpProvider.defaults.headers.put['Content-Type'] = 'application/x-www-form-urlencoded';
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
    $httpProvider.defaults.transformRequest = [function (data) {
        /**
         * The workhorse; converts an object to x-www-form-urlencoded serialization.
         * @param {Object} obj
         * @return {String}
         */
        var param = function (obj) {
            var query = '', name, value, fullSubName, subName, subValue, innerObj, i;

            for (name in obj) {
                value = obj[name];

                if (value instanceof Array) {
                    for (i = 0; i < value.length; ++i) {
                        subValue = value[i];
                        fullSubName = name + '[' + i + ']';
                        innerObj = {};
                        innerObj[fullSubName] = subValue;
                        query += param(innerObj) + '&';
                    }
                }
                else if (value instanceof Object) {
                    for (subName in value) {
                        subValue = value[subName];
                        fullSubName = name + '[' + subName + ']';
                        innerObj = {};
                        innerObj[fullSubName] = subValue;
                        query += param(innerObj) + '&';
                    }
                }
                else if (value !== undefined && value !== null)
                    query += encodeURIComponent(name) + '=' + encodeURIComponent(value) + '&';
            }

            return query.length ? query.substr(0, query.length - 1) : query;
        };

        return angular.isObject(data) && String(data) !== '[object File]'
                ? param(data)
                : data;
    }];
    //$httpProvider.defaults.transformRequest = [function (data) {
    //    return $.param(data);
    //}];
});
// 请求拦截器
app.factory('myInterceptor', function () {
    var myInterceptor = {
        request: function (config) {
            config.requestTimestamp = new Date().getTime();
            return config;
        }
    };

    return myInterceptor;
});
app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('myInterceptor');
}]);

// 应用初始化
app.run(function ($rootScope, $http) {

});
