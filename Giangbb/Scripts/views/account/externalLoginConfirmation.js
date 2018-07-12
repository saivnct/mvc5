$().ready(function () {
    var page = $('.full-page');
    var image_src = page.data('image');

    if (image_src !== undefined) {
        var image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
        page.append(image_container);
    }



    $('#ExternalLoginConfirmationForm').validate({
        rules: {
            "UserName": {
                required: true
            },
            "Email": {
                required: true,
                email: true
            },
            "DrivingLicense": {
                required: true,
                maxlength: 255
            }
        },
        messages: {
            "UserName": {
                required: "Name must not empty!"                
            },
            "Email": {
                required: "Email must not empty!",
                email: "Please input valid email"
            },            
            "DrivingLicense": {
                required: "DrivingLicense must not empty!",
                maxlength: "DrivingLicense must not be more than 255 characters!"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
            error.insertAfter(element);
        }
    });
});