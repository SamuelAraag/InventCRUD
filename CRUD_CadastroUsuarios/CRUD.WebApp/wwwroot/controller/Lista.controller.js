sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History"

], function (Controller, JSONModel, History) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Lista", {

        onInit: function(){
			this.getOwnerComponent()
			.getRouter()
			.getRoute("lista")
			.attachPatternMatched(this.aoCoincidirComRota, this)
		},

        aoCoincidirComRota: function(evento){
            this.carregarUsuariosDoBanco();
        },

		buscarUsuariosDoBanco : function (){
            let usuariosObtidos = fetch('https://localhost:7137/api/Usuario')
            .then((resposta) => resposta.json())
			return (usuariosObtidos)
        },

		carregarUsuariosDoBanco: function(){
			var resultado = this.buscarUsuariosDoBanco();
			resultado.then(lista=> {
				var oModel = new JSONModel(lista);
				this.getView().setModel(oModel, "listaDeUsuarios")
			})
		},

		aoClicarEmCriar: function(id){
			let idUsuario = 0;
			let oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("cadastro", {id: idUsuario})
		},

		modelo: function(nome, modelo){
			var view = this.getView();
			if(!modelo){
				view.setModel(modelo, nome);
			}
			return view.getModel(nome);
		},

		modeloListaDeUsuarios: function(modelo){
			const nome = "listaDeUsuarios";
			return this.modelo(nome, modelo);
		},

		aoClicarNoUsuario: function(oEvent){
			var idEvento = oEvent
				.getSource()
				.oBindingContexts
				.listaDeUsuarios
				.getObject("id");
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detalhes", {id: idEvento});
		},
	});
});