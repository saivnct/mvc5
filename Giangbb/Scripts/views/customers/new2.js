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
   

    $('#customerForm').validate({
        rules: {
            "CustomerForm.Name": {
                required: true,
                minlength: 5
            },
            "CustomerForm.Address": {
                required: true                
            },
            "CustomerForm.Birthday": {
                required: true
            },
            "CustomerForm.MembershipTypeId": {
                required: true
            }
        },
        messages: {
            "CustomerForm.Name": {
                required: "Name must not empty!",
                minlength: "length must be more than 5"
            },
            "CustomerForm.Address": {
                required: "Address must not empty!",                
            },
            "CustomerForm.Birthday": {
                required: "Address must not empty!",
            },
            "CustomerForm.MembershipTypeId": {
                required: "MembershipTypeId must not empty!"
            }
        },
        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
            error.insertAfter(element);
        }
    });
});




function handleIsSubscribedToNewLettersCheckbox(cb) {
//    var isSubscribe = $('#customerForm #CustomerForm_IsSubscribedToNewLettersCheckbox').is(':checked');
    var isSubscribe = cb.checked;
    $('#customerForm #CustomerForm_IsSubscribedToNewLetters').val(isSubscribe);
    console.log(isSubscribe);    
    return;
}