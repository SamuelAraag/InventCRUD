sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"sap/m/MessageToast",
	"sap/ui/core/Fragment"

], function (Controller, JSONModel, History, MessageToast, Fragment) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Detalhes", {
		
        onInit: function(){
			this.getOwnerComponent()
			.getRouter()
			.getRoute("detalhes")
			.attachPatternMatched(this.aoCoincidirComRota, this)
		},

		aoCoincidirComRota: function(oEvent){
			var idDoUsuario = oEvent
				.getParameter("arguments")
				.id;
				
            this.carregarUsuario(idDoUsuario);
		},

		carregarUsuario: function(id){
			this.buscarUsuarioPorId(id)
				.then(dados => {
					let oModel = new JSONModel(dados);
					this.getView().setModel(oModel, "usuario")
				})
		},

		buscarUsuarioPorId: function(id){
			return fetch(`https://localhost:7137/api/Usuario/${id}`)
				.then((resposta) => resposta.json())
		},

        aoClicarEmEditar: function(){
            let oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("lista")
        },

        aoClicarEmCancelar: function(){
			let oHistory = History.getInstance();
			let sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("lista", {}, true);
			}
		},

		aoClicarEmDeletar: function(){
			let id = this.getView().getModel("usuario").getData().id;
			fetch(`https://localhost:7137/api/Usuario/${id}`, {
				method: 'DELETE'
			})
			alert("Usuário deletado")
			this.aoClicarEmCancelar();
		},

		onCloseDialog : function () {
			this.byId("helloDialog").close();
		}
	});
});