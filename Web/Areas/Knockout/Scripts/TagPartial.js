


$(function () {
    function Tag(data) {
        this.tagId = ko.observable(data.tagId);
        this.articleId = ko.observable(data.articleId);
        this.name = ko.observable(data.name);
        this.isInArticle = ko.observable(data.isInArticle);
    }

    function TagListViewModel() {
        // Data
        var self = this;
        self.tags = ko.observableArray([]);
        self.newTagText = ko.observable();
        self.existingtags = ko.computed(function () {
            return ko.utils.arrayFilter(self.tags(), function (tag) { return !tag._destroy; });
        });
        self.articleTags = ko.computed(function () {
            return ko.utils.arrayFilter(self.tags(), function (tag) { return tag.isInArticle() ; });
        });


        // Operations
        self.addTag = function () {
            self.tags.push(new Tag({ name: this.newTagText() }));
            self.newTagText("");
        };
        self.removeTag = function (tag) { self.tags.destroy(tag); };
        self.save = function () {
            $.ajax("/Knockout/Main/SaveTags", {
                data: ko.toJSON({ tags: self.existingtags }),
                type: "post", contentType: "application/json",
                success: function (result) { alert(result); },
                error: function () { alert('error'); }
            });
        };
        self.cancel = function () {
            self.load();
        };
        self.load = function () {
            $('#TagPartial').block({ message: '<h3><img src="/Images/busy.gif" /> Just a moment...</h3>' });
            // Load initial state from server, convert it to Tag instances, then populate self.tags 
            $.getJSON("/Knockout/Main/GetTags", function (allData) {
                $('#TagPartial').unblock();
                var mappedtags = $.map(allData, function (item) { return new Tag(item); });
                self.tags(mappedtags);
                self.configureTagAutocomplete();
            });
        };
        self.configureTagAutocomplete = function () {
            var availableTags = $.map(self.tags(), function (item) { return (item.name._latestValue); });
            $("#txtTag").autocomplete({
                source: availableTags
            });
        };
        self.load();
    }

    ko.applyBindings(new TagListViewModel(), $('#TagPartial')[0]);

});

