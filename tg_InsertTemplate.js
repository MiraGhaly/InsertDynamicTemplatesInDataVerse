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
function OpenInsertDialog(formContext) {
    debugger;
    var emailid;

    if (formContext.getAttribute("regardingobjectid").getValue() != null) {
        if (formContext.ui.getFormType() == 1) {
            formContext.data.save("save").then(
                function () {
                    emailid = formContext.data.entity.getId().replace(/[{}]/g, '');
                    var pageInput = {
                        pageType: "custom",
                        name: "cr2d2_inserttemplate_8315a",
                        entityName: "email",
                        recordId: emailid
                    };
                    var navigationOptions = {
                        target: 2,
                        width: 700, // value specified in pixel
                        height: 600, // value specified in pixel
                        position: 1
                    };
                    Xrm.Navigation.navigateTo(pageInput, navigationOptions).then(
                        function success() {
                            // Run code on success
                            formContext.data.refresh(false).then(function () { }, function () { });

                        },
                        function error() {
                            // Handle errors
                        }
                    );
                },
                function () { }


            );
        }
        else {
            emailid = formContext.data.entity.getId().replace(/[{}]/g, '');
            var pageInput = {
                pageType: "custom",
                name: "cr2d2_inserttemplate_8315a",
                entityName: "email",
                recordId: emailid
            };
            var navigationOptions = {
                target: 2,
                width: 700, // value specified in pixel
                height: 600, // value specified in pixel
                position: 1
            };
            Xrm.Navigation.navigateTo(pageInput, navigationOptions).then(
                function success() {
                    // Run code on success
                    formContext.data.refresh(false).then(function () { }, function () { });

                },
                function error() {
                    // Handle errors
                }
            );
        }


    }
    else {
        Xrm.Utility.alertDialog("Regarding should be selected!");
        return false;

    }

}

