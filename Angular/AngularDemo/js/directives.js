// 自定义指令

// Ajax-Loading
app.directive('loading', function ($animate) {
    return {
        restrict: 'AE',
        replace: true,
        scope: true,
        template: '<div class="loading" name="loading"><img alt="Loading" src="img/ajax-loader.gif" />{{ loadingText || "加载中,请稍后..." }}</div>',
        link: function (scope, element, attr) {
            scope.$watch('loading', function (value) {
                if (value) {
                    element.css("display", "block");
                }
                else {
                    element.css("display", "none");
                }
            });
            // 禁用动画
            $animate.enabled(false, element);
        }
    }
});

// progress-bar
app.directive('progressBar', function ($timeout) {
    return {
        restrict: 'AE',
        replace: true,
        scope: {
            loadtime: "@"
        },
        template: '<div class="progress progress-striped active"><div class="progress-bar progress-bar-info" style="width:0%"></div></div> ',
        link: function (scope, element, attr) {
            var timeLimit = 50;     // 计算时间
            var current = 0;     // 当前时间
            var progressBarGrow = function () {
                current += timeLimit;
                var a = current / scope.loadtime * 100;
                if (a <= 100) {
                    element.children().css("width", a + "%");
                    $timeout(progressBarGrow, timeLimit);
                } else {
                    element.css("display", "none");
                }
            };
            progressBarGrow();
        }
    }
});