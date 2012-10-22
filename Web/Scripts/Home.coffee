Instructor = (data) ->
    Name = ko.observable(data.Name)
    Id = ko.observable(data.Id)
    Name:Name
    Id:Id 
viewModel =-> 
    instructors = ko.observableArray([])      
    load = -> 
        console.log 'load'   
        $.getJSON("/api/Instructors",(dataAll)->mapData(dataAll)) 
    mapData = (data) ->
        console.log 'in mapData'
        debugger
        mappedItems = $.map( data , (item)-> Instructor(item) )
        console.log 'after mapitems'
        instructors(mappedItems)  
    instructors:instructors     
    load:load        
$(->    
    console.log 'start'   
    vm = new viewModel()
    vm.load()
    ko.applyBindings(vm)
    this
)