(function () {
    //console.log("startHome");
    var HomeController = function ($scope) {
        $scope.Message = "Welcome to the Project Tracking Website";
    };

    app.controller("HomeController", HomeController);
    //console.log("endHome");

}());

//app.controller('HomeController', function ($scope) {
//    $scope.Message = "Welcome to the Project Tracking Website";
//});