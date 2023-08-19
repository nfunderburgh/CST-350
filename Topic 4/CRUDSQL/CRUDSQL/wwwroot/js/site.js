// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    console.log("document is ready");

    $(document).on("click", ".edit-product-button", function () {
        console.log("You just clicked button number " + $(this).val());

        var productId = $(this).val();
        $.ajax({
            type: 'json',
            data: {
                "id": productId
            },
            url: "/products/ShowOneProductJSON",
            success: function (data) {
                console.log(data);

                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);
            }
        })
    });

    $("#save-button").click(function (){
        var product = {
            "Id": $("#modal-input-id").val(),
            "Name": $("#modal-input-name").val(),
            "Price": $("#modal-input-price").val(),
            "Description": $("#modal-input-description").val()
        }
        console.log("saved:");
        console.log(product);

        $.ajax({
            type: 'json',
            data: product,
            url: '/products/ProcessEditReturnPartial',
            success: function (data) {
                console.log(data);
                $("#card-number-" + product.Id).html(data).hide().fadeIn(2000);
            }
        })
    });
});
