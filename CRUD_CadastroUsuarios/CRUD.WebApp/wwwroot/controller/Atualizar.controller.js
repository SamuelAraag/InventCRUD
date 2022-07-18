sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",

], function (Controller, History, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Atualizar", {

		onInit: function(){
			this.getView().setModel(new JSONModel({
				
			nome: "",
			senha: "",
			email: "",
			dataNascimento: "",
			}), "usuario") 
		},

		aoClicarEmSalvar: function(){
			var usuarioTela = this.getView().getModel("usuario")
            //preciso pegar o id do usuario

			fetch('https://localhost:7137/api/Usuario', {
				method: 'PUT',
				headers: {
                    'Accept': 'application/json',
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