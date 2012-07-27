class DetailPartial
	AttachLoad: -> $('#DetailPartialTop .partialLoad').click ->  
		eleId = $(this).addClass('waiting').attr('id')
		dp = new DetailPartial 
		dp.Post(eleId,'/Articles/DetailPartial/Post', {name: 'John Doe', email: 'a@a.com'}  ) 
	PostPost: (results, eleId) -> 
		alert 'eleId: ' + eleId + '          results:' + results
		top = $('#'+eleId).closest('.partialTop')  
		top.html($(results))
		dp = new DetailPartial 
		dp.AttachCollapser()
		dp.AttachLoad() 
	Post: (eleId, pathToPost, params) ->  
		$.post(pathToPost,  
		name: 'John Doe'
		email: 'a@a.com' 
		(result) ->  
			dp = new DetailPartial 
			dp.PostPost(result, eleId)) 
	AttachCollapser: -> $('#DetailPartialTop .collapser').click ->  
		$(this).toggleClass('expanded').next().toggle();
dp = new DetailPartial 
dp.AttachLoad()