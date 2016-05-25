/// <reference path="../plugins/angular/angular.js" />

//Create the module
var myApp = angular.module('myModule', []);

//Creating the controller and registering with the module all done.
myApp.controller("SchoolController", SchoolController);
myApp.service('Validator', Validator);
//myApp.controller("StudentController", StudentController);
//myApp.controller("TeacherController", TeacherController);

////myApp.$inject = ['$scope'];
////declare


//function StudentController($scope) {
//    $scope.message = "This is my message from Student ";
//}

//function TeacherController($scope) {
//    $scope.message = "This is my message from Teacher";
//}

SchoolController.$inject = ['$scope', 'Validator'];

function SchoolController($scope, Validator) {
    $scope.checkNumber = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function Validator($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return 'This is even';
        }
        else
            return 'This is odd';
    }
}