// 自定义服务

// 获取当前URL路径
app.service('UrlService', function ($location) {
    this.getUrl = function () {
        return decodeURI($location.absUrl());
    };
});

app.service('UserService', function ($rootScope, $http) {
    return {
        add: function (user) {
            return $http.post("../server/Server.aspx?type=userAdd", user);
        },
        del: function (id) {
            return $http.get("../server/Server.aspx?type=userDel&id=" + id);
        },
        edit: function (user) {
            return $http.post("../server/Server.aspx?type=userEdit", user);
        },
        userList: function () {
            return $http.get("../server/Server.aspx?type=userList");
        },
        userById: function (id) {
            return $http.get("../server/Server.aspx?type=userById&id=" + id);
        },
    }
});
