"use strict";
var TitlesGrid;
(function (TitlesGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "/Titles/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    TitlesGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(TitlesGrid || (TitlesGrid = {}));
//# sourceMappingURL=Grid.js.map