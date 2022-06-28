((ns) => {
    ns.Order = ns.Order || {};

})(DCMS);


((ns) => {
    ns.Create = (loadingContainer, offerId,offerName) => {
        $(loadingContainer).LoadingOverlay("show");

        $.magnificPopup.open({
            items: {
                type: 'ajax',
                src: global_root + "Order/OrderCreate?offerId=" + offerId + "&offerName=" + offerName
            },
            callbacks: {
                open: function () {
                    $(loadingContainer).LoadingOverlay("hide");
                }
            }
        })

    };
    ns.Create_Save = (loadingContainer, formId) => {
        $(loadingContainer).LoadingOverlay("show");

        $.post(global_root + "Order/OrderCreateSave", $(formId).serialize(), function (data) {
            $(loadingContainer).LoadingOverlay("hide");
            if (data.statusMessage == "success") {
                swal.fire({
                    title: "Congratulations!!",
                    text: "Your order has been submitted",
                    icon: "success",
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
                swal.fire({
                    title: "OPS..",
                    text: data.responseText,
                    icon: "error",
                });
            })
    };
    ns.GetOrdersByCustomerId = (loadingContainer,resultContainer,customerId) => {
        $(loadingContainer).LoadingOverlay("show");

        $.get(global_root + "Order/GetOrdersByCustomerId", { customerId: customerId }, function (data) {
            $(loadingContainer).LoadingOverlay("hide");
            $(resultContainer).html(data);

        })
            .fail(function (data) {
                swal.fire({
                    title: "OPS..",
                    text: data.responseText,
                    icon: "error",
                });
            })

    }
})(DCMS.Order)