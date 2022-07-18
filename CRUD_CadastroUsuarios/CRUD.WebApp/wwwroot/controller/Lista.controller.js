sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",

], function (Controller, History, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

        onInit: function(){
			
			this.getView().getRouter();
		},

        aoCoincidirComRota: function(){

            //corrigir metodo, ao coincidir com a rota, executa esse metodo e carrega a lista
            this.carregarUsuariosDoBanco();
        },

		buscarUsuariosDoBanco : function (){
            var usuariosObtidos = fetch('https://localhost:7137/api/Usuario')
            .then((resposta) => resposta.json())
			return (usuariosObtidos)
        },

		carregarUsuariosDoBanco: function(){
			var resultado = this.buscarUsuariosDoBanco();
			resultado.then(lista=> {
				var oModel = new JSONModel(lista);
				this.getView().setModel(oModel, "listaDeUsuarios")
			})
			return MessageToast.show("Usuarios carregados")
		},

		aoClicarEmSalvar: function(){
			var usuarioTela = this.getView().getModel("usuario")

			fetch('https://localhost:7137/api/Usuario', {
				method: 'POST',
				headers: {
					'content-type': 'application/json'
				},
				body: JSON.stringify(usuarioTela.getData())
			})
			.then((resposta) => resposta.json())
			alert("Usuário cadastrado")
		},

		aoClicarEmCancelar: function(){
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("overview", {}, true);
			}
		},
	});
});