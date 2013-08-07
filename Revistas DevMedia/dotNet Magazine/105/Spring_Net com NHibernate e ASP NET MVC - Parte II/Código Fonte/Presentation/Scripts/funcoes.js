
$(function () {
    //Aplica o ui Widget do jQuery
    $("button")
                .button();
    //Transforma o div informado em um Dialog
    $("#janela-principal")
        .dialog({
            modal: false
        });

    //Transforma a mensagem de saída em um botão
    /*
    $("#mensagem").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
    */
});