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
    ns.CallCustomerCreate = (loadingContainer, offerId, offerName) => {
        DCMS.Customer.Create('undefined', offerId, offerName)
    }
})(DCMS.Order)