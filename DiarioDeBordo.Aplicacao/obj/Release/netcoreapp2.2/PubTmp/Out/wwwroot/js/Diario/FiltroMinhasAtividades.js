$(document).ready(function ($) {
    if ($('#txtDataInicio').val() === "0001-01-01") {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }
        if (mm < 10) {
            mm = '0' + mm;
        }

        today = yyyy + '-' + mm + '-' + dd;
        $('#txtDataInicio').val(today);
        $('#txtDataFim').val(today);
    }
    
});