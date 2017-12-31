// filter:联系方式
app.filter('contactTypeFilter', function () {
    var types = ["手机", "电话", "邮箱"];
    return function (input) {
        return types[input];
    };
});
// 性别
app.filter('filterSex', function () {
    var types = ["男", "女"];
    return function (input) {
        return types[input];
    };
});