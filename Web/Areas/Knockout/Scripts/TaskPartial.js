﻿


$(function () {
    function Task(data) {
        this.title = ko.observable(data.title);
        this.isDone = ko.observable(data.isDone);
    }

    function TaskListViewModel() {
        // Data
        var self = this;
        self.tasks = ko.observableArray([]);
        self.newTaskText = ko.observable();
        self.incompleteTasks = ko.computed(function () {
            return ko.utils.arrayFilter(self.tasks(), function (task) { return !task.isDone() && !task._destroy; });
        });
        self.existingTasks = ko.computed(function () {
            return ko.utils.arrayFilter(self.tasks(), function (task) { return !task._destroy; });
        });

        // Operations
        self.addTask = function () {
            self.tasks.push(new Task({ title: this.newTaskText() }));
            self.newTaskText("");
        };
        self.removeTask = function (task) { self.tasks.destroy(task) };
        self.save = function () {
            $.ajax("/Knockout/Main/SaveTasks", {
                data: ko.toJSON({ tasks: self.existingTasks }),
                type: "post", contentType: "application/json",
                success: function (result) { alert(result); }
            });
        };
        self.cancel = function () {
            self.load();
        };
        self.load = function() {
            // Load initial state from server, convert it to Task instances, then populate self.tasks
            $.getJSON("/Knockout/Main/GetTasks", function(allData) {
                var mappedTasks = $.map(allData, function(item) { return new Task(item); });
                self.tasks(mappedTasks);
            });
        };
        self.load();
    }
    ko.applyBindings(new TaskListViewModel());
});

