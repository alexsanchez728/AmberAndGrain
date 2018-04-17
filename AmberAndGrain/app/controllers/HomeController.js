app.controller("HomeController", ["$scope", "$http",
    function ($scope, $http) {
        $scope.message = "Hello";

        $http.get("/api/recipes").then(function (results) {
            $scope.recipes = results.data;
        })
}]);