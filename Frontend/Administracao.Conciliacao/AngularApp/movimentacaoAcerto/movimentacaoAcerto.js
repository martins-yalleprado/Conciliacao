
angular.module("MartinsApp").service("MovimentacaoAcertoService", function ($http, AppConstants) {
  this.getMovimentacaoAcertoPorData = function (data) {
    console.log(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${data}`);

    return $http.get(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${data}`);
  };

  this.putMovimentacaoAcerto = function (numSeq, objeto) {
    //var headerOptions = new Headers({ 'Content-Type': 'application/json' }); // , 'X-HTTP-Method-Override': 'PUT' 
    //var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });

    //return this.http.put(AppConstants.API_ROOT + '/api/MovimentoAcerto', objeto, requestOptions);
    return $http.put(AppConstants.API_ROOT + '/api/MovimentoAcerto', objeto);
  };

  this.postMovimentacaoAcerto = function (mov) {
    //var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    //var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });

    //return this.http.post(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov, requestOptions);
    return $http.post(`${AppConstants.API_ROOT}/api/MovimentoAcerto`, mov);
  };

  this.deleteMovimentoAcerto = function (numSeq, data, codIdt) {
    return $http.delete(`${AppConstants.API_ROOT}/api/MovimentoAcerto/${numSeq}/${data}/${codIdt}`);
  }

});

angular.module('MartinsApp').controller('MovimentacaoAcertoController', function ($scope, $http, AppConstants, MovimentacaoAcertoService, DataService) {

  class MovimentoContabilModel {
    get CodContaContabil() { return this._codContaContabil; }
    set CodContaContabil(value) { this._codContaContabil = value; }

    get CodEventoContabil() { return this._codEventoContabil; }
    set CodEventoContabil(value) { this._codEventoContabil = value; }

    get NomSistemaInformacao() { return this._nomSistemaInformacao; }
    set NomSistemaInformacao(value) { this._nomSistemaInformacao = value; }

    get CodFatoContabil() { return this._codFatoContabil; }
    set CodFatoContabil(value) { this._codFatoContabil = value; }

    get CodUnidadeNegocio() { return this._codUnidadeNegocio; }
    set CodUnidadeNegocio(value) { this._codUnidadeNegocio = value; }

    get CodIdentidadeContabil() { return this._codIdentidadeContabil; }
    set CodIdentidadeContabil(value) { this._codIdentidadeContabil = value; }

    get DesEventoContabil() { return this._desEventoContabil; }
    set DesEventoContabil(value) { this._desEventoContabil = value; }

    get DesFatoContabil() { return this._desFatoContabil; }
    set DesFatoContabil(value) { this._desFatoContabil = value; }
  }

  class MovimentacaoAcerto {
    //constructor(dataMovimento) {
    //  this._dataMovimento = dataMovimento;
    //}

    get VlrMovimentoCobranca() { return this._vlrMovimentoCobranca; }
    set VlrMovimentoCobranca(value) { this._vlrMovimentoCobranca = value; }

    get CodIdentidadeContabil() { return this._codIdentidadeContabil; } // .toUpperCase()
    set CodIdentidadeContabil(value) { this._codIdentidadeContabil = value; }

    get DataMovimento() { return this._dataMovimento; }
    set DataMovimento(value) { this._dataMovimento = value; }

    get NumSequenciaLancamento() { return this._numSequenciaLancamento; }
    set NumSequenciaLancamento(value) { this._numSequenciaLancamento = value; }

    get VlrMovimentoContabil() { return this._vlrMovimentoContabil; }
    set VlrMovimentoContabil(value) { this._vlrMovimentoContabil = value; }

    get DesAcertoConciliacaoBancaria() { return this._desAcertoConciliacaoBancaria; }
    set DesAcertoConciliacaoBancaria(value) { this._desAcertoConciliacaoBancaria = value; }

    get MovimentoContabilModel() { return this._movimentoContabilModel; }
    set MovimentoContabilModel(value) { this._movimentoContabilModel = value; }
  }

  var ModoOperacao = {
    "novo": 1,
    "edicao": 2
  };

  var _dataGridModalBackup;

  var _btnInserir;
  var _btnAlterar;
  var _btnExcluir;

  $scope.reset = function () {
    $scope.pesquisaModel.CodIdentidadeContabil = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.CodUnidadeNegocio = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.CodContaContabil = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.NomSistemaInformacao = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.CodEventoContabil = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.DesEventoContabil = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.CodFatoContabil = undefined;
    $scope.pesquisaModel.MovimentoContabilModel.DesFatoContabil = undefined;

    $scope.pesquisaModel.NumSequenciaLancamento = undefined;
    $scope.pesquisaModel.VlrMovimentoContabil = undefined;
    $scope.pesquisaModel.VlrMovimentoCobranca = undefined;
    $scope.pesquisaModel.DesAcertoConciliacaoBancaria = undefined;
  }

  $scope.resetModal = function () {
    $scope._dataGridModal = angular.copy(_dataGridModalBackup);

    $scope.pesquisaModalModel.MovimentoContabilModel.CodUnidadeNegocio = undefined;
    $scope.pesquisaModalModel.MovimentoContabilModel.CodContaContabil = undefined;

    $scope.pesquisaModalModel.MovimentoContabilModel.NomSistemaInformacao = undefined;
    $scope.pesquisaModalModel.MovimentoContabilModel.CodEventoContabil = undefined;
    $scope.pesquisaModalModel.MovimentoContabilModel.DesEventoContabil = undefined;
    $scope.pesquisaModalModel.MovimentoContabilModel.CodFatoContabil = undefined;
    $scope.pesquisaModalModel.MovimentoContabilModel.DesFatoContabil = undefined;
  }

  //on init
  $(document).ready(function () {
    console.log("Ready!");

    $scope._gridModalSize = 0;

    _dataGridModalBackup = [];

    var mov1 = new MovimentacaoAcerto();
    mov1.MovimentoContabilModel = new MovimentoContabilModel();

    var mov2 = new MovimentacaoAcerto();
    mov2.MovimentoContabilModel = new MovimentoContabilModel();

    $scope.pesquisaModel = mov1;
    $scope.pesquisaModalModel = mov2;

    _btnInserir = document.getElementById('btnInserir');
    _btnAlterar = document.getElementById('btnAlterar');
    _btnExcluir = document.getElementById('btnExcluir');

    _btnInserir.disabled = true;
    _btnAlterar.disabled = true;
    _btnExcluir.disabled = true;

    $scope.pesquisaModel.DataMovimento = new Date();
    $scope.getMovimentacaoAcertoPorData();
  });

  var formataData = function (dataref) {
    var data = dataref;

    if (data === undefined || data === "")
      return null

    if (typeof dataref === 'string') {
      if (dataref.search("-") == -1) {
        var parts = dataref.split("/");
        var day = parts[0];
        var month = parts[1];
        var year = parts[2];

        data = new Date(year, month - 1, day);

      } else {
        data = new Date(dataref); //data = new Date("2018-06-05T03:00:00.000Z");
      }
    }

    return data.format("yyyy-mm-dd");
  };

  $scope.getMovimentacaoAcertoPorData = function () {
    var dataPsq = formataData($scope.pesquisaModel.DataMovimento);

    if (dataPsq === null)
      return

    MovimentacaoAcertoService.getMovimentacaoAcertoPorData(dataPsq)
      .then(function (ResData) {
        $scope._dataGrid = ResData.data.Data;

        if ($scope._dataGrid.length > 0) {
          bindGridModal(dataPsq);
        }
        else {
          $scope._gridModalSize = 0;
        }
      }).catch(function (data) {
        alert("exceção - getMovimentacaoAcertoPorData")
      });
  }

  var bindGridModal = function (data) {
    $scope._dataGridModal = [];

    var codUN = 0;
    var codCnt = 0;

    $scope._dataGrid.forEach(i => {
      if (i.MovimentoContabilModel.CodUnidadeNegocio !== codUN || i.MovimentoContabilModel.CodContaContabil !== codCnt) {
        codUN = i.MovimentoContabilModel.CodUnidadeNegocio;
        codCnt = i.MovimentoContabilModel.CodContaContabil;

        $scope._dataGridModal.push(i.MovimentoContabilModel);
        //extra
        _dataGridModalBackup = angular.copy($scope._dataGridModal); // JSON.parse(JSON.stringify($scope._dataGridModal)); // copy
      }
    });

    $scope._gridModalSize = $scope._dataGridModal.length;
  }

  $scope.editForm = function (mov) {
    $scope.pesquisaModel = angular.copy(mov); // JSON.parse(JSON.stringify(mov)); // copy object
    // mod  
    var str = $scope.pesquisaModel.DataMovimento;

    $scope.pesquisaModel.DataMovimento = str;

    controledisponibilidade(ModoOperacao.edicao);
  }

  var controledisponibilidade = function (modo) {
    switch (modo) {
      case 1: {
        _btnInserir.disabled = false;
        _btnAlterar.disabled = true;
        _btnExcluir.disabled = true;
        break;
      }
      case 2: {
        _btnInserir.disabled = true;
        _btnAlterar.disabled = false;
        _btnExcluir.disabled = false;
        break;
      }
      default: {
        _btnInserir.disabled = true;
        _btnAlterar.disabled = true;
        _btnExcluir.disabled = true;
        break;
      }
    }
  }

  $scope.onSubmit = function (form) {
    console.log(form);

    if (form === undefined)
      return;

    if (form.CodIdentidadeContabil.$viewValue === undefined || form.CodIdentidadeContabil.$viewValue === "")
      return;

    if (form.NumSequenciaLancamento.$viewValue === undefined || form.NumSequenciaLancamento.$viewValue === "")
      return;

    var numSeq = 0;

    $scope._dataGrid.forEach(i => {
      if (i.CodIdentidadeContabil === form.CodIdentidadeContabil.$viewValue)
        numSeq = i.NumSequenciaLancamento;
    });

    if (form.NumSequenciaLancamento.$viewValue === numSeq) {

      // alterar
      if (!validaCampos(form))
        return;

      MovimentacaoAcertoService.putMovimentacaoAcerto(form.NumSequenciaLancamento.$viewValue, $scope.pesquisaModel) // form.value
        .then(function (ResData) {
          if (!ResData.data.Data.ErroModel.Sucesso)
            alert("Não foi possível atualizar a informação neste momento, tente novamente");

        }).catch(function (data) {
          alert("exceção - onsubmit put");
        });

    } else {

      // incluir
      if (!validaCampos(form))
        return;

      MovimentacaoAcertoService.postMovimentacaoAcerto($scope.pesquisaModel) //form.value
        .then(function (ResData) {

        }).catch(function (data) {
          alert("exceção - onsubmit post");
        });
    }
  }

  var validaCampos = function (form) {
    var vlrMovimentoCobranca = form.VlrMovimentoCobranca.$viewValue === undefined || form.VlrMovimentoCobranca.$viewValue === null ? "" : form.VlrMovimentoCobranca.$viewValue;
    var vlrMovimentoContabil = form.VlrMovimentoContabil.$viewValue === undefined || form.VlrMovimentoContabil.$viewValue === null ? "" : form.VlrMovimentoContabil.$viewValue;
    var desAcertoConciliacaoBancaria = form.DesAcertoConciliacaoBancaria.$viewValue === undefined ? "" : form.DesAcertoConciliacaoBancaria.$viewValue;

    var mensagem = "";

    if (vlrMovimentoContabil === "")
      mensagem = "Campo Valor Contábil é obrigatório e deve ser preenchido";
    else if (vlrMovimentoCobranca === "")
      mensagem = "Campo Valor Cobrança é obrigatório e deve ser preenchido";
    else if (desAcertoConciliacaoBancaria === "")
      mensagem = "Campo Descrição é obrigatório e deve ser preenchido";

    alert(mensagem);

    if (mensagem.length > 0)
      return false;

    return true;
  }

  $scope.selectForm = function (obj) {
    var mov = new MovimentacaoAcerto();
    mov.CodIdentidadeContabil = obj.CodIdentidadeContabil;
    mov.MovimentoContabilModel = obj;
    mov.DataMovimento = $scope.pesquisaModel.DataMovimento;

    $scope.editForm(mov);
    controledisponibilidade(null);
  };

  $scope.selecionarMovimentoContabil = function () {
    if ($scope._dataGridModal === undefined || $scope._dataGridModal.length === 0)
      return;

    var mov = new MovimentacaoAcerto();
    mov.CodIdentidadeContabil = $scope._dataGridModal[0].CodIdentidadeContabil;
    mov.MovimentoContabilModel = $scope._dataGridModal[0];
    mov.DataMovimento = $scope.pesquisaModel.DataMovimento;

    $scope.editForm(mov);
    controledisponibilidade(null);
  }

  $scope.onSearch = function (form) {
    if (form === undefined)
      return;

    var dataPsq = $scope.pesquisaModel.DataMovimento.toString();
    if (dataPsq == "")
      return

    // let codUnidade: string = form.value.CodUnidadeNegocio === undefined || form.value.CodUnidadeNegocio == "" ? "" : form.value.CodUnidadeNegocio;
    // let codConta: string = form.value.CodContaContabil === undefined || form.value.CodContaContabil == "" ? "" : form.value.CodContaContabil;

    // this.service.getMovimentacaoContabilPorData(codUnidade, codConta)
    //   .subscribe(data => {
    //     console.log("pesquisa modal");
    //     console.log(data["Data"]);

    //     this._dataGridModal = data["Data"];
    //     this._gridModalSize = this._dataGridModal == null ? 0 : this._dataGridModal.length;
    //   },
    //     (error) => {
    //       console.error("exceção - getMovimentacaoAcerto");
    //       console.error(error);
    //     }
    //   )

    var dataGridTemp = [];
    $scope._dataGridModal = angular.copy(_dataGridModalBackup); // <MovimentoContabilModel[] > JSON.parse(JSON.stringify(this._dataGridModalBackup)); // copy

    var codUnidadeNegocio = form.CodUnidadeNegocio.$viewValue === undefined || form.CodUnidadeNegocio.$viewValue === null ? 0 : form.CodUnidadeNegocio.$viewValue;
    var codContaContabil = form.CodContaContabil.$viewValue === undefined || form.CodContaContabil.$viewValue === null ? 0 : form.CodContaContabil.$viewValue;
    var nomSistemaInformacao = form.NomSistemaInformacao.$viewValue === undefined ? "" : form.NomSistemaInformacao.$viewValue.trim().toLowerCase();
    var codEventoContabil = form.CodEventoContabil.$viewValue === undefined || form.CodEventoContabil.$viewValue === null ? 0 : form.CodEventoContabil.$viewValue;
    var desEventoContabil = form.DesEventoContabil.$viewValue === undefined ? "" : form.DesEventoContabil.$viewValue.trim().toLowerCase();
    var codFatoContabil = form.CodFatoContabil.$viewValue === undefined || form.CodFatoContabil.$viewValue === null ? 0 : form.CodFatoContabil.$viewValue;
    var desFatoContabil = form.DesFatoContabil.$viewValue === undefined ? "" : form.DesFatoContabil.$viewValue.trim().toLowerCase();

    for (var i = 0; i < _dataGridModalBackup.length; i++) {

      if (codUnidadeNegocio != 0)
        if (_dataGridModalBackup[i].CodUnidadeNegocio != codUnidadeNegocio)
          continue;

      if (codContaContabil != 0)
        if (_dataGridModalBackup[i].CodContaContabil != codContaContabil)
          continue;

      if (nomSistemaInformacao != "")
        if (_dataGridModalBackup[i].NomSistemaInformacao.toString().trim().toLowerCase().search(nomSistemaInformacao) == -1)
          continue;

      if (codEventoContabil != 0)
        if (_dataGridModalBackup[i].CodEventoContabil != codEventoContabil)
          continue;

      if (desEventoContabil != "")
        if (_dataGridModalBackup[i].DesEventoContabil.toString().trim().toLowerCase().search(desEventoContabil) == -1)
          continue;

      if (codFatoContabil != 0)
        if (_dataGridModalBackup[i].CodFatoContabil != codFatoContabil)
          continue;

      if (desFatoContabil != "")
        if (_dataGridModalBackup[i].DesFatoContabil.toString().trim().toLowerCase().search(desFatoContabil) == -1)
          continue;

      dataGridTemp.push($scope._dataGridModal[i]);
    }

    $scope._dataGridModal = dataGridTemp;
    $scope._gridModalSize = $scope._dataGridModal == null ? 0 : $scope._dataGridModal.length;
  }

  $scope.excluir = function (form) {
    if (form === undefined)
      return;

    var numSequenciaLancamento = form.NumSequenciaLancamento.$viewValue === undefined ? "" : form.NumSequenciaLancamento.$viewValue;
    var dataMovimento = form.DataMovimento.$viewValue === undefined ? "" : form.DataMovimento.$viewValue;
    var codIdentidadeContabil = form.CodIdentidadeContabil.$viewValue === undefined ? "" : form.CodIdentidadeContabil.$viewValue;

    if (numSequenciaLancamento == "" || dataMovimento == "" || codIdentidadeContabil == "")
      return;

    if (confirm('Tem certeza que deseja cancelar esse registro ?') == true) {

      MovimentacaoAcertoService.deleteMovimentoAcerto(numSequenciaLancamento, dataMovimento, codIdentidadeContabil)
        .then(function (ResData) {
          console.log(ResData.data.Data);

        }).catch(function (data) {
          alert("exceção - excluir")
        });
    }
  }

  $scope.proximaSequencia = function (form) {
    if (form === undefined)
      return;

    if (form.CodIdentidadeContabil.$viewValue === undefined || form.CodIdentidadeContabil.$viewValue === "")
      return;

    var numSeq = 0;

    $scope._dataGrid.forEach(i => {
      if (i.CodIdentidadeContabil == form.CodIdentidadeContabil.$viewValue && numSeq < i.NumSequenciaLancamento)
        numSeq = i.NumSequenciaLancamento;
    });

    $scope.pesquisaModel.NumSequenciaLancamento = (numSeq + 1);

    controledisponibilidade(ModoOperacao.novo);
  }

  $scope.sequencia = function (form) {
    var vlrCampo = form.NumSequenciaLancamento.$viewValue === undefined ? "" : form.NumSequenciaLancamento.$viewValue; //  form.value.NumSequenciaLancamento;
    var codIdentidadeContabil = form.CodIdentidadeContabil.$viewValue === undefined ? "" : form.CodIdentidadeContabil.$viewValue;
    var existe = false;

    $scope._dataGrid.forEach(i => {
      if (i.CodIdentidadeContabil == codIdentidadeContabil && i.NumSequenciaLancamento == vlrCampo) {
        existe = true;
        // form.value.VlrMovimentoContabil = i.VlrMovimentoContabil;
        // form.value.VlrMovimentoCobranca = i.VlrMovimentoCobranca;
        // form.value.DesAcertoConciliacaoBancaria = i.DesAcertoConciliacaoBancaria;
        //break/
      }
    });

    if (vlrCampo == "" || codIdentidadeContabil == "") {
      controledisponibilidade(null);
    } else {
      controledisponibilidade(ModoOperacao.novo);

      if (existe) {
        controledisponibilidade(ModoOperacao.edicao);
      }
    }
  }

});

