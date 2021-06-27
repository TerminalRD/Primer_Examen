"use strict";
var JobsEdit;
(function (JobsEdit) {
    var formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    formulario.$mount("#AppEdit");
})(JobsEdit || (JobsEdit = {}));
//# sourceMappingURL=Edit.js.map