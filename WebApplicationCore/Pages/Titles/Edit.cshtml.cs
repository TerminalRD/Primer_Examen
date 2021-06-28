using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Titles
{
    public class EditModel : PageModel
    {
        public EditModel(ITitlesService titlesService)
        {
            TitlesService = titlesService;
        }

        public ITitlesService TitlesService { get; }

        [BindProperty]
        public TitlesEntity Entity { get; set; } = new TitlesEntity();

        [BindProperty(SupportsGet =true)]
        public int? id {get; set;}

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await TitlesService.GetById(new() { Id_Titulo = id });
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
                if (Entity.Id_Titulo.HasValue)
                { // Actualizar registro
                    var result = await TitlesService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {   //Nuevo registro
                    var result = await TitlesService.Create(Entity);
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
