class DetailPartial
	AttachLoad: -> $('#DetailPartialTop .partialLoad').click ->  
		eleId = $(this).addClass('waiting').attr('id')
		dp = new DetailPartial 
		dp.Post(eleId,'/Articles/DetailPartial/Post', {name: 'John Doe', email: 'a@a.com'}  ) 
	PostPost: (results) -> alert test
	Post: (eleId, pathToPost, params) ->  $.post pathToPost,  
			params
			(result) ->  
				top = $('#'+eleId).closest('.partialTop')  
				top.html($(result))
				dp = new DetailPartial 
				dp.AttachCollapser()
				dp.AttachLoad() 
	AttachCollapser: -> $('#DetailPartialTop .collapser').click ->  
		$(this).toggleClass('expanded').next().toggle();
dp = new DetailPartial 
dp.AttachLoad()