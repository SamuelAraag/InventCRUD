sap.ui.define([
	"sap/ui/core/mvc/Controller"

], function (Controller) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

		onInit: function(){
			this.getView().addStyleClass(this.getOwnerComponent().getContentDensityClass());
		},
	});
});