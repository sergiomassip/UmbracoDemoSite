
angular.module("umbraco").controller("Example.CharLimitControlller", function ($scope) {

    $scope.limitchars = function () {
        var limit = 30;
        if ($scope.model.value.length > limit) {
            $scope.info = 'You can not write more than' + limit + 'characters';
            $scope.model.value = $scope.model.value.substr(0, limit);
        } else {

            $scope.info = 'You have ' + (limit - $scope.model.value.length) + ' characters left';
        }
    };
    //alert("Hello World");
});