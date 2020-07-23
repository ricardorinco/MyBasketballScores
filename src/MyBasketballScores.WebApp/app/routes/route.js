app.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'HomeController',
            templateUrl: '"app/views/home.html'
        })
        .otherwise({ redirectTo: '/' });
});
