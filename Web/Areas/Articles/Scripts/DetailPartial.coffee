$('#WorkDetailPartial-load').click ->  
	$.post '/Articles/DetailPartial/PostDetails',  
		name: 'John Doe'
		email: 'a@a.com'
		(result) -> $("#WorkDetailPartial").html $(result)   
