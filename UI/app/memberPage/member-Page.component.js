(function () {
	'use strict';

	var app = angular.module('app');
    app.component('memberPage', {
        templateUrl: 'app/memberPage/memberPage.html',
		controllerAs: 'vm',
        controller: ['$resource', 'appSettings', 'memberService', '$scope', 'uiGridConstants', controller]
	});

    function controller( $resource, appSettings, memberService, $scope, uiGridConstants) {
        var vm = this;

        vm.selection = 'All';
        vm.showInsert = true;
        vm.showUpdate = false;

        // get all members
        vm.getAllMembers = function () {
            memberService.getAllMembers.query(
                function (data) {
                    $scope.memberGrid.data = data;
                    for (var i = 0; i < $scope.memberGrid.data.length; i++) {
                        $scope.memberGrid.data[i].fullName = data[i].firstName + ' ' + data[i].lastName
                    }
                });
        }

        vm.getAllMembers();

        // get all projects
        memberService.getAllProjects.query(
            function (data) {
                vm.projects = data;
            });

        // on projects list change
        vm.change = function (data) {
            if (data == 'All') {
                vm.getAllMembers();
            }
            else {
                memberService.getMembersByProject.query({ id: data },
                    function (data) {
                        $scope.memberGrid.data = data;
                        for (var i = 0; i < $scope.memberGrid.data.length; i++) {
                            $scope.memberGrid.data[i].fullName = data[i].firstName + ' ' + data[i].lastName
                        }
                    }
                );

            }
        }


        // addd new member
        vm.addNew = function () {
            $('#modalForDetail').modal('show');

            vm.firstName = "";
            vm.lastName = "";
            vm.title = "";
            vm.selectionModal = 0;

            vm.showInsert = true;
            vm.showUpdate = false;
        }

        //ui grid

        $scope.memberGrid = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: false,
            enableRowSelection: true,
            enablePinning: true,
            enableRowHeaderSelection: false,
            multiSelect: false,
            showGridFooter: true,
            showColumnFooter: true,
            enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
            columnDefs: [
                { name: 'id', enableCellEdit: false, displayName: 'ID', width: '5%', enableFiltering: false},
                { name: 'projectName', enableCellEdit: false, displayName: 'Project Name', width: '20%', enableFiltering: false },
                { name: 'fullName', enableCellEdit: false, displayName: 'Full Name', width: '30%', cellTemplate: '<div class="ui-grid-cell-contents"><a ng-click="grid.appScope.detail(row)" data-toggle="modal" data-target="#modal-basic_data" > {{COL_FIELD}} </a> </div>', enableFiltering: false },
                { name: 'title', enableCellEdit: false, displayName: 'Title', width: '30%', enableFiltering: false },
                { field: 'action', enableCellEdit: false, name: '', cellTemplate: '<button type="button" class="btn btn-xs" ng-click="grid.appScope.openDeleteModal(row)"> <i class="fa fa-trash"></i> </button>', enableFiltering: false },
            ]
        };

        //create new member
        vm.submit = function (data) {
            var member = {};
            member.firstName = data.firstName;
            member.lastName = data.lastName;
            member.title = data.title;
            member.projectId = data.selectionModal;

            memberService.createMember.save(member)
                .$promise.then(function (value) {
                    vm.messageSuc = true;
                    vm.messageErr = false;
                    $('#endMessage').modal('show');
                    $('#modalForDetail').modal('hide');
                    vm.SuccessMsg = 'Created Successfullye';
                    vm.getAllMembers();
                    vm.messageSuc = true;
                    vm.messageErr = false;
                }), function (error) {
                    vm.messageSuc = false;
                    vm.messageErr = true;
                    $('#endMessage').modal('show');
                    vm.ErrorMsg = 'Error';
                    //$('#modalForDetail').modal('hide');
                    
                }
        };

        //Update member
        vm.edit = function (data) {
            var member = {};
            member = vm.tempSelected;
            member.firstName = data.firstName;
            member.lastName = data.lastName;
            member.title = data.title;
            member.projectId = data.selectionModal;

            memberService.updateMember.save(member)
                .$promise.then(function (value) {
                    vm.messageSuc = true;
                    vm.messageErr = false;
                    $('#endMessage').modal('show');
                    $('#modalForDetail').modal('hide');
                    vm.SuccessMsg = 'Updated Successfully';
                    vm.getAllMembers();
                    vm.messageSuc = true;
                    vm.messageErr = false;
                }), function (error) {
                    vm.messageSuc = false;
                    vm.messageErr = true;
                    $('#endMessage').modal('show');
                    vm.ErrorMsg = 'Error';
                    //$('#modalForDetail').modal('hide');

                }
        };

        //delete member
        vm.delete = function () {
           $resource(appSettings.serverPath + 'api/member/delete/' + vm.idRow)
           .delete(vm.idRow)
               .$promise
               .then(function (value) {
                    vm.messageSuc = true;
                    vm.messageErr = false;
                    $('#endMessage').modal('show');
                    vm.SuccessMsg = 'Deleted Successfully';
                    vm.getAllMembers();
                    vm.messageSuc = true;
                    vm.messageErr = false;
                }), function (error) {
                    vm.messageSuc = false;
                    vm.messageErr = true;
                    $('#endMessage').modal('show');
                    vm.ErrorMsg = 'Error';
                    //$('#modalForDetail').modal('hide');

                }
        };

        // edit member
        $scope.detail = function (row) {
            $('#modalForDetail').modal('show');
            vm.firstName = row.entity.firstName;
            vm.lastName = row.entity.lastName;
            vm.title = row.entity.title;
            vm.selectionModal = row.entity.projectId.toString();
            vm.tempSelected = row.entity;

            vm.showInsert = false;
            vm.showUpdate = true;
        }

        //delete
        $scope.openDeleteModal = function (row) {
            $('#alertMessage').modal('show');
            vm.idRow = row.entity.id;
        };

	}

})();