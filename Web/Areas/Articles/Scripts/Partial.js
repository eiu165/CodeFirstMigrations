(function() {

  $('.partialLoad').click(function() {
    var eleId;
    eleId = $(this).attr('id');
    return $.post('/Articles/' + eleId + '/Post', {
      name: 'John Doe',
      email: 'a@a.com'
    }, function(result) {
      var el;
      el = $('#' + eleId).closest('.partialTop');
      return el.html($(result));
    });
  });

}).call(this);
