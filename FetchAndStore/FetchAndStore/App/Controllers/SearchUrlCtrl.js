app.controller("SearchUrlCtrl", function ($scope, $http) {
    
    //set the varibles to empty
    $scope.url = "";
    $scope.HttpMethod = "";

    //Function called from action from DOM
    $scope.HttpFetcher = function (    ) {

        //Duration of respose



        //call to url based on http method requested 
        $http({ method: $scope.HttpMethod, url: $scope.url, cache: $templateCache }).
        then(function (response) {
            $scope.status = response.status;
            $scope.data = response.data;
        }, function (response) {
            $scope.data = response.data || 'Request failed';
            $scope.status = response.status;
        });
    };
    
});
