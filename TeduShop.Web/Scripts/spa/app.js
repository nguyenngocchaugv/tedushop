/// <reference path="../plugins/angular/angular.js" />

//Create the module
var myApp = angular.module('myModule', []);

//Creating the controller and registering with the module all done.
myApp.controller("SchoolController", SchoolController);
myApp.controller("StudentController", StudentController);
myApp.controller("TeacherController", TeacherController);

//myApp.$inject = ['$scope'];
//declare
function SchoolController($scope) {
    $scope.message = "This is my message from School";
}

function StudentController($scope) {
    $scope.message = "This is my message from Student ";
}

function TeacherController($scope) {
    $scope.message = "This is my message from Teacher";
}