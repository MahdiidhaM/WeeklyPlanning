#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeeklyPlanning.Data;
using WeeklyPlanning.Models;

namespace WeeklyPlanning.Pages.Works
{
    public class CreateModel : PageModel
    {
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public CreateModel(WeeklyPlanning.Data.WeeklyPlanningContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Work Work { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Work.Add(Work);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
