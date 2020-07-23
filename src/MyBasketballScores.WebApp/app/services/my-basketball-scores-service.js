angular.module('app').factory('myBasketballScoresWebApi', function ($http, config){
    var addNewGame = function (scoreResponse) {
        const gameDateOffset = scoreResponse.gameDate.getTimezoneOffset();
        let gameDate = new Date(scoreResponse.gameDate.getTime() + (gameDateOffset * 60 * 1000));
        gameDate = gameDate.toISOString().split('T')[0];

        scoreResponse.gameDate = gameDate;

        return $http({
            method: 'POST',
            url: `${config.baseUrl}/score/add`,
            data: scoreResponse
        });
    };

    var getSeasonReport = function () {
        return $http({
            method: 'GET',
            url: `${config.baseUrl}/season-report`
        });
    };

    return{
        addNewGame: addNewGame,
        getSeasonReport: getSeasonReport
    };
});