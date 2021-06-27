"use strict";
var DeparmentsGrid;
(function (DeparmentsGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "/Deparments/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    DeparmentsGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(DeparmentsGrid || (DeparmentsGrid = {}));
//# sourceMappingURL=Grid.js.map