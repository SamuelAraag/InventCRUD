sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",

], function (Controller, History, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

		onInit: function(){
			this.getView().setModel(new JSONModel({
				
			nome: "",
			senha: "",
			email: "",
			dataNascimento: "",
			}), "usuario") 
		},

		aoClicarEmSalvar: function(){
			//não está formatando a data, para datetime
			var usuarioTela = this.getView().getModel("usuario")
			var dateFormat = sap.ui.core.format.DateFormat.getDateInstance({pattern : "YYYY/MM/DD" });   
			var dataFormatada = dateFormat.format(usuarioTela.dataNascimento);
			usuarioTela.dataNascimento = dataFormatada;
			console.log(usuarioTela);


			fetch('https://localhost:7137/api/Usuario', {
				method: 'POST',
				headers: {
					'content-type': 'application/json'
				},
				body: JSON.stringify(usuarioTela.getData())
			})
			.then((resposta) => resposta.json())
			.then((data) => console.log(data))
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
		}

	});
});