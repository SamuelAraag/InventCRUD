sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageToast"
], function (Controller, JSONModel, MessageToast) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.App", {

		onInit: function(){
			this.getView().addStyleClass(this.getOwnerComponent().getContentDensityClass());
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

		aoClicarEmCriar: function(){
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("cadastro")

			// return MessageToast.show("botão criar funcionando!")
			// var teste = this.
			// 	getView().
			// 	getModel("listaDeUsuarios").
			// 	getData()
			// console.log(teste)
		}



		//Botão funcionando
		// aoClicarEmCriar: function(){
		// 	return MessageToast.show("botão criar funcionando!")

		// }
	});
});