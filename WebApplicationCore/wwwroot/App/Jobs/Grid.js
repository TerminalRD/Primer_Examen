"use strict";
var JobsGrid;
(function (JobsGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "/Jobs/Grid?handler=Eliminar&id" + id;
            }
        });
    }
    JobsGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").dataTable();
})(JobsGrid || (JobsGrid = {}));
//# sourceMappingURL=Grid.js.map