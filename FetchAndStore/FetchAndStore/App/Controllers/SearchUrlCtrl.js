app.controller("SearchUrlCtrl", function ($scope, $http) {
    
    //set the varibles to empty
    $scope.url = "";
    $scope.HttpMethod = "";
    $scope.ResponseTime = "";

    //Function called from action from DOM
    $scope.HttpFetcher = function ( methodPicked, urlEntered ) {

        //Duration of respose
        var startTime = Date.now();
        

        //call to url based on http method requested 
        $http({ method: $scope.HttpMethod, url: $scope.url }).
        then(function (response) {
            $scope.ResponseTime = Date.now() - startTime;
            $scope.status = response.status;
            $scope.data = response.data;
        }, function (response) {
            $scope.data = response.data || 'Request failed';
            $scope.status = response.status;
        });
    };
    
});
