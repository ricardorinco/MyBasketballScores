angular.module('app').factory('myBasketballScoresWebApi', function ($http, config){
    var getSeasonReport = function () {
        return $http({
            method: 'GET',
            url: config.baseUrl + '/season-report'
        });
    };

    return{
        getSeasonReport: getSeasonReport
    };
});