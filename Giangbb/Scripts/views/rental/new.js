$(document).ready(function () {
    var vm = {
        movieIds: []
    };

    $.validator.addMethod("validCustomer",
        function() {
            return vm.customerId && vm.customerId !== 0;
        },
        "Please select a valid customer");

    var validator = $('#rentalForm').validate({
        rules: {
            "customer": {
                required: true,                
                validCustomer: true               
            }
           
        },
        messages: {
            "customer": {
                required: "Customer must not empty!"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
            error.insertAfter(element);
        },
        submitHandler: function () {            
        
            $.ajax({
                url: "/api/rental",
                method: "POST",
                data: vm
            }).done(function () {
                console.log("DONE!!!!!!");
                showSpecificNotification('success', 'Add Rental Success', 'notifications', 200);
                $('#rentalForm #movie').typeahead("val", "");
                $('#rentalForm #customer').typeahead("val", "");
                $('#rentalForm #movies').empty();
                vm = { movieIds: [] };
                validator.resetForm();
            }).fail(function () {

                });

            return false; //prevent a form from submitting normally
        }
    });

    

    var customers = new Bloodhound({    //Bloodhound is suggestion engine behind typeahead.js
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,        
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });    
    

    $('#rentalForm #customer').typeahead({
        minLength: 1,
        highlight: true
    }, {
            name: 'customers',            
            display: 'name',
            source: customers //Bloodhound obj
        }).on("typeahead:select", function(e, customer) {
            vm.customerId = customer.id;
            console.log(customer);

        });

    var movies = new Bloodhound({    //Bloodhound is suggestion engine behind typeahead.js
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#rentalForm #movie').typeahead({
            minLength: 1,
            highlight: true
        },
        {
            name: 'movies',
            display: 'name',
            source: movies //Bloodhound obj
        }).on("typeahead:select",
        function(e, movie) {
            vm.movieIds.push(movie.id);
            console.log(movie);

            $('#rentalForm #movies').append("<li class='list-group-item'>" + movie.name + "</li>");

            $('#rentalForm #movie').typeahead("val","");

        });

   

    
});
