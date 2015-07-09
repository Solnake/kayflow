function gfGetElement(clientid) {
    return ASPxClientControl.GetControlCollection().Get(clientid);
}

function isNullOrEmpty(str) {
    if (!str)
        return true;
    for (var i = 0; i < str.length; i++)
        if (" " != str.charAt(i))
            return false;
    return true;
}