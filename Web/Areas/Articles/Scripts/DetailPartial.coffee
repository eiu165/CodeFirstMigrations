class DetailPartial
	AttachLoad:  -> 
		$('#DetailPartialTop .partialLoad').unbind('click').click ->  
			$(this).addClass('waiting')
			nameEle = $('#DetailPartialTop [name="name"]') 
			name = 'xsx' 
			if(nameEle.length != 0)  
				name =   nameEle.val()  
			alert name
			params = {name: name, email: 'a@bba.com'}
			dp = new DetailPartial 
			dp.Post('DetailPartial' ,  params ) 
		$('#DetailPartialTop .namecheck').unbind('click').click -> 
			alert $('#DetailPartialTop [name="name"]').val

	AttachCollapser: -> 
		$('#DetailPartialTop .collapser').unbind('click').click ->  
			$(this).toggleClass('expanded').next().toggle();

	Post: (controller, params) ->  
		$.post('/Articles/'+controller+'/Post',
		params
		(result) ->  
			(new DetailPartial).PostPost(result, controller)) 

	PostPost: (results, eleId) ->  
		$('#'+eleId).closest('.partialTop').html($(results))  
		dp = new DetailPartial 
		dp.AttachCollapser()
		dp.AttachLoad() 

dp = new DetailPartial 
dp.AttachLoad()