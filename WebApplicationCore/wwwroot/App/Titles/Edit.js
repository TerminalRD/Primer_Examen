"use strict";
var TitlesEdit;
(function (TitlesEdit) {
    var formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    formulario.$mount("#AppEdit");
})(TitlesEdit || (TitlesEdit = {}));
//# sourceMappingURL=Edit.js.map