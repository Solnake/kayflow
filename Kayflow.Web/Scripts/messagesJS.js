function doCompanyMessages(arrayMessage) {
    for (var i = 0; i < arrayMessage.length; i++) {
        showMessage(arrayMessage[i]);
    }
}

function showMessage(msg) {
    var n = noty({
        text: msg,
        type: 'warning',
        layout: 'center',
        modal: true,
        animation: {
            open: 'animated bounceIn', // Animate.css class names
            close: 'animated bounceOut', // Animate.css class names
            easing: 'swing', // unavailable - no need
            speed: 500 // unavailable - no need
        }
    });

    return n;
}