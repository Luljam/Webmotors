$(document).ready(function () {
   

    CarregarCombos();
});

function CarregarCombos() {
    $("#marca").prop("disabled", true);
    $("#modelo").prop("disabled", true);
    $("#versao").prop("disabled", true);

    $.ajax({
        type: "GET",
        url: "/Veiculo/GetListaMarcas",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Selecione a marca</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option id="' + data[i].id + '" value="' + data[i].name + '">' + data[i].name + '</option>';
            }
            $("#marca").html(s);
            $("#marca").prop("disabled", false);
        }
    });


    $('#marca').change(function () {
        var idMarca = $('#marca option:selected').attr('id');
        debugger;

        $.ajax({
            type: "GET",
            url: "/Veiculo/GetListaModelos?idMarca=" + idMarca,
            success: function (data) {
                var s = '<option value="-1">Selecione o modelo</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option id="' + data[i].id + '" value="' + data[i].name + '">' + data[i].name + '</option>'
                }
                $("#modelo").html(s);
                $("#modelo").prop("disabled", false);
            }
        });

    });

    $('#modelo').change(function () {
        var idModelo = $('#modelo option:selected').attr('id');
        debugger;

        $.ajax({
            type: "GET",
            url: "/Veiculo/GetListaVersao?idModelo=" + idModelo,
            success: function (data) {
                var s = '<option value="-1">Selecione o modelo</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option id="' + data[i].id + '" value="' + data[i].name + '">' + data[i].name + '</option>'
                }
                $("#versao").html(s);
                $("#versao").prop("disabled", false);
            }
        });

    });
}