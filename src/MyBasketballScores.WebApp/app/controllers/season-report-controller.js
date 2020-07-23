app.controller('SeasonReportController', function($scope, myBasketballScoresWebApi) {
    $scope.title = 'Resultados';

    $scope.alertMessage = '';
    $scope.errorMessage = '';
    
    $scope.seasonReport = {};

    loadReport();

    function loadReport() {
        myBasketballScoresWebApi.getSeasonReport().then(
            function(response) {
                $scope.seasonReport = response.data;
                
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
