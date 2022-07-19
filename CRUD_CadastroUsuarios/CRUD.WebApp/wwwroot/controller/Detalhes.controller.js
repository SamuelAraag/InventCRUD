sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History"


], function (Controller, History) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Detalhes", {

		onInit: function(){
			this.getView().addStyleClass(this.getOwnerComponent().getContentDensityClass());
		},

        aoClicarEmEditar: function(){
            var oRouter = this.getOwnerComponent().getRouter();
            //criar caminho e tela para editar o usuario
            oRouter.navTo("cadastro")
        },

        // aoClicarEmCancelar: function(){
        //     var oRouter = this.getOwnerComponent().getRouter();
        //     oRouter.navTo("lista")

        // },

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


//copiei a controller app