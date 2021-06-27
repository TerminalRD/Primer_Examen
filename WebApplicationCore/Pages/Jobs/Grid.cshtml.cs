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
    public class GridModel : PageModel
    {
        private readonly IJobsService jobsService;

        public GridModel(IJobsService jobsService)
        {
            this.jobsService = jobsService; //Nos va a permitir llamar los metodos
        }

        public void OnGet()
        {

        }

    }
}
