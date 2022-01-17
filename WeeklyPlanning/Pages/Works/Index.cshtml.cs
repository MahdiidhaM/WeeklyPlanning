#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeklyPlanning.Data;
using WeeklyPlanning.Models;

namespace WeeklyPlanning.Pages.Works
{
    public class IndexModel : PageModel
    {
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public IndexModel(WeeklyPlanning.Data.WeeklyPlanningContext context)
        {
            _context = context;
        }

        public IList<Work> Work { get;set; }

        public async Task OnGetAsync()
        {
            Work = await _context.Work.ToListAsync();
        }
    }
}
