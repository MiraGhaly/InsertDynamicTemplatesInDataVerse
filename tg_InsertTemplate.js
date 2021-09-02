// JavaScript source code

function InsertTemplate(executionContext) {

    var emailtemplateid = formContext.getAttribute("tg_emailtemplateid").getValue()[0].id.replace("}", "").replace("{", "").trim();

    var entity = {};
    entity["tg_emailtemplate@odata.bind"] = "/tg_emailtemplateses(" + emailtemplateid + ")";

    Xrm.WebApi.online.updateRecord("email", formContext.data.entity.getId().replace(/[{}]/g, ''), entity).then(
        function success(result) {
            var updatedEntityId = result.id;
        },
        function (error) {
            Xrm.Utility.alertDialog(error.message);
        }
    );
}