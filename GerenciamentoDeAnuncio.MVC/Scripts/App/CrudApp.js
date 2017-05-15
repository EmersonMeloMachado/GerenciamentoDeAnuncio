$(function () {
    Listar();
});
function Cadastrar() {
    var dadosAnuncio = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/Anuncios/Create",
        data: dadosAnuncio,
        success: function () {
            alert("Cadastrado com Sucesso!");
            Listar();
        },
        error: function () {
            alert("Error!");
        }
    });
}

function Listar() {
    LimparFormulario();

    $.ajax({
        type: "GET",
        url: "/Anuncios/Listar",
        success: function (dadosAnuncio) {

            if (dadosAnuncio != null) {
                $('#tbody').children().remove();
                $(dadosAnuncio).each(function (i) {
                    var dataMiliSegundos = dadosAnuncio[i].DataCadastro.replace('/Date(', '').replace(')/', '');
                    var tbody = $('#tbody');
                    var tr = "<tr>";
                    tr += "<td>" + dadosAnuncio[i].AnuncioID;
                    tr += "<td>" + dadosAnuncio[i].Texto;
                    tr += "<td>" + dadosAnuncio[i].Audio;
                    tr += "<td>" + dadosAnuncio[i].Video;
                    tr += "<td>" + dadosAnuncio[i].Status;
                    tr += "<td>" + DataCadastro;
                    tr += "<td>" + "<button class='btn btn-info' onclick=Editar(" + dadosAnuncio[i].Id + ")>" + "Editar";
                    tr += "<td>" + "<button class='btn btn-danger' onclick=Deletar(" + dadosAnuncio[i].Id + ")>" + "Deletar";
                    tbody.append(tr);
                });
            }
        }
    });
}

function Editar(AnuncioID) {

    if (AnuncioID != null && AnuncioID > 0) {

        $.ajax({
            type: 'GET',
            url: '/Anuncios/Edit/5',
            data: { id: idAnuncio },
            success: function (dados) {
                var dataMiliSegundos = dados.DataAlteracao.replace('/Date(', '').replace(')/', '');
                var dataFormatoLocal = new Date(parseInt(dataMiliSegundos)).toLocaleDateString();

                var dataFormatada = "";
                dataFormatada += dataFormatoLocal.substring(6, 10) + '-';
                dataFormatada += dataFormatoLocal.substring(3, 5) + '-';
                dataFormatada += dataFormatoLocal.substring(0, 2);

                $('#AnuncioID').val(dados.IdAnuncio);
                $('#Texto').val(dados.Texto);
                $('#Audio').val(dados.Texto);
                $('#Video').val(dados.Texto);
                $('#DataAlteracao').val(dataFormatada);
                $("#salvar").addClass("hidden");
                $("#atualizar").removeClass("hidden");
            }
        });
    }
}

function Atualizar() {

    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/Anuncios/Atualizar",
        data: dadosSerializados,
        success: function () {

            $("#salvar").removeClass("hidden");
            $("#atualizar").addClass("hidden");

            Listar();
        },
        error: function myfunction() {
            alert("Erro!");
        }

    });
}

function Deletar(AnuncioID) {
    var confirmar = confirm("Deseja Realmente Apagar ?");
    if (confirmar) {
        if (AnuncioID != null || AnuncioID > 0) {
            $.ajax({
                type: 'POST',
                url: "/Anuncios/Delete/5",
                data: { id: AnuncioID },
                success: function () {
                    Listar();
                    alert("Deletado com Sucesso !");
                },
                error: function () {
                    alert("Erro !");
                }

            });
        }
    }
}

function LimparFormulario() {
    $("#formDados").on("submit", function (event) {
        event.preventDefault();
        console.log($(this).serialize());
    });
    $('#formDados').each(function () {
        this.reset();
    });
}

function Mensagem(stringCss, mensagem) {
    $("#mensagem").remove();

    setTimeout(function () {
        $('#formDados').append("<div class='alert alert-" + stringCss + "' id=mensagem role=alert>" + mensagem + "</div>");
    }, 10);
}


