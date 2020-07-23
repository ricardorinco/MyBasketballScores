app.controller('AddNewGameController', function($scope, myBasketballScoresWebApi) {
    $scope.title = 'Lançar Pontos';
    
    $scope.successMessage = '';
    $scope.errorMessages = [];

    $scope.scoreRequest = {};

    buildForm();

    $scope.addScores = function() {
        myBasketballScoresWebApi.addNewGame($scope.scoreRequest).then(
            function(scoreResponse){               
                buildForm();

                if (scoreResponse.data.notifications.length > 0) {
                    scoreResponse.data.notifications.forEach((notification) => {
                        $scope.errorMessages.push(notification.message);
                    });
                    
                } else{
                    $scope.successMessage = 'Lançamento de pontos realizado com sucesso.';
                }
            },
            function(error) {
                if (error.data.notifications.length > 0) {
                    error.data.notifications.forEach((notification) => {
                        $scope.errorMessages.push(`${notification.property}: ${notification.message}.`);
                    });
                    
                } else{
                    $scope.errorMessages.push('Ocorreu um erro ao lançar os pontos da partida.')
                    console.error('Error:', error);
                }
            }
        );
    };

    function buildForm() {
        $scope.scoreRequest= {};

        $scope.scoreRequest.gameDate = new Date();
        $scope.scoreRequest.totalScore = 0;
    }
});