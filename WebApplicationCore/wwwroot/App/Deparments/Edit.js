"use strict";
var DeparmentsEdit;
(function (DeparmentsEdit) {
    var formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    formulario.$mount("#AppEdit");
})(DeparmentsEdit || (DeparmentsEdit = {}));
//# sourceMappingURL=Edit.js.map