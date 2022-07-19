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
		},
		aoClicarEmCriar: function(){
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("cadastro")
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


		//Preciso passar o id quando clicado no usuario da tela, lista
		aoClicarNoUsuario: function(oEvent){
			var eventoCapturado = oEvent.getSource();

			// var oRouter = this.getOwnerComponent().getRouter();
			// oRouter.navTo("detalhes", {
			// 	//id deve receber a propriedade que indica qual usuario/id foi clicado na tela
			// 	id: window.encodeURIComponent(oItem.getBindingContext("listaDeUsuarios"))
			// });
		},
	});
});