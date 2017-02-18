/// <reference path="../Scripts/angular.js" />
/// <reference path="../Scripts/angular-mocks.js" />


var BindingCode = function ($scope,Factory,UtilityObject)
{
    //$scope.cname = "Vaibhav";
    //$scope.cid = "1001";
    //$scope.CustomerBackgroundColor = "Blue";
    //$scope.Amount = "100";

    $scope.cust = Factory.CreateCustObject(1); //Dependency Injection
    $scope.util = UtilityObject;
    
   

    $scope.$watch("cust.Amount", function () {
        if ($scope.cust.Amount < 100) {
            $scope.cust.CustomerBackgroundColor = "Red";
        }
        else if ($scope.cust.Amount > 100) {
            $scope.cust.CustomerBackgroundColor = "Green";
        }
        else {
            $scope.cust.CustomerBackgroundColor = "White";
        }
    });

    $scope.Submit = function () {
        if ($scope.cust.cname.length == 0) {
            alert("Name is Blank");
        }
        else {
            alert("Good Data");
        }
    };

};


