app.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'HomeController',
            templateUrl: 'app/views/home.html'
        })
        .when('/season-report', {
            controller: 'SeasonReportController',
            templateUrl: 'app/views/season-report.html'
        })
        .otherwise({ redirectTo: '/' });
});
