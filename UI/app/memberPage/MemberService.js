(function(){
    'use strict';

    angular.module('CommonService')
        .factory('memberService', ['$resource', 'appSettings', memberService])
    function memberService($resource, appSettings) {
        return {
            getAllMembers: $resource(appSettings.serverPath + 'api/getAllMembers'),
            getAllProjects: $resource(appSettings.serverPath + 'api/getAllProjects'),
            getMembersByProject: $resource(appSettings.serverPath + 'api/getMembersByProject/:id'),
            createMember: $resource(appSettings.serverPath + 'api/member/create'),
            updateMember: $resource(appSettings.serverPath + 'api/member/update'),
            deleteMember: $resource(appSettings.serverPath + 'api/member/delete'),
        }
    }
})();