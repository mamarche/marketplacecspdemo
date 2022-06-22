((ns) => {
    ns.Solution = ns.Solution || {};

})(DCMS);



((ns) => {
    ns.GetSolutions = (resultContainer) => {
        $.get(global_root + "Solution/SolutionList", function (data) {
            $(resultContainer).html(data);
        })
    };

})(DCMS.Solution)