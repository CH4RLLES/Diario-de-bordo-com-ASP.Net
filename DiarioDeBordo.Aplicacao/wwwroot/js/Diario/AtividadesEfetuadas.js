$(document).ready(function ($) {
    $("#DadosAtividade_Quantidade").val("");
    $("#DadosAtividade_ProcessoSEI").val("");
    if ($('#txtData').val() === "") {
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
        $('#txtData').val(today);
    }

    $("#DadosAtividade_IdAtividade").change(function (e) {
        $("#DadosAtividade_Quantidade").val("");
        $("#DadosAtividade_ProcessoSEI").val("");

        $.ajax({
            url: '/api/Atividades/VerificarTemPai?idAtividade=' + $("#DadosAtividade_IdAtividade").val(),
            accepts: 'application/json',
            contentType: "application/json",
            type: 'GET',
            data: $('#frm').serialize(),
            success: function (result) {
                if (result) {
                    $("#divMsg").show();
                    $("#btnSalvar").hide();
                }
                else {
                    $("#divMsg").hide();
                    $("#btnSalvar").show();
                }
            }
        });

        $.ajax({
            url: '/api/Atividades/VerificarTemQuantidade?idAtividade=' + $("#DadosAtividade_IdAtividade").val(),
            accepts: 'application/json',
            contentType: "application/json",
            type: 'GET',
            data: $('#frm').serialize(),
            success: function (result) {
                if (result) {
                    $("#divQuantidade").show();
                      $("input").prop('required', true);
                }
                else {
                    $("input").prop('required', false);
                    $("#divQuantidade").hide();
                }
            }
        });

        $.ajax({
            url: '/api/Atividades/VerificarTemProcesso?idAtividade=' + $("#DadosAtividade_IdAtividade").val(),
            accepts: 'application/json',
            contentType: "application/json",
            type: 'GET',
            data: $('#frm').serialize(),
            success: function (result) {
                if (result) {
                    $("#divNumProcesso").show();
                    $("input").prop('required', true);                    
                }
                else {
                    $("input").prop('required', false);
                    $("#divNumProcesso").hide();
                }
            }
        });
    });

    if ($("#DadosAtividade_AtividadeFeita_Quantidade").val() == "true") {
        $("#divQuantidade").show();
    }
    else {
        $("#divQuantidade").hide();
    }

    if ($("#DadosAtividade_AtividadeFeita_NumProcesso").val() == "true") {
        $("#divNumProcesso").show();
    }
    else {
        $("#divNumProcesso").hide();
    }

    if ($("#DadosAtividade_AtividadeFeita").val() == "true") {
        $("#divMsg").show();
    }
    else {
        $("#divMsg").hide();
    }
});