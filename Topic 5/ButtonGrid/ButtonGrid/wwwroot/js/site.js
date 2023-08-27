// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

$(function () {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("Right click. prevent context menu from showing");
    });

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which) {
            case 1:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("button number " + buttonNumber + " was left clicked");
                doButtonUpdate(buttonNumber, "/button/ShowOneButton");
                break;
            case 2:
                alert('middle mouse button is pressed');
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("button number " + buttonNumber + " was right clicked");
                doButtonUpdate(buttonNumber, "/button/RightClickShowOneButton");
                break;
            default:
                alert('Nothing');
        }
    });
});

function doButtonUpdate(buttonNumber, urlString) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: urlString,
        data: {
            "buttonNumber": buttonNumber
        },
        success: function (data) {
            console.log(data);
            $("#" + buttonNumber).html(data);
        }
    });
};