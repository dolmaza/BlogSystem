$(function () {
    $("#add-new").click(function () {
        CategoriesTree.StartEditNewNode();
        return false;
    });

    $("#collapse-all-nodes")
        .click(function () {
            CategoriesTree.CollapseAll();

            $(this).attr("disabled", "disabled");
            $("#expand-all-nodes").removeAttr("disabled");

        });

    $("#expand-all-nodes")
        .click(function () {
            CategoriesTree.ExpandAll();

            $(this).attr("disabled", "disabled");
            $("#collapse-all-nodes").removeAttr("disabled");
        });
});