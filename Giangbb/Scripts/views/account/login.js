$().ready(function () {
    var page = $('.full-page');
    var image_src = page.data('image');

    if (image_src !== undefined) {
        var image_container = '<div class="full-page-background" style="background-image: url(' + image_src + ') "/>';
        page.append(image_container);
    }

    setTimeout(function () {
            // after 1000 ms we add the class animated to the login/register card
            $('.card').removeClass('card-hidden');
        },
        200);

    $('#LoginForm').validate({
        rules: {            
            "Email": {
                required: true,
                email: true
            },
            "Password": {
                required: true
            }
        },
        messages: {           
            "Email": {
                required: "Email must not empty!",
                email: "Please input valid email"
            },
            "Password": {
                required: "Password must not empty!"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
            error.insertAfter(element);
        }
    });
});

function handleRememberMeCheckbox(cb) {
    //    var isSubscribe = $('#customerForm #CustomerForm_IsSubscribedToNewLettersCheckbox').is(':checked');
    var isSubscribe = cb.checked;
    $('#LoginForm #RememberMe').val(isSubscribe);
//    console.log(isSubscribe);
    return;
}