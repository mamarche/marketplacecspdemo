((ns) => {
    ns.Customer = ns.Customer || {};

})(DCMS);



((ns) => {
    ns.GetAll = (resultContainer) => {
        $(resultContainer).LoadingOverlay("show");

        $.get(global_root + "Customer/CustomerGetAll", function (data) {
            $(resultContainer).html(data);
            $(resultContainer).LoadingOverlay("hide");
        })
            .fail(function (data) {
                $(resultContainer).LoadingOverlay("hide");
                $(resultContainer).html(data.responseText);
            })
    };
    ns.Create = (loadingContainer, offerId, offerName) => {
        $(loadingContainer).LoadingOverlay("show");

        $.magnificPopup.open({
            items: {
                type: 'ajax',
                src: global_root + "Customer/CustomerCreate?offerId="+offerId+"&offerName="+offerName
            },
            callbacks: {
                open: function () {
                    $(loadingContainer).LoadingOverlay("hide");
                }
            },
            modal: false
        })

    };
    ns.Create_Save = (loadingContainer, resultContainer) => {
        $(loadingContainer).LoadingOverlay("show");

        $.post(global_root + "Customer/CreateSave", $("#customer-create").serialize(), function (data) {
            $(loadingContainer).LoadingOverlay("hide");
            if (data.statusMessage == "success") {
                swal.fire({
                    title: "Creation complete!!",
                    html: "User:" + data.User + " - Password:" + data.Password + "<br/>Please take note of this information",
                    icon: "success",
                }).then(function () {
                    $.magnificPopup.close();
                    DCMS.Order.Create('');
                });
            }
            else {
                swal.fire({
                    title: "OPS..",
                    text: data.statusMessage,
                    icon: "error",
                });
            }
        })
            .fail(function (data) {
                $(loadingContainer).LoadingOverlay("hide");
                $(resultContainer).html(data.responseText);
            })

    };
    ns.CheckDomain = (loadingContainer, resultContainer) => {
        $(loadingContainer).LoadingOverlay("show");
        $(resultContainer).html("Domain check in progress..");
        $.post(global_root + "Customer/CheckDomain", { domainPrefix: $("#customer-create #domain").val() }, function (data) {

            $(loadingContainer).LoadingOverlay("hide");
            if (data == true) {
                $(resultContainer).html("Domain not available");
            }
            else if (data == false) {
                $(resultContainer).html("Domain available");
            }
            else {
                $(resultContainer).html(data);
            }
        })
            .fail(function (data) {
                $(resultContainer).html("Error: maybe input format is incorrect");

            })
        


    }

})(DCMS.Customer)