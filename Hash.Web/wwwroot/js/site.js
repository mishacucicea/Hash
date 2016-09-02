// Write your Javascript code.
$(function () {
    $("#btnComputeHash").click(function () {
        var text = $("#textToHash").val();
        var encoding = $("#encoding").val();

        $.get('/Home/GetHash', { textToHash: text, encoding:encoding }, 
            function(data) {
                $("#hashResult").val(data);
            });
    });
});