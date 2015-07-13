var DialogForm_Size = new Array();
window.IsNullForm = function (formName, position, nullvalue) {
    var element = DialogForm_Size[formName];
    if (typeof element == 'undefined')
        return nullvalue;
    return element[position];
};

function DialogForm_GetWidth(formName) {
    return IsNullForm(formName, 0, 100);
}
function DialogForm_GetHeight(formName) {
    return IsNullForm(formName, 1, 100);
}
function DialogForm_SetSize(formName, width, heigth) {
    DialogForm_Size[formName] = [width, heigth];
}

DialogForm_SetSize("OfficeEdit", 412, 120);
DialogForm_SetSize("EmployeeEdit", 520, 440);
DialogForm_SetSize("TerritorialUnitEdit", 460, 320);
DialogForm_SetSize("CategoryEdit", 412, 120);
DialogForm_SetSize("CostEdit", 412, 200);
DialogForm_SetSize("StateEdit", 412, 120);
DialogForm_SetSize("DocumentGroupEdit", 412, 250);
DialogForm_SetSize("DocumentEdit", 412, 320);
DialogForm_SetSize("ActActionEdit", 412, 320);
DialogForm_SetSize("ExpenseEdit", 412, 250);
DialogForm_SetSize("ActEdit", 920, 550);
DialogForm_SetSize("StepsEdit", 920, 250);
DialogForm_SetSize("TerritorialUnitSearch", 620, 440);
DialogForm_SetSize("schEventEdit", 412, 200);




