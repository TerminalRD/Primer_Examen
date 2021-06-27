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
    public class EditModel : PageModel
    {
        public EditModel(IDeparmentsService deparmentsService)
        {
            DeparmentsService = deparmentsService;
        }

        public IDeparmentsService DeparmentsService { get; }

        [BindProperty]
        public DeparmentsEntity Entity { get; set; } = new DeparmentsEntity();

        [BindProperty(SupportsGet =true)]
        public int? id {get; set;}

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await DeparmentsService.GetById(new() { Id_Departamento = id });
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Content(content: ex.Message);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.Id_Departamento.HasValue)
                { // Actualizar registro
                    var result = await DeparmentsService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {   //Nuevo registro
                    var result = await DeparmentsService.Create(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó correctamente";
                }
                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {
                return Content(content: ex.Message);
            }

        }
    }
}
