#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeklyPlanning.Data;
using WeeklyPlanning.Models;

namespace WeeklyPlanning.Pages.Works
{
    public class EditModel : PageModel
    {
        private readonly WeeklyPlanning.Data.WeeklyPlanningContext _context;

        public EditModel(WeeklyPlanning.Data.WeeklyPlanningContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(Work.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.ID == id);
        }
    }
}
