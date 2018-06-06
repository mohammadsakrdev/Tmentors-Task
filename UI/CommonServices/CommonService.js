(function () {
    'use strict';

    angular.module('CommonService', ['ngResource'])
        .constant('appSettings', {
            serverPath: 'http://localhost:62986/'
        })
})();