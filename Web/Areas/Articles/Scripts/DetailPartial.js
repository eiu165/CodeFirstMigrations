(function() {
  var DetailPartial, dp;

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachLoad = function() {
      return $('#DetailPartialTop .partialLoad').click(function() {
        var eleId;
        eleId = $(this).addClass('waiting').attr('id');
        return $.post('/Articles/DetailPartial/Post', {
          name: 'John Doe',
          email: 'a@a.com'
        }, function(result) {
          var dp, top;
          top = $('#' + eleId).closest('.partialTop');
          top.html($(result));
          dp = new DetailPartial;
          dp.AttachCollapser();
          return dp.AttachLoad();
        });
      });
    };

    DetailPartial.prototype.Post = function(eleIdToUpdate, pathToPost, params) {
      return alert(aa);
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
