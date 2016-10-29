"use strict";

app.controller("SearchUrlCtrl", function ($scope, $http) {
    
    //set the varibles to empty
    $scope.url = "";
    $scope.HttpMethod = "";
    $scope.ResponseTime = "";

    //Function called from action from DOM
    $scope.HttpFetcher = function ( methodPicked, urlEntered ) {

        //Duration of respose 
        var startTime = Date.now();
        
        //call to url entered based on http method requested 
        $http({ method: $scope.HttpMethod, url: $scope.url }).
        then(function (response) {
            $scope.ResponseTime = (Date.now() - startTime )/1000;
            $scope.status = response.status;
            $scope.data = response.data;
        }, function (response) {
            $scope.data = response.data || 'Request failed';
            $scope.status = response.status;
        });
    };


    //Function to store responses to the database
    $scope.ResponseSave = function () {
        var stringifiedData = JSON.stringify({URL: $scope.url, StatusCode: $scope.status, Method: $scope.HttpMethod, RequestTime: $scope.ResponseTime })
        console.log(stringifiedData);
        $http({
            url: '/api/response',
            method: 'POST',
            
            data: stringifiedData

        }).success(response => {
            console.log(response)
            $scope.ResponseRecall();
        })
        
    };

    //Function to return responses from the database
    $scope.ResponseRecall = function ( ) {
        $http({
            url: '/api/response',
            method: 'GET'
            
        }).success(response => {
            console.log(response)
            $scope.dbResponses = response
        })
    };

    $scope.hideMe = true; // true to hide ,false to show

    $scope.hideIt = function () {
        $scope.hideme = true;
    }

   

    //Function to delete responses from the database
    $scope.databaseResponseViewable =
    $scope.ResponseRemove = function (id) {
        $http({
            url: `/api/response/${id}`,
            method: 'DELETE',
           

        }).success(response => {
            
            $scope.ResponseRecall();
        })



    }
    
});
