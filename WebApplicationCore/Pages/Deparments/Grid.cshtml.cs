using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Deparments
{
    public class GridModel : PageModel
    {
        private readonly IDeparmentsService deparmentsService;

        public GridModel(IDeparmentsService deparmentsService)
        {
            this.deparmentsService = deparmentsService; //Nos va a permitir llamar los metodos
        }

        public IEnumerable<DeparmentsEntity> GridList { get; set; } = new List<DeparmentsEntity>();
        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet() // Pos ser asincronico no puede ser public void
        {
            try
            {
                GridList = await deparmentsService.Get();
                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Content(content: ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id) // Pos ser asincronico no puede ser public void
        {
            try
            {
                var result = await deparmentsService.Delete(new()
                {
                    Id_Departamento=id
                });
                if (result.CodeError!=0)
                {
                    throw new Exception(message: result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";
                return Redirect("Grid");
            }
            catch (Exception ex)
            {
                return Content(content: ex.Message);
            }
        }

    }
}
