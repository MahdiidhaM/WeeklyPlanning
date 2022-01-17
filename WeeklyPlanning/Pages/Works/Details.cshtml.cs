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
    public class DetailsModel : PageModel
    {
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public DetailsModel(WeeklyPlanning.Data.WeeklyPlanningContext context)
        {
            _context = context;
        }

        public Work Work { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Work = await _context.Work.FirstOrDefaultAsync(m => m.ID == id);

            if (Work == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
