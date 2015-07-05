var arrStack = new Array();

function DialogForm_ShowFrame(headerText, view, qs, event, w, h, dialogLoadingPanel) {
    var viewport = getViewport();
    if (!arrStack || arrStack.length == 0 || arrStack[arrStack.length - 1][2] != headerText) {
        var isIos = isBrowserMobileIOS();
        w = w ? w : DialogForm_GetWidth(view);
        h = h ? h : DialogForm_GetHeight(view);
        var _window = popGetParentWindow();
        popRemoveParentScroll();
        if (dialogLoadingPanel)
            dialogLoadingPanel.Show();
        var _src = 'PopUpPage.aspx?view=' + view;
        if (!isNullOrEmpty(qs))
            _src += '&' + qs;
        _src += '&wdth=' + w + '&hght=' + h + '&viewportwdth=' + viewport.width + '&viewporthght' + viewport.height + '&hdrTitle=' + headerText;
        var arr = new Array(3);
        arr[0] = event;
        _window.arrStack[_window.arrStack.length] = arr;
        var frameId = "modalDialog_" + _window.arrStack.length;
        var frameArr = popGetFrame(frameId, _src, isIos);
        frameArr.frameelement.load(function () {
            if (dialogLoadingPanel)
                dialogLoadingPanel.Hide();
            popSetPopupScrollState(frameId);
            $('#' + frameId).css('visibility', 'visible');
        });
        frameArr.framehtml.appendTo('body');
        arr[1] = frameId;
        arr[2] = headerText;
    } else {
        if(dialogLoadingPanel)
            dialogLoadingPanel.Hide();
        if (!arrStack || arrStack.length == 0)
            popRestoreParentScroll();
    }
}

function popGetFrame(frameid, sourceurl, isIos) {
    if (isIos) {
        var outpumrk = $('<div id="div' + frameid + '" style="visibility:hidden; overflow-y: auto; overflow-x: hidden; position:fixed; left:0; top:0; margin:0; padding:0; z-index:99999; width:100%; height:100%; -webkit-overflow-scrolling: touch;"><iframe id="' + frameid + '" style="/*visibility:hidden;*/ border:none; background-color: transparent;" width="100%" height="100%" scrolling="auto" frameborder="0" allowtransparency="true" src="' + sourceurl + '" /></div>');
        return { framehtml: outpumrk, frameelement: outpumrk.find("#" + frameid) };
    } else {
        outpumrk = $('<iframe id="' + frameid + '" style="visibility:hidden; overflow-x: hidden; position:fixed; left:0; top:0; margin:0; padding:0; z-index:99999; border:none; background-color: transparent;" width="100%" height="100%" scrolling="auto" frameborder="0" allowtransparency="true" src="' + sourceurl + '" />');
        return { framehtml: outpumrk, frameelement: outpumrk };
    }
}

function popGetParentWindow() {
    var _window = this;
    while (_window.parent != _window) {
        _window = _window.parent;
    }
    return _window;
}

function popRemoveFrame(frameid) {
    $('#' + frameid).remove();
    if (isBrowserMobileIOS())
        $('#div' + frameid).remove();
}

function RemoveLastWindow() {
    popRemoveFrame(arrStack[arrStack.length - 1][1]);
    arrStack.pop();
}

function HideDialogFrame() {
    setTimeout(TimeOutHideDialogFrame, 100);
}

function TimeOutHideDialogFrame() {
    popRestoreParentScroll();
    popRemoveFrame(arrStack[arrStack.length - 1][1]);
    arrStack.pop();
}

var CloseDialogFrameValue = null;

function CloseDialogFrame(_val) {
    CloseDialogFrameValue = _val;
    if (__aspxBrowserMajorVersion == 9) {
        setTimeout(TimeOutCloseDialogFrame, 100);
    } else {
        TimeOutCloseDialogFrame();
    }
}

function TimeOutCloseDialogFrame() {
    var _val = CloseDialogFrameValue;
    CloseDialogFrameValue = null;
    var _fun;
    if (arrStack.length > 1) {
        popRemoveFrame(arrStack[arrStack.length - 1][1]);
        _fun = arrStack[arrStack.length - 1][0];
        arrStack.pop();
        if (window.execScript) {
            execScript('document.getElementById(arrStack[arrStack.length - 1][1]).contentWindow.' + _fun + '(\'' + _val + '\');');
        } else {
            eval('document.getElementById(arrStack[arrStack.length - 1][1]).contentWindow.' + _fun + '(\'' + _val + '\');');
        }

    } else {
        popRestoreParentScroll();
        popRemoveFrame(arrStack[arrStack.length - 1][1]);
        _fun = arrStack[arrStack.length - 1][0];
        arrStack.pop();
        if (_fun) {
            if (window.execScript) {
                execScript(getCompleteFunction(_fun, _val));
            } else {
                setTimeout(function () {
                    eval(getCompleteFunction(_fun, _val));
                }, 100);
            }
        }
    }
}

function getCompleteFunction(fun, val) {
    if (fun.charAt(fun.length - 1) == ";")
        return fun;
    else {
        return fun + '(\'' + val + '\');';
    }
}

function getViewport() {
    var viewport = new Object();
    viewport.width = Math.max(document.documentElement.clientWidth, window.innerWidth || 0);
    viewport.height = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
    return viewport;
}

function popSetPopupScrollState(frameid) {
    var popContetnHeight = $('#divIFrame', $("#" + frameid).contents()).height();
    var popHeight = $("#" + frameid).height();
    if (popContetnHeight && popContetnHeight + (popContetnHeight * 0.01) < popHeight) {
        $("#" + frameid).attr('scrolling', 'no');
    }
}

function popRemoveParentScroll() {
    $('body').css('overflow', 'hidden');
    $('body').css('height', '100%');
    $('body').css('max-height', '100%');
}

function popRestoreParentScroll() {
    if (arrStack.length <= 1) {
        $('body').css('overflow', '');
        $('body').css('height', '');
        $('body').css('max-height', '');
    }
}

function isBrowserMobileIOS() {
    return (/iphone|ipad|ipod/i.test(navigator.userAgent.toLowerCase()));
}

window.popFixScroll = function (popContentHeight, frameID) {
    if ($('#' + frameID).height() < popContentHeight)
        $("#" + frameID).attr('scrolling', 'auto');
    else {
        //alert(frameID + ' frame height=' + $('#' + frameID).height() + ' content='+ popContentHeight)
        $("#" + frameID).attr('scrolling', 'no');
    }
}

function isNullOrEmpty(str) {
    if (!str)
        return true;
    for (var i = 0; i < str.length; i++)
        if (" " != str.charAt(i))
            return false;
    return true;
}