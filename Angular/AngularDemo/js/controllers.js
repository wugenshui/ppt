// 控制器

// 自定义指令
app.controller('directiveController', function ($scope, $timeout) {
    $scope.loading = true;
    $timeout(function () {
        $scope.loading = false;
        $scope.msg = "加载完成";
    }, 1500);
});
// 服务
app.controller('serviceController', function ($scope, $interval, $timeout, UrlService) {
    //$scope.count = 5;
    //$scope.loading = true;
    //$scope.loadingText = "加载网址...";
    //var interval = $interval(function () {
    //    $scope.count--;
    //    if ($scope.count <= 0) {
    //        $scope.loading = false;
    //        $scope.currentUrl = "当前网址：" + UrlService.getUrl();
    //        $interval.cancel(interval);
    //    };
    //}, 1000);
    $timeout(function () {
        $scope.currentUrl = "当前网址：" + UrlService.getUrl();
    }, 5500);
});
// 三级联动
app.controller("optionController", ["$scope", "$http", function ($scope, $http) {
    $http.get("../js/data/citys.json")
        .success(function (response) {
            $scope.data = response;
        })
        .error(function () {
            alert("请求异常！");
        });
    $scope.provinceChange = function () {
        //$scope.selectedCity = null;
        //$scope.selectedCounty = null;
    };
    $scope.click = function () {

    };
}]);
// 用户列表
app.controller('userListController', function ($rootScope, $scope, $location, $modal, UserService) {
    getData();
    // 编辑or新增
    $scope.Edit = function (isEdit, user) {
        // 编辑模式or新增模式
        var modalInstance = $modal.open({
            templateUrl: 'tpls/UserEdit.html',
            controller: 'userEditController',
            backdrop: "static",
            resolve: {
                currentUserIndex: function () {
                    if (user) {
                        return user.ID;
                    }
                },
                isEdit: function () {
                    return isEdit;
                }
            }
        });

        modalInstance.result.then(function () {   // close回调方法
            getData();
        }, function (reason) {  // dismiss回调方法
            console.log(reason);
        });
    };
    // 详情
    $scope.Detail = function (user) {
        // 跳转至详情页
        $location.path("/UserDetail/" + user.ID);
    };
    // 删除
    $scope.Delete = function (user) {
        if (confirm("你确定要删除吗？")) {
            UserService.del(user.ID)
                .then(getData);
        }
    };
    // 获取列表数据
    function getData() {
        UserService.userList().success(function (response) {
            $scope.users = response;
        });
    }
});
// 用户详情
app.controller("userDetailController", function ($scope, $http, $rootScope, $stateParams, UserService) {
    var id = $stateParams.userId;
    if (id) {
        UserService.userById(id).success(function (response) {
            $scope.currentUser = response;
        });
    }
});
// 编辑用户
app.controller('userEditController', function ($scope, $rootScope, $modalInstance, UserService, currentUserIndex, isEdit) {
    // 编辑模式or新增模式
    if (isEdit) {
        $scope.title = "编辑用户";
        UserService.userById(currentUserIndex).success(function (response) {
            $scope.currentUser = response;
        });
        $scope.save = function () {
            UserService.edit($scope.currentUser)
                .then(function () {
                    $modalInstance.close();
                });
        };
    } else {
        $scope.title = "新增用户";
        $scope.currentUser = {};
        $scope.save = function () {
            UserService.add($scope.currentUser)
                .then(function () {
                    $modalInstance.close();
                });
        };
    }
    // 取消
    $scope.cancel = function () {
        $modalInstance.dismiss('cancer');
    };
});