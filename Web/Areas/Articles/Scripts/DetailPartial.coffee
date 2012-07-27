class DetailPartial
	AttachLoad: -> $('#DetailPartialTop .partialLoad').unbind('click').click ->  
			eleId = $(this).addClass('waiting').attr('id')
			dp = new DetailPartial 
			dp.Post('DetailPartial','/Articles/DetailPartial/Post', {name: 'John Doe', email: 'a@bba.com'}  ) 

	AttachCollapser: -> $('#DetailPartialTop .collapser').unbind('click').click ->  
		$(this).toggleClass('expanded').next().toggle();

	Post: (eleId, pathToPost, params) ->  
		$.post(pathToPost,
		params
		(result) ->  
			(new DetailPartial).PostPost(result, eleId)) 

	PostPost: (results, eleId) -> 
		alert eleId
		top = $('#'+eleId).closest('.partialTop')  
		top.html($(results))
		dp = new DetailPartial 
		dp.AttachCollapser()
		dp.AttachLoad() 

dp = new DetailPartial 
dp.AttachLoad()