sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "sap/ui/model/json.JSONModel"

], function (Controller, JSONModel) {
	"use strict";
	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

        //criando modelo json para usuario
		onInit: function () {
            var oModel = new JSONModel();
            oModel.setData({
                "Usuario":{
                    "nome": "string",
                    "senha": "string",
                    "email": "string@string.com",
                    "dataNascimento": "2000-07-08T18:36:04.710Z"
                }
            });
            this.getView().setModel(oModel);


			this.getView().setModel(new JSONModel({
				nome: "SamuelAPI",
				senha: "1234123",
				email: "samuel@samuel.com",
				dataNascimento: "2000-07-08T18:36:04.710Z",
			}), "Usuario")
		},

		salvarNoBancoDeDados: function () {
			var cliente = this.getView().getModel("Usuario");

			fetch('https://localhost:7137/api/Usuario/', {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(cliente.getData())
			})
				.then((resposta) => resposta.json())
				.then((data) => console.log(data))

		},

	});
 })