sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History"

], function (Controller, JSONModel, History ) {
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
					var oModel = new JSONModel(dados);
					this.getView().setModel(oModel, "usuario")
				})
		},

		//Aqui preciso retornar o objeto completo, todas as informações
		buscarUsuarioPorId: function(id){
			return fetch(`https://localhost:7137/api/Usuario/${id}`)
				.then((resposta) => resposta.json());
		},


















        aoClicarEmEditar: function(){
            var oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("lista")
        },

        aoClicarEmCancelar: function(){
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("lista", {}, true);
			}
		},
	});
});