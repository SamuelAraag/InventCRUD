sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageToast"

], function (Controller, History, JSONModel, MessageToast) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

		onInit: function(){
			this.getOwnerComponent()
			.getRouter()
			.getRoute("cadastro")
			.attachPatternMatched(this.aoCoincidirComRota, this)
		},

		aoCoincidirComRota: function(oEvent){
			this._idDoUsuario = oEvent
				.getParameter("arguments")
				.id;
				this._idDoUsuario != 0 ? this.carregarUsuario(this._idDoUsuario): this.inicializarModelDaTela();
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

		aoClicarEmSalvar: function(){
			var usuarioTela = this.getView().getModel("usuario").getData();
			this._idDoUsuario != 0 ? this.metodoAtualizar(usuarioTela) : this.metodoCriar(usuarioTela)
		},

		aoClicarEmCancelar: function(){
			this.voltarNavegacao();
		},

		voltarNavegacao: function(){
			let oHistory = History.getInstance();
			let sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("lista", {}, true);
			}
		},

		mostrarMensagem: function(mensagem){
			return new Promise((resolve, reject) => 
				MessageToast.show(mensagem, { onClose: () => resolve(), duration: 300 } ) 
			);
		},

		inicializarModelDaTela: function(){
			this.getView().setModel(new JSONModel({
				nome: "",
				senha: "",
				email: "",
				dataNascimento: "",
				}), "usuario") 
		},

		metodoAtualizar: function(usuarioTela){
			fetch(`https://localhost:7137/api/Usuario/${usuarioTela.id}`, {
					method: 'PUT',
					headers: {
						'Accept': 'application/json',
						'content-type': 'application/json'
					},
					body: JSON.stringify(usuarioTela)
				})
			.then(() => this.mostrarMensagem("Usuário atualizado")) 
			.then(() => this.voltarNavegacao())
		},

		metodoCriar: function(usuarioTela){
			fetch('https://localhost:7137/api/Usuario', {
					method: 'POST',
					headers: {
						'Accept': 'application/json',
						'content-type': 'application/json'
					},
				body: JSON.stringify(usuarioTela)
			})
			.then(() => this.mostrarMensagem("Usuário cadastrado")) 
			.then(() => this.voltarNavegacao());
		}
	});
});