((ns) => {
    ns.Product = ns.Product || {};

})(DCMS);



((ns) => {
    ns.GetProductByTargetAndSegment = (loadingContainer, resultContainer,country, target,segment) => {
        $(loadingContainer).LoadingOverlay("show");

        $.get(global_root + "Product/GetOrderByTargetAndSegment", {country:country, target: target,segment:segment }, function (data) {
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

})(DCMS.Product)