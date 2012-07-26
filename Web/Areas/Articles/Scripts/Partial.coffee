$('.partialLoad').click ->  
	eleId = $(this).attr 'id' 
	$.post '/Articles/'+eleId+'/Post',  
		name: 'John Doe'
		email: 'a@a.com'
		(result) ->  
			el = $('#'+eleId).closest '.partialTop'  
			el.html($(result));
