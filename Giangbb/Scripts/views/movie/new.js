$(document).ready(function () {
    $('.datepicker').datetimepicker({
        format: 'DD/MM/YYYY',
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-chevron-up",
            down: "fa fa-chevron-down",
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right',
            today: 'fa fa-screenshot',
            clear: 'fa fa-trash',
            close: 'fa fa-remove',
            inline: true
        }
    });


    $('#movieForm').validate({
        rules: {
            "MovieForm.Name": {
                required: true,
                minlength: 5
            },
            "MovieForm.ReleaseDate": {
                required: true
            },
            "MovieForm.GenreId": {
                required: true
            },
            "MovieForm.NumberInStock": {
                required: true
            }
        },
        messages: {
            "MovieForm.Name": {
                required: "Name must not empty!",
                minlength: "length must be more than 5"
            },
            "MovieForm.ReleaseDate": {
                required: "Release Date must not empty!",
            },
            "MovieForm.GenreId": {
                required: "GenreId must not empty!",
            },
            "MovieForm.NumberInStock": {
                required: "NumberInStock must not empty!"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
            error.insertAfter(element);
        }
    });
});
