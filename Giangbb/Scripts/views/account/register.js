$().ready(function () {
    var page = $('.full-page');
    var image_src = page.data('image');

    if (image_src !== undefined) {
        var image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
        page.append(image_container);
    }



    $('#RegisterForm').validate({
        rules: {
            "UserName": {
                required: true,
                minlength: 5
            },
            "Email": {
                required: true,
                email: true
            },
            "Password": {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            "ConfirmPassword": {                
                equalTo: "#Password"
            },
            "DrivingLicense": {
                required: true,
                maxlength: 255
            }
        },
        messages: {
            "UserName": {
                required: "Name must not empty!",
                minlength: "length must be more than 5"
            },
            "Email": {
                required: "Email must not empty!",
                email: "Please input valid email"
            },
            "Password": {
                required: "Password must not empty!",
                minlength: "Password must not be less than 6 characters!",
                maxlength: "Password must not be more than 100 characters!"
            },
            "ConfirmPassword": {
                equalTo: "Repeat password must be match"
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