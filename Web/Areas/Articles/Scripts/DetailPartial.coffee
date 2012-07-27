
class Partial
	@GetInputVal: (selector) -> 
		ele = $(selector) 
		r = '' 
		if(ele.length != 0)   
			r = ele.val() 
			
	@AttachCollapser: (controller)  -> 
		$('#'+controller+'Top .collapser').unbind('click').click ->  
			$(this).toggleClass('expanded').next().toggle();


class DetailPartial
	
	AttachGet:  -> 
		$('#DetailPartialTop .partialGet').unbind('click').click ->
			controller = 'DetailPartial'
			params = {name: '', email: 'a@bba.com'} 
			$.get('/Articles/'+ controller+'/Get',
			params
			(result) ->  
				(new DetailPartial).PostPost(result, controller))  
	AttachLoad:  ->  
		$('#DetailPartialTop .partialPost').unbind('click').click ->  
			$(this).addClass('waiting')
			name = Partial.GetInputVal('.DetailPartial-Name') 
			params = {name: name, email: 'a@bba.com'}
			dp = new DetailPartial 
			dp.Post('DetailPartial' ,  params ) 
		$('#DetailPartialTop .namecheck').unbind('click').click ->  
			name = Partial.GetInputVal('.DetailPartial-Name')  
	Post: (controller, params) ->  
		$.post('/Articles/'+controller+'/Post',
		params
		(result) ->  
			(new DetailPartial).PostPost(result, controller))  
	PostPost: (results, eleId) ->  
		alert eleId
		$('#'+eleId+'Top').closest('.partialTop').html($(results))  
		Partial.AttachCollapser('DetailPartial')
		(new DetailPartial).AttachLoad() 

detailPartial = new DetailPartial 
detailPartial.AttachGet() 