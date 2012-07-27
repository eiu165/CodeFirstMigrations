(function() {
  var DetailPartial, dp;

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachLoad = function() {
      return $('#DetailPartialTop .partialLoad').unbind('click').click(function() {
        var dp, eleId;
        eleId = $(this).addClass('waiting').attr('id');
        dp = new DetailPartial;
        return dp.Post('DetailPartial', '/Articles/DetailPartial/Post', {
          name: 'John Doe',
          email: 'a@bba.com'
        });
      });
    };

    DetailPartial.prototype.AttachCollapser = function() {
      return $('#DetailPartialTop .collapser').unbind('click').click(function() {
        return $(this).toggleClass('expanded').next().toggle();
      });
    };

    DetailPartial.prototype.Post = function(eleId, pathToPost, params) {
      return $.post(pathToPost, params, function(result) {
        return (new DetailPartial).PostPost(result, eleId);
      });
    };

    DetailPartial.prototype.PostPost = function(results, eleId) {
      var dp, top;
      alert(eleId);
      top = $('#' + eleId).closest('.partialTop');
      top.html($(results));
      dp = new DetailPartial;
      dp.AttachCollapser();
      return dp.AttachLoad();
    };

    return DetailPartial;

  })();

  dp = new DetailPartial;

  dp.AttachLoad();

}).call(this);
