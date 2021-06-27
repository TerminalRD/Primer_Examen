using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Jobs
{
    public class EditModel : PageModel
    {
        public EditModel(IJobsService jobsService)
        {
            JobsService = jobsService;
        }

        public IJobsService JobsService { get; }

        [BindProperty]
        public JobsEntity Entity { get; set; } = new JobsEntity();

        [BindProperty(SupportsGet =true)]
        public int? id {get; set;}

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await JobsService.GetById(new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)
                { // Actualizar registro
                    var result = await JobsService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {   //Nuevo registro
                    var result = await JobsService.Create(Entity);
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
