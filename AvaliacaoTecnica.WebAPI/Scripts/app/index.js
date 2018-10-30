var initializer = {

    obterProdutos: function () {
        $.ajax({
            url: "http://localhost:52215/Api/Produto",
            type: "GET",
            dataType: "json",
            success: function (data) {
                if (data) {
                    var trHTML = "";

                    $("#body tr").remove();

                    var cont = 0;
                    $.each(data, function (i, item) {
                        cont++;
                        trHTML += '<tr><td style="width:10px;">' + cont + '</td><td>' + item.Nome + '</td><td>' + item.PrecoFormatado + '</td><td>' + item.Marca[0].Nome + '</td></tr>';
                    });

                    $("#body").append(trHTML);
                }
                else {
                    bootbox.alert("Erro na consulta");
                }
            }
        });
    },

    buscarProduto: function () {

        $("#buscar").keyup(function () {

            var texto = $(this).val();

            if (texto.length >= 3) {

                $.ajax({
                    url: "http://localhost:52215/Api/Produto",
                    type: "GET",
                    data: { nome: texto },
                    success: function (data) {
                        if (data) {
                            var trHTML = "";

                            $("#body tr").remove();

                            var cont = 0;
                            $.each(data, function (i, item) {
                                cont++;
                                trHTML += '<tr><td style="width:10px;">' + cont + '</td><td>' + item.Nome + '</td><td>' + item.PrecoFormatado + '</td><td>' + item.Marca[0].Nome + '</td></tr>';
                            });

                            $("#body").append(trHTML);
                        }
                        else {
                            bootbox.alert("Erro na consulta");
                        }
                    }
                });
            }
            else
                if (texto.length < 1) {
                    initializer.obterProdutos();
                }
        });
    }
};



