(function() {
  var DetailPartial, Partial, detailPartial;

  Partial = (function() {

    Partial.name = 'Partial';

    function Partial() {}

    Partial.GetInputVal = function(selector) {
      var ele, r;
      ele = $(selector);
      r = '';
      if (ele.length !== 0) {
        return r = ele.val();
      }
    };

    Partial.AttachCollapser = function(controller) {
      return $('#' + controller + 'Top .collapser').unbind('click').click(function() {
        return $(this).toggleClass('expanded').next().toggle();
      });
    };

    return Partial;

  })();

  DetailPartial = (function() {

    DetailPartial.name = 'DetailPartial';

    function DetailPartial() {}

    DetailPartial.prototype.AttachGet = function() {
      return $('#DetailPartialTop .partialGet').unbind('click').click(function() {
        var controller, params;
        controller = 'DetailPartial';
        params = {
          name: '',
          email: 'a@bba.com'
        };
        return $.get('/Articles/' + controller + '/Get', params, function(result) {
          return (new DetailPartial).PostPost(result, controller);
        });
      });
    };

    DetailPartial.prototype.AttachLoad = function() {
      $('#DetailPartialTop .partialPost').unbind('click').click(function() {
        var dp, name, params;
        $(this).addClass('waiting');
        name = Partial.GetInputVal('.DetailPartial-Name');
        params = {
          name: name,
          email: 'a@bba.com'
        };
        dp = new DetailPartial;
        return dp.Post('DetailPartial', params);
      });
      return $('#DetailPartialTop .namecheck').unbind('click').click(function() {
        var name;
        return name = Partial.GetInputVal('.DetailPartial-Name');
      });
    };

    DetailPartial.prototype.Post = function(controller, params) {
      return $.post('/Articles/' + controller + '/Post', params, function(result) {
        return (new DetailPartial).PostPost(result, controller);
      });
    };

    DetailPartial.prototype.PostPost = function(results, eleId) {
      alert(eleId);
      $('#' + eleId + 'Top').closest('.partialTop').html($(results));
      Partial.AttachCollapser('DetailPartial');
      return (new DetailPartial).AttachLoad();
    };

    return DetailPartial;

  })();

  detailPartial = new DetailPartial;

  detailPartial.AttachGet();

}).call(this);
