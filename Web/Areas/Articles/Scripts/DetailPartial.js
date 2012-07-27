(function() {
  var DetailPartial, dp;

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachLoad = function() {
      return $('#DetailPartialTop .partialLoad').click(function() {
        var dp, eleId;
        eleId = $(this).addClass('waiting').attr('id');
        dp = new DetailPartial;
        return dp.Post(eleId, '/Articles/DetailPartial/Post', {
          name: 'John Doe',
          email: 'a@a.com'
        });
      });
    };

    DetailPartial.prototype.PostPost = function(results) {
      return alert(test);
    };

    DetailPartial.prototype.Post = function(eleId, pathToPost, params) {
      return $.post(pathToPost, params, function(result) {
        var dp, top;
        top = $('#' + eleId).closest('.partialTop');
        top.html($(result));
        dp = new DetailPartial;
        dp.AttachCollapser();
        return dp.AttachLoad();
      });
    };

    DetailPartial.prototype.AttachCollapser = function() {
      return $('#DetailPartialTop .collapser').click(function() {
        return $(this).toggleClass('expanded').next().toggle();
      });
    };

    return DetailPartial;

  })();

  dp = new DetailPartial;

  dp.AttachLoad();

}).call(this);
