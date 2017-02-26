/// <reference path="../Scripts/angular.js" />
/// <reference path="../Scripts/angular-mocks.js" />


var BindingCode = function ($scope,Factory,UtilityObject,$http,$q,$sce)
{
    //$scope.cname = "Vaibhav";
    //$scope.cid = "1001";
    //$scope.CustomerBackgroundColor = "Blue";
    //$scope.Amount = "100";


    $scope.successFn = function (response) {
        $scope.lstCust = response.data;
    };

    $scope.failureFn = function (response) {
        // $scope.lstCust = response.data;
        alert("Failure - See Console");
        consol.log(response);
    };

    $scope.notificationFn = function () {
        alert("This is the nofication");
    };

    $scope.cust = Factory.CreateCustObject(1); //Dependency Injection
    $scope.util = UtilityObject;
    $scope.lstCust = [];

    var defer = $q.defer();
    var promise = defer.promise;

    promise.then($scope.successFn, $scope.failureFn, $scope.notificationFn);
   

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
        $scope.div1Value = "";
        if ($scope.cust.cname.length == 0) {
            alert("Name is Blank");
        }
        else
        {
            ///     alert("Good Data");
            //$http.post("http://localhost:50253/api/Customer", $scope.cust)
            //    .then(function (data) {
            //        //alert("success");
            //        $scope.cust = data.data;
            //        console.log(data);
            //        //$scope.cust.cname = "Name Changed";
            //    });

            $http.get("http://localhost:50253/api/Customer")
                .then(function (data) {
                    //alert("success");
                    //$scope.lstCust = data.data;
                    //console.log(data);
                    //$scope.cust.cname = "Name Changed";
                    $scope.div1Value =  $sce.trustAsHtml("<span style='color:green'>Connection Succeeded</span>");

                    defer.resolve(data);
                }, function (failureData) {
                    //alert("Connection Failed.");
                    console.log(failureData);
                    $scope.div1Value = $sce.trustAsHtml("<span style='color:red;text-indent: 50px;'>" + failureData.data.Message + "<br /><br />"
                                        + failureData.data.MessageDetail + "</span>");
     

                });
        }
    };

};


