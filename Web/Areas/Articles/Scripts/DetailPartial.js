(function() {

  $('#WorkDetailPartial-load').click(function() {
    return $.post('/Articles/DetailPartial/PostDetails', {
      name: 'John Doe',
      email: 'a@a.com'
    }, function(result) {
      return $("#WorkDetailPartial").html($(result));
    });
  });

}).call(this);
