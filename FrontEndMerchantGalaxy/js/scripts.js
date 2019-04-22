 $(document).ready(function () {});

function ConverterInteiroNumeroRomano() {
    var id = $("#inputTexto").val().replace(".",",").replace("?","").replace("&","");
    if(id == ""){
        $("#inputTexto").focus();
        return null;
    }
    var endereco = EnderecoAPI("/api/InteirosRomanos/ConverterInteiroRomano/" + id);
    if(endereco != null){
        $.getJSON(endereco,
            function (data) {
                $(".modal-body").text(data);
                $("#ModalCenterTitle").text("Conversão de numero inteiro para romano")
                $("#modalResposta").modal('toggle');
            })
            .fail(function(jqxhr, textStatus, error ) {
                $(".modal-body").text("Confira se o endereço e porta da maquina foi digitado corretamente");
                $("#ModalCenterTitle").text("Conversão de numero inteiro para romano")
                $("#modalResposta").modal('toggle');
                $("#inputEndereco").focus();
            })
    }else{
        $("#inputEndereco").focus();
        return null;
    }
}


function ConverterNumeroRomanoInteiro() {
    var id = $("#inputTexto").val().replace(".",",").replace("?","").replace("&","");
    if(id == ""){
        $("#inputTexto").focus();
        return null;
    }
    var endereco = EnderecoAPI("/api/RomanosInteiros/ConverterRomanoInteiro/"+id);
    if(endereco != null){
        $.getJSON(endereco,
            function (data) {
                $(".modal-body").text(data);
                $("#ModalCenterTitle").text("Conversão de numero romano para inteiro")
                $("#modalResposta").modal('toggle');
            })
            .fail(function(jqxhr, textStatus, error ) {
                $(".modal-body").text("Confira se o endereço e porta da maquina foi digitado corretamente");
                $("#ModalCenterTitle").text("Conversão de numero romano para inteiro")
                $("#modalResposta").modal('toggle');
                $("#inputEndereco").focus();
            })
    }else{
        $("#inputEndereco").focus();
        return null;
    }
}

function ConverterNumeroTextoGalactical() {
    var id = $("#inputTexto").val().replace(".",",").replace("?","").replace("&","");
    
    if(id == ""){
        $("#inputTexto").focus();
        return null;
    }
    var endereco = EnderecoAPI("/api/InterGalactical/ConverterTextoGalactical/"+id);
    
    if(endereco != null){
        $.getJSON(endereco,
            function (data) {
                $(".modal-body").text(data);
                $("#ModalCenterTitle").text("Conversão do texto galactical")
                $("#modalResposta").modal('toggle');
            })
            .fail(function(jqxhr, textStatus, error ) {
                $(".modal-body").text("Confira se o endereço e porta da maquina foi digitado corretamente");
                $("#ModalCenterTitle").text("Conversão do texto galactical")
                $("#modalResposta").modal('toggle');
                $("#inputEndereco").focus();
            })
    }else{
        $("#inputEndereco").focus();
        return null;
    }
}

function EnderecoAPI(caminho){
    var enderecoMaquina = $("#inputEndereco").val().replace("https://").replace("http://", "").replace("/","");
    if(enderecoMaquina == ""){
        return null;
    }
    return "https://"+enderecoMaquina+caminho;     
}