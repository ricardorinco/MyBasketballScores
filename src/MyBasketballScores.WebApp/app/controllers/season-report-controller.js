app.controller('SeasonReportController', function($scope, myBasketballScoresWebApi) {
    $scope.title = 'Resultados';

    $scope.alertMessage = '';
    $scope.errorMessage = '';
    
    $scope.seasonReportResponse = {};

    loadReport();

    function loadReport() {
        myBasketballScoresWebApi.getSeasonReport().then(
            function(response) {
                $scope.seasonReportResponse = response.data;
                
                if (response.data.totalGamesPlayed === 0) {
                    $scope.alertMessage = 'Não foram encontrados registros de jogos até o momentos.';
                }
            },
            function(error) {
                $scope.errorMessage = 'Não foi possível carregar os registros.';
                console.error('Error:', error);
            }
        );
    }
});
