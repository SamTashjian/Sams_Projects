var myApp = angular.module('friendsApp', ['ngRoute']);

myApp.factory('friendsFactory',
    function($http) {
        //create new object
        var webAPIProvider = {};

        var url = '/api/Friends';

        //add a get request to the object
        webAPIProvider.getFriends = function() {
            return $http.get(url);
        };

        //add a post request to the object
        webAPIProvider.saveFriend = function(friend) {
            return $http.post(url, friend);
        };

        //the object is ready to use, return it to whatever controller needs it
        return webAPIProvider;
    });

myApp.config(function($routeProvider) {
    $routeProvider
        .when('/Routes',
        {
            controller: "friendsController",
            templateUrl: '/AngularViews/FriendsList.html'
        })
        .when('/AddFriend',
        {
            controller: 'AddFriendController',
            templateUrl: '/AngularViews/Addfriend.html'
        })
        .otherwise({ redirectTo: '/Routes' });
});

myApp.controller('FriendsController',
    function($scope, friendsFactory) {
        friendsFactory.getFriends()
            .success(function(data) {
                $scope.friends = data;
            })
            .error(function(data, status) {
                alert("oh crap! status: " + status);
            });
    });

myApp.controller('AddFriendController', function($scope, $location, friendsFactory) {
    $scope.friends = {};

    $scope.save = function() {
        friendsFactory.saveFriend($scope.friend)
            .success(function() {
                $location.path('/Routes');
            })
            .error(function(data, status) {
                alert("oh crap! status: " + status);
            });
    }
})