class DetailPartial
	AttachLoad: -> $('#DetailPartialTop .partialLoad').click ->  
		eleId = $(this).addClass('waiting').attr('id')
		$.post '/Articles/DetailPartial/Post',  
			name: 'John Doe'
			email: 'a@a.com'
			(result) ->  
				top = $('#'+eleId).closest('.partialTop')  
				top.html($(result))
				dp = new DetailPartial 
				dp.AttachCollapser()
				dp.AttachLoad() 
	Post: (eleIdToUpdate, pathToPost, params) -> alert aa
	AttachCollapser: -> $('#DetailPartialTop .collapser').click ->  
		$(this).toggleClass('expanded').next().toggle();
dp = new DetailPartial 
dp.AttachLoad()