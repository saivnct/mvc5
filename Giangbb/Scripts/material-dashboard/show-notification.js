function getFlashMessageFromCookie() {
    var flash = { message: Cookies.get("FlashMessage"), type: Cookies.get("FlashType") }

    return flash;
}

function deleteFlashMessageCookie() {  
    Cookies.remove('FlashMessage', { path: '/' }); 
    Cookies.remove('FlashType', { path: '/' });
}

function showNotification() {  
    //                type = ['', 'info', 'success', 'warning', 'danger', 'rose', 'primary'];

    var flash = getFlashMessageFromCookie();
    deleteFlashMessageCookie();
    console.log("message:" + flash.message);
    console.log("type:" + flash.type);
    var message = flash.message;
    var type = flash.type;
    var icon = 'notifications';
    var duration = 200;
       

    if (!message || 0 === message.length || !type || 0 === type.length) {
        return;
    }



    $.notify({
        icon: icon,
        message: message

    }, {
            type: type,
            timer: duration,
        placement: {
            from: 'top',
            align: 'center'
        }
    });
}