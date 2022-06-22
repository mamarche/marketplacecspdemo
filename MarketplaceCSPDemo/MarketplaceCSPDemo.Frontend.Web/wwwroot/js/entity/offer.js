((ns) => {
    ns.Offer = ns.Offer || {};

})(DCMS);



((ns) => {
    ns.GetOfferByCountry = (resultContainer, country) => {
        $(resultContainer).LoadingOverlay("show");

        $.get(global_root + "Offer/GetOffersByCountry", {country:$(country).val()}, function (data) {
            $(resultContainer).html(data);
            $(resultContainer).LoadingOverlay("hide");
        })
            .fail(function (data) {
                $(resultContainer).LoadingOverlay("hide");
                $(resultContainer).html(data.responseText);
            })
    };

})(DCMS.Offer)