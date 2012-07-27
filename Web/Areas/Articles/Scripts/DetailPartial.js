(function() {
  var DetailPartial, dp;

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachLoad = function() {
      $('#DetailPartialTop .partialLoad').unbind('click').click(function() {
        var dp, name, nameEle, params;
        $(this).addClass('waiting');
        nameEle = $('#DetailPartialTop [name="name"]');
        name = 'xsx';
        if (nameEle.length !== 0) {
          name = nameEle.val();
        }
        alert(name);
        params = {
          name: name,
          email: 'a@bba.com'
        };
        dp = new DetailPartial;
        return dp.Post('DetailPartial', params);
      });
      return $('#DetailPartialTop .namecheck').unbind('click').click(function() {
        return alert($('#DetailPartialTop [name="name"]').val);
      });
    };

    DetailPartial.prototype.AttachCollapser = function() {
      return $('#DetailPartialTop .collapser').unbind('click').click(function() {
        return $(this).toggleClass('expanded').next().toggle();
      });
    };

    DetailPartial.prototype.Post = function(controller, params) {
      return $.post('/Articles/' + controller + '/Post', params, function(result) {
        return (new DetailPartial).PostPost(result, controller);
      });
    };

    DetailPartial.prototype.PostPost = function(results, eleId) {
      var dp;
      $('#' + eleId).closest('.partialTop').html($(results));
      dp = new DetailPartial;
      dp.AttachCollapser();
      return dp.AttachLoad();
    };

    return DetailPartial;

  })();

  dp = new DetailPartial;

  dp.AttachLoad();

}).call(this);
