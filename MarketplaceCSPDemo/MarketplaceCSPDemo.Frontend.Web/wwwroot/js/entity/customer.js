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
    ns.Create = (loadingContainer, offerId) => {
        $(loadingContainer).LoadingOverlay("show");

        $.magnificPopup.open({
            items: {
                type: 'ajax',
                src: global_root + "Customer/CustomerCreate"
            },
            callbacks: {
                open: function () {
                    $(loadingContainer).LoadingOverlay("hide");
                }
            }
        })

    };
    ns.CheckDomain = (loadingContainer,resultContainer) => {
        $(loadingContainer).LoadingOverlay("show");

        $.post(global_root + "Customer/CheckDomain", { domainPrefix: $("#customer-create #domain").val() }, function (data) {
            $("#resultContainer").html(data);
        })
            .always(function () {


            })


    }

})(DCMS.Customer)